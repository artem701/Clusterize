
#include "point.h"
#include "cluster.h"

#include <iostream>
#include <fstream>
#include <vector>
#include <list>

/*


class A {
public:
	static double Distance(const A&, const A&);
	static A Average(std::list<A>);
	void flush(std::ofstream&);
};


int main(int argc, char* argv[])
{
	
	Cluster<A>* c;
	Branch<A>* b = new Branch<A>(nullptr, nullptr);
	Leave<A>* l = new Leave<A>(A());

	c = b;
	A a = c->mid();

	c = l;
	a = c->mid();
}

double A::Distance(const A &, const A &)
{
	return 0.0;
}

A A::Average(std::list<A>)
{
	return A();
}

void A::flush(std::ofstream &)
{
}
*/

using namespace std;

int main(void)
{
	ifstream ifs = ifstream("in.txt");
	//ofstream ofs = ofstream("out.txt");

	int n; ifs >> n;
	list<Point> l;

	while (!ifs.eof())
	{
		vector<double> v;
		for (int i = 0; i < n; ++i)
		{
			double x;
			ifs >> x;
			v.push_back(x);
		}
		l.push_back(Point(v));
	}

	Cluster<Point>* c = Cluster<Point>::clusterize(l);
	c->save("out.txt");
	delete c;

	return 0;
}