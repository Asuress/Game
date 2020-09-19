using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformerengine.res.code.logic {
    class Point {
        private int X { get; }
        private int Y { get; }
        public Point(int _x, int _y) {
            X = _x;
            Y = _y; 
        }
        public Point(Point _p) {
            X = _p.X;
            Y = _p.Y;
        }
    }
}
