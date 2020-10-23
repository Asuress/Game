
namespace Platformerengine.res.code.logic {
 public class Point
    {
        private double X { get; set; }
        private double Y { get; set; }

        public Point(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
        }

        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
        }
        public override bool Equals(object o)
        {
            if (o is Point)
            {
                return Equals(this, o);
            }
            return false;
        }
        public static bool Equals(Point p1, Point p2)
        {
            if (p1.X == p2.X && p1.Y == p2.Y)
            {
                return true;
            }
            return false;
        }
        public Vector2 Subtract(Point end)
        {
            return new Vector2(end.X - this.X, end.Y - this.Y);
        }
        public void Move(double _x, double _y)
        {
            X += _x;
            Y += _y;

        }
        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator !=(Point p1, Point p2) => !(p1.X == p1.X && p1.Y == p2.Y);
        public static bool operator ==(Point p1, Point p2) => (p1.X == p2.X && p1.Y == p2.Y);
    }
}


