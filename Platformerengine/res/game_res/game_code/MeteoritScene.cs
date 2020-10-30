using Platformerengine.res.code.graphic;
using Platformerengine.res.code.logic;
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
        public MeteoritScene(Size winSize) : base(winSize) {
            ImageBrush img = new ImageBrush(
                new BitmapImage(
                    new Uri("C:/development/projects/Game/Platformerengine/res/game_res/assets/cosmos_back3.jpg", UriKind.Absolute)
                    )
                );
            canvas.Background = img;
            canvas.Height = 1080;
            canvas.Width = 1920;
            canvas.SnapsToDevicePixels = true;
            AddMeteorit("1", new Point(50, 50), new Size(50, 50), new Vector2(3, 0));
            AddMeteorit("2", new Point(430 * 4.5, 50), new Size(50, 50), new Vector2(-10, 0));
            //AddMeteorit("3", new Point(50, 50), new Size(100, 100), new Vector2(2, 0.1));
            //AddMeteorit("4", new Point(430 * 4.5, 100), new Size(50, 50), new Vector2(-3, 0.9));
            //AddMeteorit("5", new Point(50, 50), new Size(50, 50), new Vector2(1.3, 0.8));
            //AddMeteorit("6", new Point(430 * 4.5, 100), new Size(50, 50), new Vector2(-5, 3));
            //AddMeteorit("7", new Point(50, 50), new Size(100, 100), new Vector2(3, 0.5));
            //AddMeteorit("8", new Point(40 * 4.5, 100), new Size(50, 50), new Vector2(-3, 2));
            AddPlayer("Player", new Point(150, 600), new Size(100, 100));
            AddPlatform("Platform1", new Point(100, 700), new Size(30000, 600));
        }

        public void AddMeteorit(string id, Point pos, Size size, Vector2 move) {
            Shape ellipse = new Ellipse();
            ellipse.Height = size.Height;
            ellipse.Width = size.Width;
            ImageBrush img = new ImageBrush(
                new BitmapImage(
                    new Uri("C:/development/projects/Game/Platformerengine/res/game_res/assets/meteorit1.png", UriKind.Absolute)
                    )
                );
            ellipse.Fill = img;
            GameObject meteorit = new GameObject(id, "Background", ellipse, pos, size);
            meteorit.Move = move;
            IGameManager manager = new MeteoritScript();
            manager.SetParent(meteorit);
            manager.StartPosition(meteorit.Transform.Position);
            manager.SetWindowSize(WindowSize);
        
            AddObjectOnScene(meteorit, manager);
        }

        public void AddPlayer(string id, Point pos, Size size) {
            Shape shape = new Rectangle();
            shape.Height = size.Height;
            shape.Width = size.Width;
            ImageBrush img = new ImageBrush(
                new BitmapImage(
                    new Uri("C:/development/projects/Game/Platformerengine/res/game_res/assets/Player.png", UriKind.Absolute)
                    )
                );
            shape.Fill = img;
            GameObject player = new Player(id, "Player", shape, pos, size);
            player.Move = new Vector2(0, 0);
            IGameManager manager = new ControllerScript();
            manager.SetParent(player);
            AddObjectOnScene(player, manager);
        }

        public void AddPlatform(string id, Point pos, Size size) {
            Shape shape = new Rectangle();
            shape.Height = size.Height;
            shape.Width = size.Width;
            ImageBrush img = new ImageBrush(
                new BitmapImage(
                    new Uri("C:/development/projects/Game/Platformerengine/res/game_res/assets/cosmos_back2.jpg", UriKind.Absolute)
                    )
                );
            shape.Fill = img;
            GameObject platform = new GameObject(id, "Platform", shape, pos, size);
            AddObjectOnScene(platform);
        }
    }
}
