
#include "cluster.h"

#include "point.h"

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

int main(void)
{
	Cluster<Point>* c = Cluster<Point>::clusterize(std::list<Point>());
	return 0;
}