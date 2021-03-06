﻿using Platformerengine.res.code.graphic;
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
        public Player Player { get; set; }
        private bool Ground { get; set; }
        private bool Top { get; set; }
        private bool Right { get; set; }
        private bool Left { get; set; }
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
            Player = (Player)parent;
            Speed = 0;
            MaxSpeed = 20;
            Acceleration = 1;
            g = 1.5;
            fallSpeed = 0;
            JumpHeight = 30;
            Player.Collider.OnCollisionEnter += OnCollisionEnter;
            Player.Collider.OnCollisionExit += OnCollisionExit;
            Player.Collider.OnCollisionStay += OnCollisionStay;
        }

        private void OnCollisionStay(code.physics.Collider.ColliderEventArgs colliderArgs) {
            if (colliderArgs.normal.Y == -1 && colliderArgs.collider2.parent.Tag == "Player" && colliderArgs.Collider.parent.Tag != "Background" && colliderArgs.Collider.parent.Tag != "Coin") {
                Ground = true;
            }
            if (colliderArgs.normal.Y == 1 && colliderArgs.collider2.parent.Tag == "Player" && colliderArgs.Collider.parent.Tag != "Background" && colliderArgs.Collider.parent.Tag != "Coin") {
                Top = true;
            }
            if (colliderArgs.normal.X == 1 && colliderArgs.collider2.parent.Tag == "Player" && colliderArgs.Collider.parent.Tag != "Background" && colliderArgs.Collider.parent.Tag != "Coin") {
                Left = true;
            }
            if (colliderArgs.normal.X == -1 && colliderArgs.collider2.parent.Tag == "Player" && colliderArgs.Collider.parent.Tag != "Background" && colliderArgs.Collider.parent.Tag != "Coin") {
                Right = true;
            }
        }

        private void OnCollisionExit(code.physics.Collider.ColliderEventArgs colliderArgs) {
            if (colliderArgs.normal.X == 0 && colliderArgs.collider2.parent.Tag == "Player" && colliderArgs.Collider.parent.Tag != "Background" && colliderArgs.Collider.parent.Tag != "Coin") {
                Right = false;
            }
            if (colliderArgs.normal.X == 0 && colliderArgs.collider2.parent.Tag == "Player" && colliderArgs.Collider.parent.Tag != "Background" && colliderArgs.Collider.parent.Tag != "Coin") {
                Left = false;
            }
            if (colliderArgs.normal.Y == 0 && colliderArgs.collider2.parent.Tag == "Player" && colliderArgs.Collider.parent.Tag != "Background" && colliderArgs.Collider.parent.Tag != "Coin") {
                Ground = false;
            }         
            if (colliderArgs.normal.Y == 0 && colliderArgs.collider2.parent.Tag == "Player" && colliderArgs.Collider.parent.Tag != "Background" && colliderArgs.Collider.parent.Tag != "Coin") {
                Top = false;
            }
        }

        private void OnCollisionEnter(code.physics.Collider.ColliderEventArgs colliderArgs) {
            if (colliderArgs.normal.Y == -1 && colliderArgs.collider2.parent.Tag == "Player" && colliderArgs.Collider.parent.Tag != "Background" && colliderArgs.Collider.parent.Tag != "Coin") {
                Ground = true;
            }
            if (colliderArgs.normal.Y == 1 && colliderArgs.collider2.parent.Tag == "Player" && colliderArgs.Collider.parent.Tag != "Background" && colliderArgs.Collider.parent.Tag != "Coin") {
                Top = true;
            }
            if (colliderArgs.normal.X == 1 && colliderArgs.collider2.parent.Tag == "Player" && colliderArgs.Collider.parent.Tag != "Background" && colliderArgs.Collider.parent.Tag != "Coin") {
                Left = true;
            }
            if (colliderArgs.normal.X == -1 && colliderArgs.collider2.parent.Tag == "Player" && colliderArgs.Collider.parent.Tag != "Background" && colliderArgs.Collider.parent.Tag != "Coin") {
                Right = true;
            }

            if (colliderArgs.Collider.parent.Tag == "Coin") {
                Player.AddScore(100);
            }
        }

        public void SetStatus(string status) {

            
        }

        public void SetWindowSize(Size size) { }

        public void StartPosition(Point start) { }

        public void Update() {

            code.Graphics.FabricScene fabric = code.Graphics.FabricScene.GetInstance();
            if (fabric.CurrentScene == null) {
                return;
            } else
                Scene = fabric.CurrentScene;

            if ((Keyboard.IsKeyDown(Key.D) || Keyboard.IsKeyDown(Key.Right))) {
                if (Speed - Acceleration > -1 * MaxSpeed)
                    Speed -= Acceleration;
                else
                    Speed = -1 * MaxSpeed;
            } else if ((Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.Left))) {
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

            if (Ground && (Keyboard.IsKeyDown(Key.W) || (Keyboard.IsKeyDown(Key.Up)))) {
                fallSpeed = -JumpHeight;
            }


            foreach (var i in Scene.objects) {
                if (i.Key.Tag != "Background" && i.Key.Tag != "Player") {
                    if (fallSpeed < 0 || !Ground)
                        Player.Move.Y = fallSpeed;
                    else if (Ground) {
                        Player.Move.Y = 0;
                        fallSpeed = 0;
                    }
                    else if (Top) {
                        fallSpeed = 0;
                    }
                        
            /*        if (Speed > 0 && Normal.X == 1) {
                        Speed = 0;
                    }
                    if (Speed < 0 && Normal.X == -1)
                        Speed = 0;
            */
                    if (Right && Speed < 0) {
                        Speed = 0;
                    }
                    if (Left && Speed > 0) {
                        Speed = 0;
                    }

                    i.Key.Move.X = Speed;
                }
                else if (i.Key.Tag == "Background") {
                    i.Key.Move.X = Speed / 10;
                }
                
                if (Player.Transform.Position.Y > 800) {
                    Player.Transform.Position.X = 150;
                    Player.Transform.Position.Y = 0;
                    Player.ZeroidScore();
                    fallSpeed = 0;
                    Speed = 0;
                }
            }
        }
    }
}