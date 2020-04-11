﻿#pragma once

#include <vector>
#include <list>
#include <iostream>
#include <fstream>

// Кластеризуемый класс точки в n-мерном пространстве
class Point {
	std::vector<double> coords;
	int n;
public:
	Point();
	Point(const std::vector<double>&);

	double operator [](int) const;

	static double Distance(const Point&, const Point&);
	static Point Average(const std::list<Point>);
	void flush(std::ofstream&) const;

	int dimensions() const;

	//bool operator <(const Point&) const;
};