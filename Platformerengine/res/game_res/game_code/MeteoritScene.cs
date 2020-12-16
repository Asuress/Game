using Platformerengine.res.code.graphic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Platformerengine.res.game_res.game_code {
    class MeteoritScene : Scene {
        private SpriteRepository resoures { get; set; } = SpriteRepository.getInstance();
        public MeteoritScene(Size winSize) : base(winSize) {

            canvas.Background = resoures.Sprites["cosmos_back3.jpg"];
            canvas.Height = 1080;
            canvas.Width = 1920;
            canvas.SnapsToDevicePixels = true;
            //AddMeteorit("1", new Point(50, 50), new Size(50, 50), new Vector2(3,0.5));
            //AddMeteorit("2", new Point(430 * 4.5, 100), new Size(50, 50), new Vector2(-10, 2));
            //AddMeteorit("3", new Point(50, 50), new Size(100, 100), new Vector2(2, 0.1));
            AddMeteorit("4", new Point(430 * 4.5, 50), new Size(50, 50), new Vector2(-3, 0));
            AddMeteorit("5", new Point(50, 50), new Size(50, 50), new Vector2(3.3, 0));
            //AddMeteorit("6", new Point(430 * 4.5, 100), new Size(50, 50), new Vector2(-5, 3));
            //AddMeteorit("7", new Point(50, 50), new Size(100, 100), new Vector2(3, 0.5));
            //AddMeteorit("8", new Point(40 * 4.5, 100), new Size(50, 50), new Vector2(-3, 2));

            AddPlayer("Player", new Point(150, 500), new Size(100, 100), new Vector2(0, 0));
            //AddPlayer("Player2", new Point(300, 500), new Size(100, 100), new Vector2(-1, 0));
            AddPlatform("Platform", new Point(150, 700), new Size(500, 100));
            AddPlatform("Platform2", new Point(680, 600), new Size(500, 100));
            //AddPlatform("Platform2", new Point(700, 600), new Size(500, 100));
        }

        public void AddMeteorit(string id, Point pos, Size size, Vector2 move) {
            Shape ellipse = new Ellipse();
            ellipse.Height = size.Height;
            ellipse.Width = size.Width;

            ellipse.Fill = resoures.Sprites["meteorit1.jpg"];
            GameObject meteorit = new GameObject(id, "Background", ellipse, pos, size);
            //meteorit.AddCollider(new BoxCollider(meteorit, this));
            meteorit.Move = move;
            IGameManager manager = new MeteoritScript();
            //manager.SetParent(meteorit);
            manager.StartPosition(meteorit.Transform.Position);
            manager.SetWindowSize(WindowSize);

            AddObjectOnScene(meteorit, manager);
        }

        protected override void OnCollisionEnter(Collider.ColliderEventArgs colliderArgs) {
            base.OnCollisionEnter(colliderArgs);

            if (colliderArgs.Collider.parent.Tag == "Background" && colliderArgs.collider2.parent.Tag == "Background") {
                //colliderArgs.Collider.parent.Shape.Fill = resoures.Sprites["Flash.jpg"];
                //objects.Remove(colliderArgs.Collider?.parent);
                objects[colliderArgs.Collider.parent].SetStatus("bump");
            }

            if (colliderArgs.Collider?.parent.Tag == "Player") {
                objects[colliderArgs.Collider?.parent].SetStatus("OnGround");
            }

            if (colliderArgs.Collider?.parent.Tag == "Platform") {
                colliderArgs.Collider.parent.Move.Y = 0;
            }
        }

        protected override void OnCollisionExit(Collider.ColliderEventArgs colliderArgs) {
            if (colliderArgs.Collider?.parent.Tag == "Player") {
                objects[colliderArgs.Collider?.parent].SetStatus("NotOnGround");
            }
        }

        protected override void OnCollisionStay(Collider.ColliderEventArgs colliderArgs) {
            if (colliderArgs.Collider?.parent.Tag == "Player") {
                objects[colliderArgs.Collider?.parent].SetStatus("OnGround");
            }
        }

        public void AddPlayer(string id, Point pos, Size size, Vector2 move) {
            Shape shape = new Rectangle();
            shape.Height = size.Height;
            shape.Width = size.Width;
            shape.Fill = resoures.Sprites["Player.jpg"];
            GameObject player = new Player(id, "Player", shape, pos, size);
            player.Move = move;
            IGameManager manager = new ControllerScript();
            //manager.SetParent(player);
            AddObjectOnScene(player, manager);
        }

        public void AddPlatform(string id, Point pos, Size size) {
            Shape shape = new Rectangle();
            shape.Height = size.Height;
            shape.Width = size.Width;
            shape.Fill = resoures.Sprites["cosmos_back2.jpg"];
            GameObject platform = new GameObject(id, "Platform", shape, pos, size);
            AddObjectOnScene(platform);
        }
    }
}