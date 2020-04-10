#pragma once

#include <vector>
#include <list>
#include <iostream>
#include <fstream>

/*
	Требования к T
	unsigned double static T::Distance(const T&, const T&)
	T static T::Average(list<T>)
	void T::flush(ofstream&)
*/
/* Кластеризуемый класс точки в n-мерном пространстве */
class Point {
	std::vector<double> coords;
	int n;
public:
	Point(const std::vector<double>&);
	//Point(unsigned int, ...);

	double operator [](int) const;

	static double Distance(const Point&, const Point&);
	static Point Average(const std::list<Point>);
	void flush(std::ofstream&) const;

	int dimensions() const;
};