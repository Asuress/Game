using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformerengine.res.code.logic {
    class Vector2d : IVector2d {
        private int dX { get; set; }
        private int dY { get; set;  }
        public Vector2d(int _dx, int _dy) {
            dX = _dx;
            dY = _dy;
        }

        public IVector2d VectorAddition(Vector2d vec2) {
            throw new NotImplementedException();
        }

        public IVector2d MultiplyVector(Vector2d vec2) {
            dX += vec2.dX;
            dY += vec2.dY;
            return this;
        }
    }
}
