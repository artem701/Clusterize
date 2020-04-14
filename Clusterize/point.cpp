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

Point Point::Average(const Point& a, int weight_a, const Point& b, int weight_b)
{
	int n = a.n;
	if (n != b.n)
		throw new std::exception("Incompatible points in Point::Average");

	std::vector<double> mid_coords;
	mid_coords.resize(n);

	for (int i = 0; i < n; ++i)
		mid_coords[i] = (a.coords[i]*weight_a + b.coords[i]*weight_b) / (weight_a + weight_b);

	return Point(mid_coords);
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
