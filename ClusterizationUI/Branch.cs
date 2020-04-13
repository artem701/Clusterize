using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusterizationUI
{
    class Branch : Cluster
    {
        public Cluster left, right;

        public Branch(Cluster a, Cluster b)
        {
            left = a;
            right = b;
        }

        public override List<Point> toList()
        {
            return left.toList().Concat(right.toList()).ToList();
        }

        public override int dimensions() => left.dimensions();
    }
}
