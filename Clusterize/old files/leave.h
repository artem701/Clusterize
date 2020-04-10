#pragma once

#include "cluster.h"

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


template<class T>
inline Leave<T>::Leave(const T & val)
{
	this->val = val;
}

template<class T>
inline std::list<T> Leave<T>::tolist() const
{
	std::list<T> l;
	l.push_back(val);
	return l;
}

template<class T>
inline T Leave<T>::mid() const
{
	return val;
}

template<class T>
inline int Leave<T>::save(std::ofstream &) const
{
	return 0;
}
