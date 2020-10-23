using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Platformerengine.res.code.logic
{
    public class Transform : IComponent
    {
        public Point Point {
            get
            {
                return _Point;
            }

            set
            {
                _Point = value;
                PointChange(this,_Point);

            }}
        private Point _Point;
        private GameObject Parent {get;}
        
        public Size  Size {
            get
            {
                return _Size;
            }
            set
            {
                _Size = value;
                SizeChange(this, _Size);
            }
            
        }
        private Size _Size;

        public RotateTransform RotateTransform { get; set; }

        public Transform(Point anyPoint, Shape anyShape,Size anySize, GameObject parent)

        {
            Parent = parent;
            Point = anyPoint;
            Size = anySize;
        }

        public void Rotate(double degree)
        {
            RotateTransform = new RotateTransform(degree);
            Parent.Shape.RenderTransform = RotateTransform;
            RotateChange(this,RotateTransform);

        }
        public void ChangePoint(Point anyPoint)
        {
            Point = anyPoint;
        }
        public delegate void RotateHandler(Transform This, RotateTransform any);

        public delegate void SizeChangeHadler(Transform This, Size s);

        public delegate void PointChangeHandler(Transform This, Point p);

       
        
        public event RotateHandler RotateChange = delegate { };
        public event SizeChangeHadler SizeChange = delegate{  };
        public event PointChangeHandler PointChange = delegate{  };
        
        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}