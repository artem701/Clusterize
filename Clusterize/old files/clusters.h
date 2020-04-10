#pragma once
#include <list>
#include <iterator>
#include <stdio.h>

/* 
	Требования к T

	double static T::Distance(const T&, const T&)
		Условное расстояние между двумя объектами

	T static T::Average(const list<T>)
		Усредненный объект

	void T::flush(ofstream&)
		Запись в файл
*/
/*
template <class T>
class Cluster
{
public:

	typedef typename std::list<typename Cluster<T>*>::iterator iterator;

	Cluster(std::list<T>);

	int save(const char*) const;

	// Возвращает центр кластера
	virtual T mid() const = 0;

	// Возвращает список всех объектов кластера
	virtual std::list<T> tolist() const = 0;

protected:

	// Для вызова из родителя
	virtual int save(std::ofstream&) const = 0;

	// Пустой конструктор для создания детей 
	Cluster();

};

template <class T>
class Branch : public Cluster<T>
{
	// Поддеревья
	Cluster<T> *t1, *t2;
	T average;
	std::list<T> l;
public:
	Branch(Cluster<T>* a, Cluster<T>* b);

	std::list<T> tolist() const override;
	T mid() const override;
	int save(std::ofstream&) const override;

	~Branch();
};

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


//		РЕАЛИЗАЦИЯ


//	Branch	
template<class T>
inline Branch<T>::Branch(Cluster<T>* a, Cluster<T>* b)
{
	t1 = a;
	t2 = b;

	std::list<T> l2;
	l = t1->tolist();
	l2 = t2->tolist();
	l.insert(l.begin(), l2.begin(), l2.end());

	average = T::Average(l);
}

template<class T>
inline std::list<T> Branch<T>::tolist() const
{
	return l;
}

template<class T>
inline T Branch<T>::mid() const
{
	return average;
}

template<class T>
inline int Branch<T>::save(std::ofstream &) const
{
	// СДЕЛАТЬ 
	return 0;
}

template<class T>
inline Branch<T>::~Branch()
{
	delete t1;
	delete t2;
}



//	Leave		

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
	// СДЕЛАТЬ 
	return 0;
}


//typedef typename std::list<T>::iterator iterator;

template<class T>
static inline bool sortPred(Cluster<T>* a, Cluster<T>* b)
{
	// Сортируем по x, если есть y, то он вторичный признак сортировки 
	return (a->mid()[0] < b->mid()[0]) || (a->mid().dimensions() < 2)?0:((a->mid()[0] == b->mid()[0]) && (a->mid()[1] < b->mid[1]));
}

template<class T>
static inline void closest(const std::list<Cluster<T>*>& l, typename Cluster<T>::iterator& a, typename Cluster<T>::iterator& b)
// God save us 
{
	l.sort()
}

template<class T>
inline Cluster<T>::Cluster(std::list<T>)
{
	// ГЛАВНАЯ ФУНКЦИЯ 
}

template<class T>
inline int Cluster<T>::save(const char *) const
{
	return 0;
}

template<class T>
inline Cluster<T>::Cluster()
{
}
*/