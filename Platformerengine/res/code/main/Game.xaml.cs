using Platformerengine.res.code.graphic;
using Platformerengine.res.code.Graphics;
using Platformerengine.res.code.logic;
using Platformerengine.res.code.physics;
using Platformerengine.res.game_res.game_code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Platformerengine.res.code.main {
    public partial class Game : Page {
        private static Game Instance;
        private bool IsGameRun;
        private FabricScene FabricScene;

        private Game() {
            InitializeComponent();
            IsGameRun = false;
            FabricScene = FabricScene.GetInstance();
        }

        public static Game GetInstance() {
            if (Instance == null) {
                Instance = new Game();
            }
            return Instance;
        }
        public void Start() {
            IsGameRun = true;
            Scene meteorits = new MeteoritScene(new logic.Size(WindowHeight, WindowWidth));
            
            FabricScene.AddScene("Meteorits".ToString(), meteorits);
            viewbox.Child = FabricScene.GetScene("Meteorits").canvas;

            /*Shape shape = new Rectangle();
            shape.Height = 100;
            shape.Width = 200;
            shape.Fill = Brushes.Black;

            Shape ellipse = new Ellipse();
            ellipse.Height = 200;
            ellipse.Width = 50;
            ellipse.Fill = Brushes.Red;

            GameObject rect = new GameObject("Rect".ToString(), "Player".ToString(), shape, new logic.Point(10, 10), new logic.Size(10, 5));
            GameObject ell = new GameObject("Ellipse".ToString(), "Enemy".ToString(), ellipse, new logic.Point(50, 20), new logic.Size(10, 10));
            Scene scene = new Scene();
            scene.AddObjectOnScene(rect);
            scene.AddObjectOnScene(ell);
            FabricScene.AddScene("Primer", scene);
<<<<<<< Updated upstream

            AddVisualChild(FabricScene.GetScene("Primer").canvas);
=======
<<<<<<< HEAD
            FabricScene.GetScene("Primer").canvas.Width = 1000;
            FabricScene.GetScene("Primer").canvas.Height = 500;
            //AddVisualChild(FabricScene.GetScene("Primer").canvas);
            viewbox.Child = FabricScene.GetScene("Primer").canvas;
            */

            //AddVisualChild(FabricScene.GetScene("Primer").canvas);
        }
    }
}
