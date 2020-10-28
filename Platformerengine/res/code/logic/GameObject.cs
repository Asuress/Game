using System.Windows.Shapes;

namespace Platformerengine.res.code.logic {
    public class GameObject : GameEnvironment
    {
        public string id {get;}
        public GameObject(string _id, int _x, int _y, Shape shape)
        {
            Shape = shape;
        }
        public Shape Shape{ get; set; }
        public string Tag { get; set; }

    }
}