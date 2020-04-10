#pragma once

#include "cluster.h"

template <class T>
class Branch : public Cluster<T>
{
	/* Поддеревья */
	Cluster<T> *t1, *t2;
public:
	Branch(Cluster<T>* a, Cluster<T>* b);

	std::list<T> tolist() const override;
	T mid() const override;
	int save(std::ofstream&) const override;

	~Branch();
};


template<class T>
inline Branch<T>::Branch(Cluster<T>* a, Cluster<T>* b)
{
	t1 = a;
	t2 = b;
}

template<class T>
inline std::list<T> Branch<T>::tolist() const
{
	std::list<T> l1, l2;
	l1 = t1->tolist();
	l2 = t2->tolist();
	l1.insert(l1.begin(), l2.begin(), l2.end());
	return l1;
}

template<class T>
inline T Branch<T>::mid() const
{
	return T::Average(tolist());
}

template<class T>
inline int Branch<T>::save(std::ofstream &) const
{
	return 0;
}

template<class T>
inline Branch<T>::~Branch()
{
	delete t1;
	delete t2;
}