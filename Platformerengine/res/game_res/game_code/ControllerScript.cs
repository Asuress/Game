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

        public bool OnGround { get; set; }
        public bool HitLeftWall { get; set; }
        public bool HitRightWall { get; set; }
        public bool HitCeil { get; set; }

        private GameObject Player { get; set; }
        private Scene Scene { get; set; }
        private double Speed { get; set; }
        private double MaxSpeed { get; set; }
        private double Acceleration { get; set; }

        private double JumpHeight { get; set; }

        private double g { get; set; }

        private double fallSpeed { get; set; }

        public void End() {
            throw new NotImplementedException();
        }

        public void SetParent(GameObject parent) {
            Player = parent;
            Speed = 0;
            MaxSpeed = 20;
            Acceleration = 1;
            g = 1;
            fallSpeed = 0;
            JumpHeight = 20;
        }

        public void SetStatus(string status) {
            switch (status) {
                case "OnGround":
                    OnGround = true;
                    break;
                case "NotOnGround":
                    OnGround = false;
                    break;
                case "HitLeftWall":
                    HitLeftWall = true;
                    break;
                case "HitRightWall":
                    HitRightWall = true;
                    break;
                case "NoLeftObstacles":
                    HitLeftWall = false;
                    break;
                case "NoRigthObstacles":
                    HitRightWall = false;
                    break;
                case "HitCeil":
                    HitCeil = true;
                    break;
                case "NotHitCeil":
                    HitCeil = false;
                    break;
            }
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
            } else if (Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.Left)) {
                if (Speed + Acceleration < MaxSpeed)
                    Speed += Acceleration;
                else
                    Speed = MaxSpeed;
            } else if (((Keyboard.IsKeyUp(Key.D) || Keyboard.IsKeyUp(Key.Right)) && (Keyboard.IsKeyUp(Key.A) || Keyboard.IsKeyUp(Key.Left)))) {
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
            fallSpeed += g;

            if (OnGround && (Keyboard.IsKeyDown(Key.W) || (Keyboard.IsKeyDown(Key.Up)))) {
                fallSpeed = -JumpHeight;
                OnGround = false;
            }


            foreach (var i in Scene.objects) {
                if (i.Key.Tag != "Background" && i.Key.Tag != "Player") {
                    if (OnGround) {
                        Player.Move.Y = 0;
                    } else
                        Player.Move.Y = fallSpeed;

                    if (Speed > 0 && HitRightWall) {
                        Speed = 0;
                    }
                    if (Speed < 0 && HitLeftWall)
                        Speed = 0;

                    i.Key.Move.X = Speed;
                }
                //Player.Move.Y = fallSpeed;
            }
        }
    }
}