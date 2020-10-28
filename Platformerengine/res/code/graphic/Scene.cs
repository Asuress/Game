using Platformerengine.res.code.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Platformerengine.res.code.graphic {
    class Scene : GameEnvironment {
        public LinkedList<GameObject> ListOfObj { get; }
        public LinkedList<IGameManager> Managers { get; }

        public Canvas Canvas { get; set; }

        public Scene(LinkedList<GameObject> obj, LinkedList<IGameManager> manage) {
            ListOfObj = obj;
            Managers = manage;

            
            foreach (GameObject i in ListOfObj) {
                if (!Canvas.Children.Contains(i.Shape)) {
                    Canvas.Children.Add(i.Shape);
                    Canvas.SetLeft(i.Shape, i.Transform.Position.X);
                    Canvas.SetTop(i.Shape, i.Transform.Position.Y);
                } else {
                    Canvas.SetLeft(i.Shape, i.Transform.Position.X);
                    Canvas.SetTop(i.Shape, i.Transform.Position.Y);
                }              
            }        
        }

        public Scene() {
            ListOfObj = new LinkedList<GameObject>();
            Managers = new LinkedList<IGameManager>();
        }

        public void AddObjectOnScene(GameObject obj, IGameManager manager = null) {
            ListOfObj.AddLast(obj);
            Managers.AddLast(manager);
        }

        protected override void EarlyUpdate() {
            
        }

        protected override void LateUpdate() {

        }

        protected override void Update() {

        }
    }
}
