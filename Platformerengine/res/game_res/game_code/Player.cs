using Platformerengine.res.code.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Platformerengine.res.game_res.game_code {
    class Player : Platformerengine.res.code.logic.GameObject {
        public ControllerScript Control { get; set; }
        private int Score { get; set; }
        private int HealthPoint { get; set; }
        
        private bool IsAlive { get; set; }

        public Player(string _id, Point Point, Size anySize) : base(_id, "Player", new Rectangle(), Point, anySize) {
            SpriteRepository resourses = SpriteRepository.getInstance();
            Shape shape = new Rectangle();
            shape.Height = anySize.Height;
            shape.Width = anySize.Width;
            shape.Fill = resourses.Sprites["Player.jpg"];
            Shape = shape;

            Control = new ControllerScript();
            HealthPoint = 100;
            IsAlive = true;
        }

        public void AddScore(int score) {
            if (score > 0) {
                Score += score;
            }
        }

        public void ZeroidScore() {
            Score = 0;
        }

        public void Damage(int value) {
            if (HealthPoint - value > 0)
                HealthPoint -= value;
            else IsAlive = false;
        }

        public bool IsPlayerAlive() {
            return IsAlive;
        }
    }
}
