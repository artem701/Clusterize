using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusterizationUI
{
    abstract class Cluster
    {
        private int _count = 0;
        
        public int Count { get => _count; }

        public abstract List<Point> toList();

        public abstract int dimensions();

        public static Cluster Load(string filename)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(filename);
            return Load(sr);
        }

        public static Cluster Load(System.IO.StreamReader sr)
        {
            if (sr.EndOfStream)
                throw new Exception("Файл для чтения пуст");

            Cluster cluster;
            int c;
            switch (c = sr.Read())
            {
                case '(':
                    cluster = new Leave(Point.Read(sr));
                    cluster._count = 1;
                    sr.Read(); // ')'
                    break;
                case '{':
                    cluster = new Branch(Load(sr), Load(sr));
                    cluster._count = ((Branch)cluster).left.Count + ((Branch)cluster).right.Count;
                    sr.Read(); // '}'
                    break;
                default:
                    throw new Exception("Встречен неожиданный символ при чтении кластера из файла: '" + 
                        (char)c + "' (код: " + c.ToString() + ")");
            }
            return cluster;
        }
    }
}
