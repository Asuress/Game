using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Platformerengine.res.code.logic
{
    public class GameObject
    {
        public GameObject(string _id, string _Tag, Shape shape, Point Point, Size anySize)
        {
            Shape = shape;
            Id = _id;
            Tag = _Tag;
            Transform = new Transform(Point, anySize, this);
            Transform.PositionChange += TransformOnPositionChange;
            Transform.SizeChange += TransformOnSizeChange;
            Transform.Position = Point;
            Transform.Size = anySize;
            Move = new Vector2();
        }

        private void TransformOnSizeChange(GameObject parent, Size s) {
            Shape.Width = s.Width;
            Shape.Height = s.Height;
        }
        public Vector2 Move { get; set; }

        private void TransformOnPositionChange(GameObject parent, Point p)
        {
            Canvas.SetLeft(Shape, p.X);
            Canvas.SetTop(Shape, p.Y);
        }

        public Transform Transform { get; set; }
        public string Id { get; }
        public Shape Shape { get; set; }
        public string Tag { get; set; }
    }
}
