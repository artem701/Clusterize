﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

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
        }

        private void fromstream(System.IO.StreamReader sr)
        {
            string coordstr = "";
            while (sr.Peek() != ')')
                coordstr += (char)sr.Read();
            coords = coordstr.Split(',').Select(coord => double.Parse(coord, CultureInfo.InvariantCulture)).ToArray();
        }

        public static Point Read(System.IO.StreamReader sr)
        {
            Point p = new Point();
            p.fromstream(sr);
            return p;
        }
    }
}
