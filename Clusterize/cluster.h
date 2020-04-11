#pragma once

#include "branch.h"

#include "SortedPair.h"
#include "segment.h"
#include <list>
#include <map>
#include <set>
#include <fstream>

/*
	Требования к T

	double static T::Distance(const T&, const T&)
		Условное расстояние между двумя объектами

	T static T::Average(const list<T>)
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

	// Возвращает список всех объектов кластера
	virtual std::list<T> tolist() const = 0;

protected:

	// Возвращает центр кластера
	virtual T mid() const = 0;

	// Для вызова из родителя
	virtual void save(std::ofstream&) const = 0;

	typedef SortedPair<Cluster<T>*> Segment;
	//typedef Segment<Cluster<T>*> Segment;

};

// РЕАЛИЗАЦИЯ

template<class T>
inline Cluster<T>* Cluster<T>::clusterize(std::list<T> elems_list)
{
	std::list<Cluster<T>*> clusters;
	
	// Инициализация исходного состояния алгоритма
	for (T el : elems_list)
		clusters.push_back(new Leave<T>(el));

	// Начальный расчёт всех расстояний
	std::map<Segment, double> distances;
	for (auto i = clusters.begin(); (i != clusters.end()) && ((i + 1) != clusters.end()); ++i)
		for (auto j = i + 1; j != clusters.end(); ++j)
			distances[Segment(*i, *j)] = T::Distance(*i->mid(), *j->mid());

	// Основная фаза алгоритма
	while (clusters.size() > 1)
	{
		// Поиск ближайших кластеров
		Segment shortest = distances.begin()->first;
		double min = distances.begin()->second;
		for (auto& d : distances)
			if (d.second < min)
			{
				min = d.second;
				shortest = d.first;
			}

		// Объединение кластеров
		Branch<T> new_cluster = new Branch<T>(shortest.val[0], shortest.val[1]);
		clusters.remove(shortest.val[0]);
		clusters.remove(shortest.val[1]);

	}

	return NULL;
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

	return 0;
}
