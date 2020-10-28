======== Game_obj_draw
﻿
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Platformerengine.res.code.logic {
    public class GameObject {
        public GameObject(string _id,string _Tag, Shape shape,Point Point, Size anySize) {
            Shape = shape;
            Id = _id;
            Tag = _Tag;
            Transform = new Transform(Point,anySize,this);
        }
        public Transform Transform { get; set; }
        public string Id {get;}
        public Shape Shape{ get; set; }
        public string Tag { get; set; }
        protected void ChangePosithion(Point Posithion)
        {
            
            Canvas.SetLeft(Shape,Posithion.X);
            Canvas.SetRight(Shape,Posithion.Y);
            Transform.Point = Posithion;
            
            
           
            
        }
        protected void ChangeSize(Size Size)
        {
            
            Shape.Width = Size.Width;
            Shape.Height = Size.Height;
            Transform.Size = Size;
        }
    }
}
=======

