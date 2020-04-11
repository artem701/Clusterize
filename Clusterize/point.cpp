#include "point.h"


Point::Point()
{
}

Point::Point(const std::vector<double>& coords)
{
	this->n = coords.size();
	this->coords = coords;
}

double Point::operator[](int i) const
{
	return coords.at(i);
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
		for (auto i = l.begin(); i != l.end(); ++i)
			sum += i->coords[j];
		
		midcoords[j] = sum / (double)(sz);
	}

	return Point(midcoords);
}

void Point::flush(std::ofstream& ofs) const
{
	// переделать
	for (int i = 0; i < n-1; ++i)
		ofs << coords[i] << ", ";
	ofs << coords[n - 1];
}

int Point::dimensions() const
{
	return n;
}
/*
bool Point::operator<(const Point & a) const
{
	if (n != a.n)
		throw std::exception("Incompatible comparison in Point::operator<");

	for (int i = 0; i < n; ++i)
	{
		if (coords[i] < a.coords[i])
			return true;
		if (coords[i] > a.coords[i])
			return false;
	}
	return false;
}*/
