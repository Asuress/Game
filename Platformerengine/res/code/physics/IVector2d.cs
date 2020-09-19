using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformerengine.res.code.logic {
    interface IVector2d {
        IVector2d VectorAddition(Vector2d vec2);
        IVector2d MultiplyVector(Vector2d vec2);
    }
}
