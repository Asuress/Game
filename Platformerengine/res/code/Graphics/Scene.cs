using Platformerengine.res.code.logic;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Platformerengine.res.code.Graphics
{
    public class Scene : Canvas
    {
        Scene()
        {
            Objects = new LinkedList<GameObject>();
        }

        public LinkedList<GameObject> Objects { get; }

        public void AddGameObject(GameObject go)
        {
            Objects.AddLast(go);
            //Canvas.Sets
            Children.Add(go.Shape);
        }
        public bool Contains(GameObject go)
        {
            foreach (var gameObject in Objects)
            {
                if (gameObject == go)
                    return true;
            }
            return false;
        }
    }
}
