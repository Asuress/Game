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

<<<<<<< Updated upstream
        public Canvas Canvas { get; set; }

        public Scene(LinkedList<GameObject> obj, LinkedList<IGameManager> manage) {
            ListOfObj = obj;
            Managers = manage;

            
=======
        public Canvas canvas { get; set; }
        public Size WindowSize { get; set; }

        public Scene(LinkedList<GameObject> obj, LinkedList<IGameManager> manage, Size winSize) : base() {
            WindowSize = winSize;
            ListOfObj = obj;
            Managers = manage;
            canvas = new Canvas();
            canvas.MinHeight = 1080;
            canvas.MinWidth = 1920;
            canvas.Height = 1920;
            canvas.Width = 1080;
            canvas.Background = Brushes.Black;
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
        public Scene() {
            ListOfObj = new LinkedList<GameObject>();
            Managers = new LinkedList<IGameManager>();
=======
        public Scene(Size winSize) : base() {
            WindowSize = winSize;
            ListOfObj = new LinkedList<GameObject>();
            Managers = new LinkedList<IGameManager>();
            canvas = new Canvas();
            canvas.MinHeight = 100;
            canvas.MinWidth = 50;
            canvas.Height = winSize.Height;
            canvas.Width = winSize.Width;

            canvas.Background = Brushes.Black;
            foreach (GameObject i in ListOfObj) {
                if (!canvas.Children.Contains(i.Shape)) {
                    canvas.Children.Add(i.Shape);
                    Canvas.SetLeft(i.Shape, i.Transform.Position.X);
                    Canvas.SetTop(i.Shape, i.Transform.Position.Y);                   
                } else {
                    Canvas.SetLeft(i.Shape, i.Transform.Position.X);
                    Canvas.SetTop(i.Shape, i.Transform.Position.Y);
                }
            }
>>>>>>> Stashed changes
        }

        public void AddObjectOnScene(GameObject obj, IGameManager manager = null) {
            ListOfObj.AddLast(obj);
            Managers.AddLast(manager);
            manager?.Update();
        }

        protected override void EarlyUpdate() {
<<<<<<< Updated upstream
            
        }

        protected override void LateUpdate() {

=======
            foreach (var i in Managers) {
                i.Update();
            }
            foreach (GameObject i in ListOfObj) {
                if (i.Shape != null) {
                    if (!canvas.Children.Contains(i.Shape)) {
                        canvas.Children.Add(i.Shape);
                        
                        Canvas.SetLeft(i.Shape, i.Transform.Position.X);
                        Canvas.SetTop(i.Shape, i.Transform.Position.Y);
                    } else {
                        Canvas.SetLeft(i.Shape, i.Transform.Position.X);
                        Canvas.SetTop(i.Shape, i.Transform.Position.Y);                       
                    }
                }
            }
           
        }

        protected override void LateUpdate() {
            //ListOfObj.First.Value.Transform.Rotate(ListOfObj.First.Value.Transform.Position.X++);
>>>>>>> Stashed changes
        }

        protected override void Update() {

        }
    }
}
