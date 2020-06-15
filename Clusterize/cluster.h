#pragma once

#include "branch.h"

#include "segment.h"
#include <list>
#include <set>
#include <iterator>
#include <fstream>
#include <iostream>

/*
	Требования к T

	Наличие конструктора по умолчанию

	double static T::Distance(const T&, const T&)
		Условное расстояние между двумя объектами

	T static T::Average(const T& a, int weight_a, const T& b, int weight_b)
		Усредненный объект

	void T::flush(ofstream&)
		Запись в файл
*/

template <class T>
class Cluster
{
public:

	// Основной алгоритм кластеризации
	static Cluster<T>* clusterize(std::list<T>);

	int save(const char*) const;

	// Возвращает центр кластера
	virtual T mid() const = 0;

	// Для вызова из родителя
	virtual void save(std::ofstream&) const = 0;

	virtual ~Cluster() { }

	typedef Segment<Cluster<T>*> Segment;

};

// РЕАЛИЗАЦИЯ

template<class T>
inline Cluster<T>* Cluster<T>::clusterize(std::list<T> elems_list)
{
	if (elems_list.empty())
		return nullptr;

	std::list<Cluster<T>*> clusters;
	
	// Инициализация исходного состояния алгоритма
	for (T el : elems_list)
		clusters.push_back(new Leave<T>(el));

	std::cout << "Начальный расчет расстояний между точками...\n";

	// Начальный расчёт всех расстояний
	std::multiset<Segment> segments;
	for (auto i = clusters.begin(); i != clusters.end(); ++i)
	{
		auto j = i;
		while (++j != clusters.end())
		{
			segments.insert(Segment(*i, *j, T::Distance((*i)->mid(), (*j)->mid())));
		}
	}

	int prev_clust_num = clusters.size();
	std::cout << "Текущее количество обрабатываемых кластеров:\n";
	std::cout << prev_clust_num << "\n";

	// Основная фаза алгоритма
	while (clusters.size() > 1)
	{
		// Поиск ближайших кластеров
		// В силу упорядоченности множества это первый элемент
		Segment shortest = *segments.begin();

		// Объединение кластеров и очистка устаревшей информации
		Branch<T>* new_cluster = new Branch<T>(shortest.first, shortest.second);
		clusters.remove(shortest.first);
		clusters.remove(shortest.second);
		//segments.erase(segments.begin());

		// Удаляем каждый отрезок, включающий хотя бы одну из поглощенных вершин
		for (auto it = segments.begin(); it != segments.end();)
			if ((it->first  == shortest.first) || (it->first  == shortest.second) ||
				(it->second == shortest.first) || (it->second == shortest.second))
			{
				it = segments.erase(it);
			}
			else
			{
				++it;
			}

		// Подсчет новых расстояний
		for (Cluster<T>* c : clusters)
			segments.insert(Segment(c, new_cluster, T::Distance(c->mid(), new_cluster->mid())));

		// Наконец, добавление сформированного кластера в список
		clusters.push_back(new_cluster);
		
		// Оповещаем пользователя о прогрессе алгоритма
		int clust_num = clusters.size();
		if (clust_num != prev_clust_num)
		{
			prev_clust_num = clust_num;
			std::cout << clust_num << "\n";
		}
	}

	// Возвращаем последний оставшийся кластер в списке
	return clusters.front();
}

// Сохранение в файл в виде:
// Лист: (<значение>)
// Вершина: {<подкластер><подкластер>}
template<class T>
inline int Cluster<T>::save(const char * fname) const
{
	std::ofstream of(fname);
	if (!of)
		return 1;

	this->save(of);
	of.close();

	return 0;
}
