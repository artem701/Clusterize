using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusterizationUI
{
    abstract class Cluster
    {
        public int Count { get => toList().Count; }

        public abstract List<Point> toList();

        public static Cluster Load(string filename)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(filename);
            return Load(sr);
        }

        public static Cluster Load(System.IO.StreamReader sr)
        {
            Cluster cluster;
            int c;
            switch (c = sr.Read())
            {
                case '(':
                    cluster = new Leave(Point.Read(sr));
                    sr.Read(); // ')'
                    break;
                case '{':
                    cluster = new Branch(Load(sr), Load(sr));
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
