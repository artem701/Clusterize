
#include "point.h"
#include "cluster.h"

#include <iostream>
#include <fstream>
#include <vector>
#include <list>
#include <time.h>

using namespace std;

int main(int argc, char* argv[])
{
	setlocale(0, "RUS");
	cout << "Запущена подпрограмма кластеризации...\n";
	time_t   start, finish;
	double elapsed_time;
	time(&start);

	ifstream ifs;


	if (argc > 1)
		ifs = ifstream(argv[1]);
	else
		ifs = ifstream("in.txt");

	int n; ifs >> n;
	list<Point> l;

	cout << "Чтение точек из файла...\n";
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
	cout << "Кластеризация...\n";
	Cluster<Point>* c = Cluster<Point>::clusterize(l);
	cout << "Сохранение результатов...\n";
	c->save((argc>2)?argv[2]:"out.txt");
	delete c;

	time(&finish);

	elapsed_time = difftime(finish, start);

	ofstream log = ofstream(/*(argc>3)?argv[3]:*/"log.txt");
	log << "Elements count: " << l.size() << "\n"
		 << "One element size: " << sizeof(l.front()) << "\n"
		 << "Calculating time: " << elapsed_time << "s\n";

	log.close();

	return 0;
}