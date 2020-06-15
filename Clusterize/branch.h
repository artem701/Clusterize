#pragma once

#include "leave.h"


template <class T>
class Branch : public Cluster<T>
{
	// Поддеревья
	Cluster<T> *t1, *t2;
	T average;
public:
	Branch(Cluster<T>* a, Cluster<T>* b);

	T mid() const override;
	void save(std::ofstream&) const override;

	~Branch();
};

template<class T>
inline Branch<T>::Branch(Cluster<T>* a, Cluster<T>* b) : average(T())
{
	// Назначаем ветвям кластеры a и b
	t1 = a;
	t2 = b;

	// Заранее вычисляем среднее значение кластера
	average = T::Average(t1->mid(), t2->mid());
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
	t1->save(of);
	t2->save(of);
	of << "}";
}

template<class T>
inline Branch<T>::~Branch()
{
	delete t1;
	delete t2;
}
