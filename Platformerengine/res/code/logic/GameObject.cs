using Platformerengine.res.code.physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace Platformerengine.res.code.logic {
    class GameObject {
        public string id {get;}
        public GameObject(string _id, int _x, int _y, Shape shape) {
            Components = new LinkedList<IComponent>();
            Position = new Point(_x, _y);
            Sprite = shape;
            id = _id;
        }
        public Point Position { get; set; }
        private LinkedList<IComponent> Components;
        public Shape Sprite { get; set; }

        public string Tag { get; set; }

        public T GetComponent<T>()
        {
            foreach (IComponent component in Components)
            {
                if (component.GetType() is T)
                    return (T)component;
            }
            return default;
        }
        
        public void AddComponent(in IComponent ph) {
            Components.AddLast(ph);
        }
    }
}