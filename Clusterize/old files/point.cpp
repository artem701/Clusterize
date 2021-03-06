#include "point.h"

#include <cstdarg>

/*
Point::Point(unsigned int n, ...)
{
	this->n = n;

	va_list vl;
	va_start(vl, n);

	for (; n > 0; --n)
		coords.push_back(va_arg(vl, double));

	va_end(vl);
}*/

Point::Point(const std::vector<double>& coords)
{
	this->n = coords.size();
	this->coords = coords;
}

double Point::operator[](int i) const
{
	return coords[i];
}

double Point::Distance(const Point& a, const Point& b)
{
	if (a.n != b.n)
		throw std::exception("Incompatible points in Point::Distance");

	double quads = 0.0;
	for (int i = 0; i < a.n; ++i)
		quads += pow(a[i] - b[i], 2.0);

	return sqrt(quads);
}

Point Point::Average(std::list<Point> l)
{
	int n = l.front().n;
	std::vector<double> midcoords;
	midcoords.resize(n);
	int sz = l.size();
	
	for (int j = 0; j < n; ++j)
	{
		double sum = 0.0;
		std::list<Point>::iterator i;
		for (i = l.begin(); i != l.end(); ++i)
			sum += i->coords[j];
		
		midcoords[j] = sum / sz;
	}

	return Point(midcoords);
}

void Point::flush(std::ofstream& ofs) const
{
	ofs << n;
	for (int i = 0; i < n; ++i)
		ofs << coords[i];
}

int Point::dimensions() const
{
	return n;
}
