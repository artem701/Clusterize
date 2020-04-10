#pragma once

template <class T>
class Cluster;
#include <list>


template <class T>
class Leave : public Cluster<T>
{
	T val;
public:
	Leave(const T&);

	std::list<T> tolist() const override;
	T mid() const override;
	int save(std::ofstream&) const override;
};

// РЕАЛИЗАЦИЯ

template<class T>
inline Leave<T>::Leave(const T & _val)
{
	val = _val;
}

template<class T>
inline std::list<T> Leave<T>::tolist() const
{
	return std::list<T>(1, val);
}

template<class T>
inline T Leave<T>::mid() const
{
	return val;
}
