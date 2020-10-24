
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Platformerengine.res.code.logic {
    public class GameObject {
        public string id {get;}
        
        public GameObject(string _id,string _Tag, Shape shape) {
            Components = new LinkedList<IComponent>();
            Shape = shape;
            id = _id;
            Tag = _Tag;
        }
        public Transform Transform { get; set; }

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

        protected void ChangePosithion(Point Posithion)
        {
            Transform.Point = Posithion;
            Canvas.SetLeft(Shape,Transform.Point.X);
            Canvas.SetRight(Shape,Transform.Point.Y);
            
            
           
            
        }
        protected void ChangeSize(Size Size)
        {
            Transform.Size = Size;
            Shape.Width = Transform.Size.Width;
            Shape.Height = Transform.Size.Height;
        }
    }
}