using Platformerengine.res.code.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformerengine.res.code.physics {
    class Collider : Physics {
        private int Size { get; set; }
        private Point Coord { get; set; }
        public Collider(int _size, Point _p) {
            Size = _size;
            Coord = new Point(_p);
        }
        public void UpdateCoord(Point _coord) {
            Coord = _coord;
        }
    }
}
