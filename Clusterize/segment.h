#pragma once

// Класс отрезка, хранит две точки типа T и расстояние между ними
template <typename T>
struct Segment
{
public:
	T first, second;
	double distance;

	Segment(T _first, T _second, double _distance)
		: first(_first), second(_second), distance(_distance)
	{

	}

	bool operator <(const Segment<T>& seg) const
	{
		return distance < seg.distance;
	}
};