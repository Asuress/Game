using Platformerengine.res.code.logic;
using Platformerengine.res.code.physics;
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

        private Game() {
            InitializeComponent();
            IsGameRun = false;
        }

        public static Game GetInstance() {
            if (Instance == null) {
                Instance = new Game();
            }
            return Instance;
        }
        public void Start()
        {
            IsGameRun = true;
            GameLoop();
        }

        private void GameLoop()
        {
            /*
            new thread
            while(IsGameRune){
                ForceUpdate();
            //another physics
            }
            */
            while (IsGameRun)
            {
                Input();
                ForceUpdate();
                Update();
                Render();
            }
        }
        private void ForceUpdate()
        {

        }
        private void Input()
        {

        }
        private void Update()
        {

        }
        private void Render()
        {
            Rectangle rect = new Rectangle();
            rect.Width = 100;
            rect.Height = 50;
            Canvas.SetLeft(rect, 20);
            Canvas.SetTop(rect, 40);
            Canvas.Children.Add(rect);
        }
    }
}
