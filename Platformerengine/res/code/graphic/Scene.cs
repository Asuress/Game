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

        public Dictionary<GameObject, IGameManager> objects { get; }

        public Canvas canvas { get; set; }
        public Size WindowSize { get; set; }

        public Scene(Dictionary<GameObject, IGameManager> objs, Size winSize) : base() {
            WindowSize = winSize;
            objects = objs;
            canvas = new Canvas();
            canvas.MinHeight = 1080;
            canvas.MinWidth = 1920;
            canvas.Height = 1920;
            canvas.Width = 1080;
            canvas.Background = Brushes.Black;

            foreach (var i in objects) {
                if (!canvas.Children.Contains(i.Key.Shape)) {
                    canvas.Children.Add(i.Key.Shape);
                    Canvas.SetLeft(i.Key.Shape, i.Key.Transform.Position.X);
                    Canvas.SetTop(i.Key.Shape, i.Key.Transform.Position.Y);
                } else {
                    Canvas.SetLeft(i.Key.Shape, i.Key.Transform.Position.X);
                    Canvas.SetTop(i.Key.Shape, i.Key.Transform.Position.Y);
                }
            }

            foreach (var i in objects) {
                if (i.Key.Collider != null) {
                    i.Key.Collider.OnCollisionEnter += OnCollisionEnter;
                    i.Key.Collider.OnCollisionExit += OnCollisionExit;
                    i.Key.Collider.OnCollisionStay += OnCollisionStay;
                }
            }

        }

        protected virtual void OnCollisionEnter(ColliderEventArgs colliderArgs) {

        }

        protected virtual void OnCollisionExit(ColliderEventArgs colliderArgs) {

        }

        protected virtual void OnCollisionStay(ColliderEventArgs colliderArgs) {

        }

        public Scene(Size winSize) {
            WindowSize = winSize;
            objects = new Dictionary<GameObject, IGameManager>();

            canvas = new Canvas();
            canvas.MinHeight = 100;
            canvas.MinWidth = 50;
            canvas.Height = winSize.Height;
            canvas.Width = winSize.Width;

            canvas.Background = Brushes.Black;
            foreach (var i in objects) {
                if (!canvas.Children.Contains(i.Key.Shape)) {
                    canvas.Children.Add(i.Key.Shape);
                    Canvas.SetLeft(i.Key.Shape, i.Key.Transform.Position.X);
                    Canvas.SetTop(i.Key.Shape, i.Key.Transform.Position.Y);
                } else {
                    Canvas.SetLeft(i.Key.Shape, i.Key.Transform.Position.X);
                    Canvas.SetTop(i.Key.Shape, i.Key.Transform.Position.Y);
                }
            }
        }

        public void AddObjectOnScene(GameObject obj, IGameManager manager = null) {
            objects.Add(obj, manager);
            obj.AddCollider(new BoxCollider(obj, this));
            obj.Collider.OnCollisionEnter += OnCollisionEnter;
            obj.Collider.OnCollisionStay += OnCollisionStay;
            obj.Collider.OnCollisionExit += OnCollisionExit;
            manager?.SetParent(obj);
            manager?.Update();
        }

        protected override void EarlyUpdate() {

        }

        protected override void LateUpdate() {
            foreach (var i in objects) {
                i.Value?.Update();
            }

            foreach (var i in objects) {
                if (i.Key.Shape != null) {
                    if (!canvas.Children.Contains(i.Key.Shape)) {
                        canvas.Children.Add(i.Key.Shape);
                        i.Key.Transform.Position = new Point(i.Key.Transform.Position.X + i.Key.Move.X,
                            i.Key.Transform.Position.Y + i.Key.Move.Y);
                    } else {
                        i.Key.Transform.Position = new Point(i.Key.Transform.Position.X + i.Key.Move.X,
                            i.Key.Transform.Position.Y + i.Key.Move.Y);
                    }

                }
            }
        }


        protected override void Update() {

        }
    }
}