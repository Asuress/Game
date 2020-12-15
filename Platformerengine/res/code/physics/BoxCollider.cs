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
            //Parent = parent;
            Size = parent.Transform.Size;
            _Scene = scene;
        }
        public BoxCollider(GameObject parent, Scene scene, Size size) : base(parent)
        {
            Size = size;
            _Scene = scene;
        }

        public Size Size { get; set; }

        bool IsStay = false;
        Scene _Scene;

        protected override void EarlyUpdate()
        {
            LinkedList<GameObject> intersectsWith = new LinkedList<GameObject>();
            double penetrationDepth = 0;
            Vector2 normal = new Vector2();
            foreach (var go in _Scene.ListOfObj)
            {
                if (IntersectWith(go, ref normal, ref penetrationDepth) && go != parent)
                {
                    intersectsWith.AddLast(go);
                    foreach (var intersect in intersectsWith)
                    {
                        if (IsStay && intersect == go)
                        {
                            InvokeOnCollisionStay(go.Collider, parent.Collider, penetrationDepth, normal);
                        }
                        else
                        {
                            IsStay = true;
                            InvokeOnCollisionEnter(go.Collider, parent.Collider, penetrationDepth, normal);
                        }
                    }
                }
                else if (!IntersectWith(go, ref normal, ref penetrationDepth) && go != parent)
                {
                    foreach (var intersect in intersectsWith)
                    {
                        if (IsStay && intersect == go)
                        {
                            IsStay = false;
                            intersectsWith.Remove(intersect);
                            InvokeOnCollisionExit(go.Collider, parent.Collider, penetrationDepth, normal);
                        }
                    }
                }
            }
        }

        private bool IntersectWith(GameObject gameObject, ref Vector2 normal, ref double penetrationDepth)
        {
            var lengthX = Math.Abs(parent.Transform.Position.X - gameObject.Transform.Position.X);
            var lengthY = Math.Abs(parent.Transform.Position.Y - gameObject.Transform.Position.Y);

            var summHalfWidth = gameObject.Transform.Size.Width * 0.5 + parent.Transform.Size.Width * 0.5;
            var summHalfHeight = gameObject.Transform.Size.Height * 0.5 + parent.Transform.Size.Height * 0.5;

            var gapX = lengthX - summHalfWidth;
            var gapY = lengthY - summHalfHeight;

            if (gapX <= 0 && gapY <= 0)
            {
                penetrationDepth = Math.Max(gapX, gapY);

                //north
                if (VectorIntersect(parent.Transform.ObjectCenter, gameObject.Transform.ObjectCenter, parent.Transform.Position, parent.Transform.Position + new Point(parent.Transform.Size.Width)))
                {
                    penetrationDepth = gapY;
                    normal = new Vector2(0, -1);
                }
                //east
                else if (VectorIntersect(parent.Transform.ObjectCenter, gameObject.Transform.ObjectCenter, parent.Transform.Position + new Point(parent.Transform.Size.Width), parent.Transform.Position + new Point(parent.Transform.Size.Width, parent.Transform.Size.Height)))
                {
                    penetrationDepth = gapX;
                    normal = new Vector2(1, 0);
                }
                //south
                else if (VectorIntersect(parent.Transform.ObjectCenter, gameObject.Transform.ObjectCenter, parent.Transform.Position + new Point(parent.Transform.Size.Width, parent.Transform.Size.Height), parent.Transform.Position + new Point(0, parent.Transform.Size.Height)))
                {
                    penetrationDepth = gapY;
                    normal = new Vector2(0, 1);
                }
                //west
                else if (VectorIntersect(parent.Transform.ObjectCenter, gameObject.Transform.ObjectCenter, parent.Transform.Position + new Point(0, parent.Transform.Size.Height), parent.Transform.Position))
                {
                    penetrationDepth = gapX;
                    normal = new Vector2(-1, 0);
                }
                return true;
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
