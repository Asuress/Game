using Platformerengine.res.code.logic;
using Platformerengine.res.code.physics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
        private Vector Speed;
        private long Framerate;
        private int FrameCoutner;
        private int FpsLimit = 120;
        private Stopwatch timeOfOneFrame;
        private Stopwatch TotalTime;
        private int move = 10; //DELETE THIS LATER
      
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
            timeOfOneFrame = new Stopwatch();
            TotalTime = new Stopwatch();
            CompositionTarget.Rendering += GameLoop;
           
        }

        protected void GameLoop(object sender, EventArgs e) {
            if (FrameCoutner++ != 0) {
                this.timeOfOneFrame.Start();
                this.TotalTime.Start();
            }

            Input();
            ForceUpdate();
            Update();
            Render();

            // FOR TEST FPS, DELETE IS LATER

            Label stopwatchLabel = new Label();
            Canvas.SetLeft(stopwatchLabel, move++);
            Canvas.SetTop(stopwatchLabel, 100);
            Canvas.Children.Add(stopwatchLabel);
            // END OF TEST


            double time = this.timeOfOneFrame.Elapsed.TotalMilliseconds;
            int idleTime = (int)((1000.0 / FpsLimit) - time);
            double totalTime = TotalTime.Elapsed.TotalMilliseconds;
            if (idleTime >= 0)
                Thread.Sleep(idleTime);

            this.timeOfOneFrame.Restart();
            // обновляется раз в секунду (1000 миллисекунд)
            if (totalTime >= 1000) {
                Framerate = (long)(FrameCoutner * 1000 / totalTime);
                stopwatchLabel.Content = time; //DELETE IS TOO, IN HERE CHANGE FPS LABEL IN SCENE
                FrameCoutner = 0;
                TotalTime.Restart();
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

        }
    }
}
