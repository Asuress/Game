﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;

namespace Platformerengine.res.code.logic
{
    class Vector2
    {
        public Vector2() 
            : this(0,0)
        {
            
        }
        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; private set; }
        public double Y{ get; private set; }
        public double Length { 
            get 
            {
                if (Length == 0)
                    Length = Math.Sqrt(X * X + Y * Y);
                return Length;
            }
            private set
            {
                Length = value;
            }
        }

        public void Normalize()
        {
            X /= Length;
            Y /= Length;
        }
        public Vector2 GetNormalVector()
        {
            return default;
        }
        public static double ScalarMul(Vector2 v1, Vector2 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }
        public override bool Equals(object o)
        {
            if(o is Vector2)
            {
                return Equals(this, o);
            }
            return false;
        }
        public static bool Equals(Vector2 v1, Vector2 v2)
        {
            if (v1.X == v2.X && v1.Y == v2.Y)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static Vector2 operator +(Vector2 v) => v;
        public static Vector2 operator -(Vector2 v) => new Vector2(-v.X, -v.Y);
        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
        }
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
        }
        public static Vector2 operator *(Vector2 v1, double scalar)
        {
            return new Vector2(v1.X * scalar, v1.Y * scalar);
        }
        public static Vector2 operator /(Vector2 v1, double scalar)
        {
            return new Vector2(v1.X / scalar, v1.Y / scalar);
        }
        public static bool operator !=(Vector2 v1, Vector2 v2) => !(v1.X == v2.X && v1.Y == v2.Y);
        public static bool operator ==(Vector2 v1, Vector2 v2) => (v1.X == v2.X && v1.Y == v2.Y);
    }
}
