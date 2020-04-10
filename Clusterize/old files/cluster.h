#pragma once

#include <list>
#include <iterator>
#include <stdio.h>

/*
	���������� � T

	unsigned double static T::Distance(const T&, const T&)
		�������� ���������� ����� ����� ���������

	T static T::Average(list<T>)
		����������� ������

	void T::flush(ofstream&)
		������ � ����
*/

template <class T>
class Cluster
{
public:
	Cluster(std::list<T>);

	int save(const char*) const;

protected:
	/* ��� ������ �� �������� */
	virtual int save(std::ofstream&) const = 0;

	/* ���������� ����� �������� */
	virtual T mid() const = 0;

	/* ���������� ������ ���� �������� �������� */
	virtual std::list<T> tolist() const = 0;
};