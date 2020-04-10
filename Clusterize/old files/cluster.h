#pragma once

#include <list>
#include <iterator>
#include <stdio.h>

/*
	Требования к T

	unsigned double static T::Distance(const T&, const T&)
		Условное расстояние между двумя объектами

	T static T::Average(list<T>)
		Усредненный объект

	void T::flush(ofstream&)
		Запись в файл
*/

template <class T>
class Cluster
{
public:
	Cluster(std::list<T>);

	int save(const char*) const;

protected:
	/* Для вызова из родителя */
	virtual int save(std::ofstream&) const = 0;

	/* Возвращает центр кластера */
	virtual T mid() const = 0;

	/* Возвращает список всех объектов кластера */
	virtual std::list<T> tolist() const = 0;
};