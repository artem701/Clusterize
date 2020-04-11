
#include "point.h"
#include "cluster.h"

#include <iostream>
#include <fstream>
#include <vector>
#include <list>

using namespace std;

int main(int argc, char* argv[])
{
	ifstream ifs;

	if (argc > 1)
		ifs = ifstream(argv[1]);
	else
		ifs = ifstream("in.txt");

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
	ifs.close();
	Cluster<Point>* c = Cluster<Point>::clusterize(l);
	c->save((argc>2)?argv[2]:"out.txt");
	delete c;

	while (1);

	return 0;
}