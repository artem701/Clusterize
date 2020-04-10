#pragma once

#include "leave.h"
#include "branch.h"

#include "SortedPair.h"


template <class T>
class Cluster
{
public:

	typedef typename std::list<typename Cluster<T>*>::iterator iterator;

	// Основной алгоритм кластеризации
	Cluster(std::list<T>);

	int save(const char*) const;

	// Возвращает центр кластера
	virtual T mid() const = 0;

	// Возвращает список всех объектов кластера
	virtual std::list<T> tolist() const = 0;

protected:

	// Для вызова из родителя
	virtual int save(std::ofstream&) const = 0;

	typedef SortedPair<T> Segment;

};

// РЕАЛИЗАЦИЯ

template<class T>
inline Cluster<T>::Cluster(std::list<T> list_of_elems)
{
}
