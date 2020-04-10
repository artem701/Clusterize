#pragma once

template<typename T>
struct SortedPair
{
public:
	T val[2];

	SortedPair(const T& v1, const T& v2)
	{
		if (v1 < v2)
			val = { v1, v2 };
		else
			val = { v2, v1 };
	}

	bool operator <(const SortedPair<T>& sp)
	{
		if (val[0] < sp.val[0])
			return true;
		if (val[0] > sp.val[0])
			return false;
		
		return val[1] < sp.val[1];
	}
};