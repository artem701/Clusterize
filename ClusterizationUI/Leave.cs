using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusterizationUI
{
    class Leave : Cluster
    {
        private Point value;

        public Leave(Point val)
        {
            value = val;
        }

        public override List<Point> toList()
        {
            return new List<Point>() { value };
        }
    }
}
