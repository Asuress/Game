using Platformerengine.res.code.Graphics;
using Platformerengine.res.code.logic;
using Platformerengine.res.code.physics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private int FpsLimit = 60;
        private Stopwatch timeOfOneFrame;
        private Stopwatch TotalTime;
        private int move = 0;

        private FabricScene scenes;
      
        private Game() {
            InitializeComponent();
            LinkedList<GameObject> ListOfObject = new LinkedList<GameObject>();

            scenes = FabricScene.GetInstance();

            Shape shape = new Rectangle();
            shape.Height = 100;
            shape.Width = 200;
            shape.Fill = Brushes.Black;

            Shape ellipse = new Ellipse();
            ellipse.Height = 200;
            ellipse.Width = 50;
            ellipse.Fill = Brushes.Red;

            GameObject rect = new GameObject("Rect".ToString(), 10, 10, shape);
            GameObject ell = new GameObject("Ellipse".ToString(), 50, 20, ellipse);

            ListOfObject.AddLast(rect);
            ListOfObject.AddLast(ell);

            scenes.AddScene("Primer", ListOfObject);
            //Canvas.Children.Add(fabric.GetScene("Primer".ToString()));
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
            
            

            double time = this.timeOfOneFrame.Elapsed.TotalMilliseconds;
            int idleTime = (int)((1000.0 / FpsLimit) - time);
            double totalTime = TotalTime.Elapsed.TotalMilliseconds;
            if (idleTime >= 0)
                Thread.Sleep(idleTime);

            this.timeOfOneFrame.Restart();
            // обновляется раз в секунду (1000 миллисекунд)
            if (totalTime >= 1000) {

                Framerate = (long)(FrameCoutner * 1000 / totalTime);
                //Canvas.Children.Add(label);
                //stopwatchLabel.Content = move; //DELETE IS TOO, IN HERE CHANGE FPS LABEL IN SCENE
                FrameCoutner = 0;
                TotalTime.Restart();
            }

            // FOR TEST FPS, DELETE IS LATER

            /*           Rectangle rect = new Rectangle();
                       FabricScene f = FabricScene.GetInstance();
                       //Canvas.Children.Add(f.GetScene("Primer".ToString()));
                       //Canvas.Children.
                       rect.Width = 100;
                       rect.Height = 50;
                       rect.Fill = Brushes.Red;
                       Canvas.SetLeft(rect, 20);
                       Canvas.SetTop(rect, move++);
                       Canvas.Children.Add(rect);
                       Label stopwatchLabel = new Label();
                       Canvas.SetLeft(stopwatchLabel, move++);
                       Canvas.SetTop(stopwatchLabel, 100);
                       Canvas.Children.Add(stopwatchLabel);*/
            // END OF TEST
        }

        private void ForceUpdate()
        {

        }
        private void Input()
        {
            // For test
            foreach (GameObject i in scenes.GetScene("Primer".ToString())) {             
                if (i.id == "Ellipse".ToString())
                    switch(Console.ReadKey().KeyChar) {
                        case 'a': i.Position.X++;
                    }
                    i.Position.X++;
            }
        }
        private void Update()
        {


        }
        private void Render() {
            int j = 0;
            foreach (GameObject i in scenes.GetScene("Primer".ToString())) {
                if (!Canvas.Children.Contains(i.Sprite)) {
                    Canvas.Children.Add(i.Sprite);
                    Canvas.SetLeft(i.Sprite, i.Position.X);
                    Canvas.SetTop(i.Sprite, i.Position.Y);
                } else {
                    Canvas.SetLeft(i.Sprite, i.Position.X);
                    Canvas.SetTop(i.Sprite, i.Position.Y);
                }
            }

        }
    }
}
