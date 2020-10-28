using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Platformerengine.res.code.logic {
    public class Transform : IComponent {
        public Point Position {
            get {
                return _Point;
            }

            set {
                _Point = value;
                PositionChange(Parent, _Point);
            }
        }
        private Point _Point;
        private GameObject Parent { get; }
        public Size Size {
            get {
                return _Size;
            }
            set {
                _Size = value;
                SizeChange(Parent, _Size);
            }

        }
        private Size _Size;
        public RotateTransform RotateTransform { get; set; }

        public Transform(Point anyPoint, Size anySize, GameObject parent) {
            Parent = parent;
            Position = anyPoint;
            Size = anySize;
        }

        public void Rotate(double degree) {
            RotateTransform = new RotateTransform(degree);
            Parent.Shape.RenderTransform = RotateTransform;
            RotateChange(Parent, RotateTransform);

        }
        public delegate void RotateHandler(GameObject parent, RotateTransform any);

        public delegate void SizeChangeHadler(GameObject parent, Size s);

        public delegate void PositionChangeHandler(GameObject parent, Point p);



        public event RotateHandler RotateChange = delegate { };
        public event SizeChangeHadler SizeChange = delegate { };
        public event PositionChangeHandler PositionChange = delegate { };

        public override string ToString() {
            return base.ToString();
        }

        public override bool Equals(object obj) {
            return base.Equals(obj);
        }


        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}