using Platformerengine.res.code.physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace Platformerengine.res.code.logic {
    public class GameObject {
        public GameObject(string tag, Shape shape) {
            Shape = shape;
            Tag = tag;
        }
        public Shape Shape{ get; set; }
        public string Tag { get; set; }

        
    }
}
