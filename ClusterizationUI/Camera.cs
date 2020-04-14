using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusterizationUI
{
    class Camera
    {
        public double bottom, left, size;

        public Camera(double _size, double _left = 0, double _bottom = 0)
        {
            size = _size;
            bottom = _bottom;
            left = _left;
        }
    }
}
