using Platformerengine.res.code.logic;
using Platformerengine.res.code.physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static Platformerengine.res.code.physics.Collider;

namespace Platformerengine.res.code.graphic {
    public class Scene : GameEnvironment {
        public LinkedList<GameObject> ListOfObj { get; }
        public LinkedList<IGameManager> Managers { get; }

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
            
            foreach (var i in ListOfObj) {
                if (i.Collider != null)
                    i.Collider.OnCollisionEnter += IntersectWith;
            }
            
        }

        public void IntersectWith(ColliderEventArgs colliderArgs) {
            if (colliderArgs.Collider?.parent.Tag == "Background") {
                ImageBrush img = new ImageBrush(
                    new BitmapImage(
                        new Uri("C:/development/projects/Game/Platformerengine/res/game_res/assets/Flash.jpg", UriKind.Absolute)
                    )
                );
                colliderArgs.Collider.parent.Shape.Fill = img;
                colliderArgs.Collider.parent.Move.X = 0;
            }
            
            if (colliderArgs.Collider?.parent.Tag == "Player") {
                colliderArgs.Collider.parent.Move.X = 0;

            }
        }

        public Scene(Size winSize) {
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
        }

        public void AddObjectOnScene(GameObject obj, IGameManager manager = null) {
            ListOfObj.AddLast(obj);
            Managers.AddLast(manager);
            manager?.Update();
            obj.AddCollider(new BoxCollider(obj, this));
            obj.Collider.OnCollisionEnter += IntersectWith;
        }

        protected override void EarlyUpdate() {
            
        }

        protected override void LateUpdate()
        {
            foreach (var i in Managers)
            {
                i?.Update();
            }

            foreach (GameObject i in ListOfObj)
            {
                if (i.Shape != null)
                {
                    if (!canvas.Children.Contains(i.Shape))
                    {
                        canvas.Children.Add(i.Shape);
                        i.Transform.Position = new Point(i.Transform.Position.X + i.Move.X,
                            i.Transform.Position.Y + i.Move.Y);
                    }
                    else
                    {
                        i.Transform.Position = new Point(i.Transform.Position.X + i.Move.X,
                            i.Transform.Position.Y + i.Move.Y);
                    }

                }
            }
        }


        protected override void Update() {

        }
    }
}
