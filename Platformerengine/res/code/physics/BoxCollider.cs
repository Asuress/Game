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
            foreach (var go in _Scene.ListOfObj)
            {
                Sides side;
                if (IntersectWith(go, out side) && go != parent)
                {
                    intersectsWith.AddLast(go);
                    foreach (var intersect in intersectsWith)
                    {
                        if (IsStay && intersect == go)
                        {
                            InvokeOnCollisionStay(go.Collider, side);
                        }
                        else
                        {
                            IsStay = true;
                            InvokeOnCollisionEnter(go.Collider, side);
                        }
                    }
                }
                else if (!IntersectWith(go, out side) && go != parent)
                {
                    foreach (var intersect in intersectsWith)
                    {
                        if (IsStay && intersect == go)
                        {
                            IsStay = false;
                            InvokeOnCollisionExit(go.Collider, side);
                        }
                    }
                }
            }
        }

        private bool IntersectWith(GameObject gameObject, out Sides side)
        {
            if (Math.Abs(parent.Transform.Position.X - gameObject.Transform.Position.X) <= (parent.Transform.Size.Width + gameObject.Transform.Size.Width) / 2 &&
               Math.Abs(parent.Transform.Position.Y - gameObject.Transform.Position.Y) <= (parent.Transform.Size.Height + gameObject.Transform.Size.Height) / 2)
            {
                side = default;
                if (parent.Transform.Position.X - gameObject.Transform.Position.X >= 0)
                    side = Sides.West;
                else if (parent.Transform.Position.X - gameObject.Transform.Position.X <= 0)
                    side = Sides.East;
                else if (parent.Transform.Position.Y - gameObject.Transform.Position.Y > 0)
                    side = Sides.North;
                else if (parent.Transform.Position.Y - gameObject.Transform.Position.Y > 0)
                    side = Sides.South;
                return true;
            }
            side = default;
            return false;
        }
    }

}
