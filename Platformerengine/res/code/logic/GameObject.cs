using Platformerengine.res.code.physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Platformerengine.res.code.logic {
    class GameObject {
        public GameObject(int _x, int _y) {
            Vector = new Vector2d(0, 0);
            Components = new LinkedList<Physics>();
            Coord = new Point(_x, _y);
        }
        private Point Coord { get; set; }
        private IVector2d Vector { get; set; }
        private LinkedList<Physics> Components;

        public void AddComponent(Physics ph) {
            Components.AddLast(ph);
        }
    }
}
