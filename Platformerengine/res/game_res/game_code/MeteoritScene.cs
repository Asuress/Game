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
        public Label label { get; set; }
        public MeteoritScene(Size winSize) : base(winSize) {

            //canvas.Background = resoures.Sprites["cosmos_back3.jpg"];
            label = new Label();
            label.Height = 100;
            label.Width = 2100;
            label.Content = "Score: ";
            label.FontSize = 50;
            canvas.Children.Add(label);
            Canvas.SetLeft(label, 20);
            Canvas.SetTop(label, 20);

            Canvas.SetZIndex(label, 2);

            canvas.Height = 1080;
            canvas.Width = 1920;
            canvas.SnapsToDevicePixels = true;
            Background background = new Background();
            AddObjectOnScene(background);

            //AddMeteorit("4", new Point(430 * 4.5, 50), new Size(50, 50), new Vector2(-3, 0));
            //AddMeteorit("5", new Point(50, 50), new Size(50, 50), new Vector2(3.3, 0));

            Player player = new Player("Player2", new Point(150, 500), new Size(100, 100), label);
            AddObjectOnScene(player, player.Control);

            for (int i = 0; i < 20; i++) {
                Coin coin = new Coin(i.ToString(), new Point(500 + i * 50, 660));
                AddObjectOnScene(coin);
                coin.Script = new CoinScript();
                coin.Script.SetParent(coin);
            }

            AddObjectOnScene(new Platform("Platform", new Point(0, 700), new Size(200, 50)));
            AddObjectOnScene(new Platform("Platform2", new Point(400, 700), new Size(200, 50)));
            AddObjectOnScene(new Platform("Platform2", new Point(800, 850), new Size(200, 50)));
            AddObjectOnScene(new Platform("Platform2", new Point(1000, 850), new Size(200, 50)));
            AddObjectOnScene(new Platform("Platform2", new Point(1200, 850), new Size(200, 50)));
            AddObjectOnScene(new Platform("Platform2", new Point(1400, 700), new Size(200, 50)));
            AddObjectOnScene(new Platform("Platform2", new Point(1600, 400), new Size(200, 50)));
            //HiddenBlock hiddenBlock = new HiddenBlock("hidden", new Point(1500, 600));
            //AddObjectOnScene(hiddenBlock);
            //hiddenBlock.Start();
            

            //AddPlayer("Player2", new Point(150, 500), new Size(100, 100), new Vector2(-1, 0));
            //AddPlatform("Platform", new Point(0, 700), new Size(2000, 500));
            //AddPlatform("Platform2", new Point(680, 600), new Size(500, 100));
            //AddPlatform("Platform3", new Point(680, 600), new Size(500, 100));
            //AddPlatform("Platform2", new Point(700, 600), new Size(500, 100));
        }
    }
}