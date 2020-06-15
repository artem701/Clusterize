#include "point.h"

int Point::n = 0;

Point::Point()
{
}

Point::Point(const std::vector<double>& coords, double w)
{
	if (n < 1)
	{
		throw std::exception("Ошибка конструирования Point: не установлена размерность пространства");
	}
	if (coords.size() != Point::n)
	{
		throw std::exception("Ошибка конструирования Point: неверное количество передаваемых координат");
	}
	//this->n = coords.size();
	this->coords = coords;
	this->weight = w;
}

double Point::operator[](int i) const
{
	return coords.at(i);
}

double Point::Distance(const Point& a, const Point& b)
{
	/*
	if (a.n != b.n)
		throw std::exception("Incompatible points in Point::Distance");
	*/

	double quads = 0.0;
	for (int i = 0; i < n; ++i)
		quads += pow(a[i] - b[i], 2.0);

	return sqrt(quads);
}

Point Point::Average(const Point& a, const Point& b)
{
	/*
	int n = a.n;
	if (n != b.n)
		throw std::exception("Incompatible points in Point::Average");
	*/

	std::vector<double> mid_coords;
	mid_coords.resize(n);

	for (int i = 0; i < n; ++i)
		mid_coords[i] = (a.coords[i]*a.weight + b.coords[i]*b.weight) / (a.weight + b.weight);

	return Point(mid_coords, a.weight + b.weight);
}

void Point::flush(std::ofstream& ofs) const
{
	for (int i = 0; i < n-1; ++i)
		ofs << coords[i] << ", ";
	ofs << coords[n - 1];
}

void Point::Init(int dimensions)
{
	Point::n = dimensions;
}
/*
int Point::dimensions() const
{
	return n;
}
*/
