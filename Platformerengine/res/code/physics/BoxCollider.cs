using Platformerengine.res.code.graphic;
using Platformerengine.res.code.logic;
using System;
using System.Collections.Generic;

namespace Platformerengine.res.code.physics
{
    public class BoxCollider : Collider
    {

        public BoxCollider(GameObject parent, Scene scene) : base(parent)
        {
            Position = parent.Transform.Position;
            Size = parent.Transform.Size;
            _Scene = scene;
        }
        public BoxCollider(GameObject parent, Scene scene, Size size, Point position) : base(parent)
        {
            Position = position;
            Size = size;
            _Scene = scene;
        }

        public Point Position { get; set; }
        public Size Size { get; set; }

        bool IsStay = false;
        Scene _Scene;
        
        LinkedList<GameObject> intersectedWith = new LinkedList<GameObject>();

        protected override void EarlyUpdate()
        {
            //LinkedList<GameObject> intersectsWith = new LinkedList<GameObject>();
            LinkedList<GameObject> intersectWith = new LinkedList<GameObject>();
            foreach (var go in _Scene.objects.Keys)
            {
                double penetrationDepth = 0;
                Vector2 normal = new Vector2(0, 0);
                var isIntersect = IntersectWith(go, ref normal, ref penetrationDepth);
                if (isIntersect && go != parent)
                {
                    intersectWith.AddLast(go);
                    if (intersectedWith.Contains(go))
                    {
                        InvokeOnCollisionStay(go.Collider, parent.Collider, penetrationDepth, normal);
                    }
                    else
                    {
                        InvokeOnCollisionEnter(go.Collider, parent.Collider, penetrationDepth, normal);
                    }
                }
                else if(!isIntersect && go != parent && intersectedWith.Contains(go))
                {
                    InvokeOnCollisionExit(go.Collider, parent.Collider, penetrationDepth, normal);
                }
            }

            //foreach (var go in _Scene.objects.Keys)
            //{
            //    if (IntersectWith(go, ref normal, ref penetrationDepth) && go != parent)
            //    {
            //        intersectWith.AddLast(go);
            //        foreach (var intersect in intersectWith)
            //        {
            //            if (IsStay && intersect == go)
            //            {
            //                InvokeOnCollisionStay(go.Collider, parent.Collider, penetrationDepth, normal);
            //            }
            //            else
            //            {
            //                IsStay = true;
            //                InvokeOnCollisionEnter(go.Collider, parent.Collider, penetrationDepth, normal);
            //            }
            //        }
            //    }
            //    else if (!IntersectWith(go, ref normal, ref penetrationDepth) && go != parent)
            //    {
            //        if (IsStay && intersectedWith.Contains(go)) {
            //            IsStay = false;
            //            intersectWith.Remove(go);
            //            InvokeOnCollisionExit(go.Collider, parent.Collider, penetrationDepth, normal);
            //        }
            //    }
            //}
            intersectedWith = intersectWith;
        }

        private bool IntersectWith(GameObject gameObject, ref Vector2 normal, ref double penetrationDepth)
        {
            normal = new Vector2(0, 0);
            Vector2 n = new Vector2(parent.Transform.ObjectCenter.X - gameObject.Transform.ObjectCenter.X,
                parent.Transform.ObjectCenter.Y - gameObject.Transform.ObjectCenter.Y);
            var a_extentX = parent.Transform.Size.Width / 2;
            var b_extentX = gameObject.Transform.Size.Width / 2;

            var x_overlap = a_extentX + b_extentX - Math.Abs(n.X);

            if (x_overlap > 0)
            {
                var a_extentY = parent.Transform.Size.Height / 2;
                var b_extentY = gameObject.Transform.Size.Height / 2;

                var y_overlap = a_extentY + b_extentY - Math.Abs(n.Y);

                if (y_overlap > 0)
                {
                    if (x_overlap > y_overlap)
                    {
                        if (n.Y < 0)
                            normal = new Vector2(0, -1);
                        else
                            normal = new Vector2(0, 1);
                        penetrationDepth = x_overlap;
                        return true;
                    }
                    else
                    {
                        if (n.X < 0)
                            normal = new Vector2(-1, 0);
                        else
                            normal = new Vector2(1, 0);
                        penetrationDepth = y_overlap;
                        return true;
                    }
                }
            }
            return false;
        }
        private bool VectorIntersect(Point A, Point B, Point C, Point D)
        {
            Vector2 AC = new Vector2(C.X - A.X, C.Y - A.Y);
            Vector2 AD = new Vector2(D.X - A.X, D.Y - A.Y);

            Vector2 BC = new Vector2(C.X - B.X, C.Y - B.Y);
            Vector2 BD = new Vector2(D.X - B.X, D.Y - B.Y);

            int zCompSign1 = Math.Sign((BC.X * BD.Y) - (BC.Y * BD.X));
            int zCompSign2 = Math.Sign((AC.X * AD.Y) - (AC.Y * AD.X));

            if (zCompSign1 != zCompSign2 || zCompSign1 == 0 || zCompSign2 == 0)
                return true;

            return false;
        }
    }
}
