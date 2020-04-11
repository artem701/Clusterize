#pragma once

#include "leave.h"


template <class T>
class Branch : public Cluster<T>
{
	// Поддеревья
	Cluster<T> *t1, *t2;
	T average;
	//std::list<T> l;
public:
	Branch(Cluster<T>* a, Cluster<T>* b);

	std::list<T> tolist() const override;
	T mid() const override;
	void save(std::ofstream&) const override;

	~Branch();
};

template<class T>
inline Branch<T>::Branch(Cluster<T>* a, Cluster<T>* b)
{
	// Назначаем ветвям кластеры a и b
	t1 = a;
	t2 = b;

	// Заранее вычисляем среднее значение кластера
	std::list<T> l, l2;
	l = t1->tolist();
	l2 = t2->tolist();
	l.insert(l.begin(), l2.begin(), l2.end());

	average = T::Average(l);
}

template<class T>
inline std::list<T> Branch<T>::tolist() const
{
	std::list<T> l, l2;
	l = t1->tolist();
	l2 = t2->tolist();
	l.insert(l.begin(), l2.begin(), l2.end());
	
	return l;
}

template<class T>
inline T Branch<T>::mid() const
{
	return average;
}

template<class T>
inline void Branch<T>::save(std::ofstream & of) const
{
	of << "{";
	t1->save;
	t2->save;
	of << "}";
}

template<class T>
inline Branch<T>::~Branch()
{
	delete t1;
	delete t2;
}
