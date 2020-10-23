
using System.Collections.Generic;
using System.Windows.Shapes;

namespace Platformerengine.res.code.logic {
    public class GameObject {
        public string id {get;}
        public GameObject(string _id, int _x, int _y, Shape shape) {
            Components = new LinkedList<IComponent>();
            Position = new Point(_x, _y);
            Shape = shape;
            id = _id;
        }
        public Point Position { get; set; }
        private LinkedList<IComponent> Components;
        public Shape Shape{ get; set; }

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