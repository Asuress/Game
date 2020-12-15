using Platformerengine.res.code.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformerengine.res.code.physics {
    public abstract class Collider : GameEnvironment
    {
        public class ColliderEventArgs
        {
            public ColliderEventArgs(Collider collider1, Collider collider2, double penetrationDepth, Vector2 normal)
            {
                Collider = collider1;
                this.collider2 = collider2;
                this.penetrationDepth = penetrationDepth;
                this.normal = normal;
            }
            public Collider Collider { get; }
            public Collider collider2 { get; }
            public double penetrationDepth { get; }
            public Vector2 normal { get; }
        }

        public delegate void ColliderEventHandler(ColliderEventArgs colliderArgs);

        public virtual event ColliderEventHandler OnCollisionEnter = delegate { };
        public virtual event ColliderEventHandler OnCollisionExit = delegate { };
        public virtual event ColliderEventHandler OnCollisionStay = delegate { };

        protected Collider(GameObject parent)
        {
            Start();
            this.parent = parent;
        }

        public GameObject parent { get; }

        protected void InvokeOnCollisionEnter(Collider collider1, Collider collider2, double penetrationDepth, Vector2 normal)
        {
            OnCollisionEnter(new ColliderEventArgs(collider1, collider2, penetrationDepth, normal));
        }
        protected void InvokeOnCollisionStay(Collider collider1, Collider collider2, double penetrationDepth, Vector2 normal)
        {
            OnCollisionStay(new ColliderEventArgs(collider1, collider2, penetrationDepth, normal));
        }
        protected void InvokeOnCollisionExit(Collider collider1, Collider collider2, double penetrationDepth, Vector2 normal)
        {
            OnCollisionExit(new ColliderEventArgs(collider1, collider2, penetrationDepth, normal));
        }
    }
}
