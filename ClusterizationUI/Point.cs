using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusterizationUI
{
    class Point
    {
        public Point (params double[] coords)
        {
            this.coords = coords;
        }

        private double[] coords;

        public int n { get => coords.Length; }

        public double this[int index]
        {
            get => coords[index];
            //private set => coords[index] = value;
        }

        private void fromstream(System.IO.StreamReader sr/*, int dimensions*/)
        {
            //coords = new double[dimensions];
            string coordstr = "";
            while (sr.Peek() != ')')
                coordstr += (char)sr.Read();
            coords = coordstr.Split(new string[]{", "}, StringSplitOptions.RemoveEmptyEntries).Select(coord => double.Parse(coord)).ToArray();
        }

        public static Point Read(System.IO.StreamReader sr)
        {
            Point p = new Point();
            p.fromstream(sr);
            return p;
        }
    }
}
