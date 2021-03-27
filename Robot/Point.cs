using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    public class Point
    {
        public Point ParentPoint;
        public int X;
        public int Y;
        public int F;
        public int G;
        public int H;
        public Point(int a, int b)
        {
            X = a;
            Y = b;
        }
    }
}
