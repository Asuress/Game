using Platformerengine.res.code.graphic;
using Platformerengine.res.code.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Platformerengine.res.game_res.game_code {
    class ControllerScript : IGameManager {
        private GameObject Player { get; set; }
        private Scene Scene { get; set; }
        private double Speed { get; set; }
        private double MaxSpeed { get; set; }
        private double Acceleration { get; set; }

        public void End() {
            throw new NotImplementedException();
        }

        public void SetParent(GameObject parent) {
            Player = parent;
            Speed = 0;
            MaxSpeed = 20;
            Acceleration = 1;
        }

        public void SetWindowSize(Size size) { }

        public void StartPosition(Point start) { }

        public void Update() {
            
            code.Graphics.FabricScene fabric = code.Graphics.FabricScene.GetInstance();
            if (fabric.CurrentScene == null) {
                return;
            } else 
                Scene = fabric.CurrentScene;

            if (Keyboard.IsKeyDown(Key.D) || Keyboard.IsKeyDown(Key.Right)) {
                if (Speed - Acceleration > -1 * MaxSpeed)
                    Speed -= Acceleration;
                else
                    Speed = -1 * MaxSpeed;
            }
            else if (Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.Left)) {
                if (Speed + Acceleration < MaxSpeed)
                    Speed += Acceleration;
                else
                    Speed = MaxSpeed;
            }
            else if (((Keyboard.IsKeyUp(Key.D) || Keyboard.IsKeyUp(Key.Right)) && (Keyboard.IsKeyUp(Key.A) || Keyboard.IsKeyUp(Key.Left)))) {
                if (Speed < 0) {
                    if (Speed + Acceleration > 0) {
                        Speed = 0;
                    } else
                        Speed += Acceleration;                   
                } else if (Speed > 0) {
                    if (Speed - Acceleration < 0) {
                        Speed = 0;
                    } else
                        Speed -= Acceleration;
                }
            }

            foreach (var i in Scene.ListOfObj) {
                if (i.Tag != "Player" && i.Tag != "Background") {
                    i.Move.X = Speed;
                }
            }

        }
    }
}
