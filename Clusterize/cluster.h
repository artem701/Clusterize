#pragma once

#include "leave.h"

#include "SortedPair.h"
#include <list>

template <class T>
class Cluster
{
public:

	// Основной алгоритм кластеризации
	static Cluster<T>* clusterize(std::list<T>);

	int save(const char*) const;

	// Возвращает список всех объектов кластера
	virtual std::list<T> tolist() const;

protected:

	// Возвращает центр кластера
	virtual T mid() const = 0;

	// Для вызова из родителя
	virtual int save(std::ofstream&) const = 0;

	typedef SortedPair<T> Segment;

};

// РЕАЛИЗАЦИЯ

template<class T>
inline Cluster<T>* Cluster<T>::clusterize(std::list<T>)
{
	return NULL;
}
