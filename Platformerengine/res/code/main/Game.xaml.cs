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
            FabricScene.AddScene("Meteorits".ToString(), new MeteoritScene(new logic.Size(WindowHeight, WindowWidth)));
            FabricScene.SetCurrentScene("Meteorits");
            viewbox.Child = FabricScene.CurrentScene.canvas;
            FabricScene.CurrentScene.Start();

        }
    }
}
