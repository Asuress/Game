using Platformerengine.res.code.logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformerengine.res.game_res.game_code {
    class MeteoritScript : IGameManager {
        private GameObject Parent { get; set; }
        private Point StartPos { get; set; }
        private Size WindowSize { get; set; }

        private int timeOfDie { get; set; }
        private bool bump { get; set; }
        private int count { get; set; }
        public void End() {

        }

        public void SetParent(GameObject parent) {
            Parent = parent;
            count = 0;
            timeOfDie = 60 * 1;
            Parent.Shape.SnapsToDevicePixels = false;
        }

        public void SetStatus(string status) {
            switch (status) {
                case "bump":
                    bump = true;
                    break;
            }
        }

        public void SetWindowSize(Size size) {
            WindowSize = size;
        }

        public void StartPosition(Point start) {
            StartPos = new Point(start);
        }

        public void Update() {
            if (Parent.Transform.Position.X + Parent.Move.X > -20 &&
                Parent.Transform.Position.Y + Parent.Move.Y > -20 &&
                Parent.Transform.Position.X + Parent.Move.X < WindowSize.Height * 2.5 &&
                Parent.Transform.Position.Y + Parent.Move.Y < WindowSize.Width * 2.5 && !bump) {

                Parent.Transform.Rotate(Parent.Transform.Position.X / 10);
            } else {
                Parent.Transform.Position = new Point(StartPos);
                bump = false;
            }


        }
    }
}