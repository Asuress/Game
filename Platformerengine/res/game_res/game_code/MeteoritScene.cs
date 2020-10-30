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
            AddMeteorit(new Point(50, 50), new Size(50, 50), new Vector2(3,0.5));
            AddMeteorit(new Point(430 * 4.5, 100), new Size(50, 50), new Vector2(-10, 2));
            AddMeteorit(new Point(50, 50), new Size(100, 100), new Vector2(2, 0.1));
            AddMeteorit(new Point(430 * 4.5, 100), new Size(50, 50), new Vector2(-3, 0.9));
            AddMeteorit(new Point(50, 50), new Size(50, 50), new Vector2(1.3, 0.8));
            AddMeteorit(new Point(430 * 4.5, 100), new Size(50, 50), new Vector2(-5, 3));
            AddMeteorit(new Point(50, 50), new Size(100, 100), new Vector2(3, 0.5));
            AddMeteorit(new Point(40 * 4.5, 100), new Size(50, 50), new Vector2(-3, 2));
            // AddObjectOnScene();
        }

        public void AddMeteorit(Point pos, Size size, Vector2 move) {
            Shape ellipse = new Ellipse();
            ellipse.Height = 50;
            ellipse.Width = 50;
            ImageBrush img = new ImageBrush(
                new BitmapImage(
                    new Uri("C:/development/projects/Game/Platformerengine/res/game_res/assets/meteorit1.png", UriKind.Absolute)
                    )
                );
            ellipse.Fill = img;
            GameObject meteorit = new GameObject("Background", "Meteorit", ellipse, pos, size);
            meteorit.Move = move;
            IGameManager manager = new MeteoritScript();
            manager.SetParent(meteorit);
            manager.StartPosition(meteorit.Transform.Position);
            manager.SetWindowSize(WindowSize);
        
            AddObjectOnScene(meteorit, manager);
        }
    }
}
