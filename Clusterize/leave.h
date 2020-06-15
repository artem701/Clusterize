#pragma once

#include <list>
#include <fstream>

template <class T>
class Cluster;


template <class T>
class Leave : public Cluster<T>
{
	T val;
public:
	Leave(const T&);

	T mid() const override;
	void save(std::ofstream&) const override;
};

// РЕАЛИЗАЦИЯ

template<class T>
inline Leave<T>::Leave(const T & _val) : val(_val)
{
}

template<class T>
inline T Leave<T>::mid() const
{
	return val;
}

template<class T>
inline void Leave<T>::save(std::ofstream & of) const
{
	of << "(";
	val.flush(of);
	of << ")";
}
