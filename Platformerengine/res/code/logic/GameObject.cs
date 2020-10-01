using Platformerengine.res.code.physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Platformerengine.res.code.logic {
    class GameObject
    {
        public GameObject(int _x, int _y) {
            Components = new LinkedList<IComponent>();
            Position = new Point(_x, _y);
        }
        private Point Position { get; set; }
        private LinkedList<IComponent> Components;

        public string Tag { get; set; }

        public T GetComponent<T>()
        {
            foreach (var component in Components)
            {
                if (component is T)
                    return (T)component;
            }
            return default;
        }
        
        public void AddComponent(in IComponent newComponent) {
            Components.AddLast(newComponent);
        }
    }
}