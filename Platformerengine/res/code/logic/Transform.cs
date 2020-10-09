using System.Windows.Media;
using System.Windows.Shapes;

namespace Platformerengine.res.code.logic
{
    public class Transform : IComponent
    {
        private Point currentPoint { get; set; }
        private Shape currentShape { get; set; }

        public Transform(Point anyPoint, Shape shape)
        {
            currentPoint = anyPoint;
            currentShape = shape;
        }

        public void Turn(double degree)
        {
            currentShape.RenderTransform =  new RotateTransform(degree);   
        }
        

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