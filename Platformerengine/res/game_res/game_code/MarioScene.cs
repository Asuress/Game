using Platformerengine.res.code.graphic;
using Platformerengine.res.code.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using Platformerengine.res.code.Graphics;

namespace Platformerengine.res.game_res.game_code {
    class MarioScene : Scene {
        private SpriteRepository resourses { get; set; } = SpriteRepository.getInstance();
        private Label label { get; set; }
        private int score { get; set; }
        public MarioScene(Size winSize) : base(winSize) {

        }

        private void BonusLevel(code.physics.Collider.ColliderEventArgs colliderArgs) {
            if ((Keyboard.IsKeyUp(Key.S) || Keyboard.IsKeyUp(Key.Down) && colliderArgs.Collider.parent.Tag == "Player" && colliderArgs.normal.Y == 1)) {
                FabricScene fabric = FabricScene.GetInstance();
                fabric.SetCurrentScene("BonusScene");

            }
        }

        public override void InitScene() {
            base.InitScene();
            score = 0;
            label = new Label();
            label.Height = 100;
            label.Width = 2100;
            label.Content = "Score: ";
            label.FontSize = 50;
            canvas.Children.Add(label);
            Canvas.SetLeft(label, 20);
            Canvas.SetTop(label, 20);

            Canvas.SetZIndex(label, 2);

            canvas.Height = 1080;
            canvas.Width = 1920;
            canvas.SnapsToDevicePixels = true;
            Background background = new Background();
            AddObjectOnScene(background);

            Platform ground = new Platform("Ground", new Point(-60, 958), new Size(5300, 300));
            AddObjectOnScene(ground);

            Player mario = new Player("Mario", new Point(100, 400), new Size(50, 65), new System.Windows.Controls.Label());
            AddObjectOnScene(mario, mario.Control);

            Size blockSize = new Size(80, 80);

            HiddenBlock moneyBlock = new HiddenBlock("hidden", new Point(1140, 652), blockSize);
            AddObjectOnScene(moneyBlock);
            moneyBlock.Collider.OnCollisionEnter += onCollisionEnter;

            HiddenBlock moneyBlock2 = new HiddenBlock("hidden2", new Point(1133 + 80 * 5, 652), blockSize);
            AddObjectOnScene(moneyBlock2);
            moneyBlock2.Collider.OnCollisionEnter += onCollisionEnter;

            HiddenBlock moneyBlock3 = new HiddenBlock("hidden3", new Point(1130 + 80 * 7, 652), blockSize);
            AddObjectOnScene(moneyBlock3);
            moneyBlock3.Collider.OnCollisionEnter += onCollisionEnter;

            HiddenBlock block1 = new HiddenBlock("1", new Point(1130 + 80 * 4, 652), blockSize);
            AddObjectOnScene(block1);

            HiddenBlock block2 = new HiddenBlock("2", new Point(1130 + 80 * 6, 652), blockSize);
            AddObjectOnScene(block2);

            HiddenBlock block3 = new HiddenBlock("2", new Point(1130 + 80 * 8, 652), blockSize);
            AddObjectOnScene(block3);

            HiddenBlock moneyBlock4 = new HiddenBlock("2", new Point(1120 + 80 * 6, 660 - 80 * 4), blockSize);
            AddObjectOnScene(moneyBlock4);
            moneyBlock4.Collider.OnCollisionEnter += onCollisionEnter;

            HiddenBlock tube = new HiddenBlock("t", new Point(1120 + 80 * 12, 958 - 2 * 80), new Size(160, 160));
            AddObjectOnScene(tube);

            HiddenBlock tube2 = new HiddenBlock("t2", new Point(1140 + 80 * 21, 958 - 3 * 80), new Size(160, 80 * 3));
            AddObjectOnScene(tube2);

            HiddenBlock tube3 = new HiddenBlock("t2", new Point(1140 + 80 * 29, 958 - 4 * 80), new Size(160, 80 * 4));
            AddObjectOnScene(tube3);

            HiddenBlock tube4 = new HiddenBlock("t2", new Point(1110 + 80 * 40, 958 - 4 * 80), new Size(160, 80 * 4));
            AddObjectOnScene(tube4);
            tube4.Collider.OnCollisionStay += BonusLevel;
        } 

        private void onCollisionEnter(code.physics.Collider.ColliderEventArgs colliderArgs) {
            if (colliderArgs.Collider.parent.Tag == "Player" && colliderArgs.normal.Y == -1) {
                //colliderArgs.Collider.parent.Shape.Visibility = System.Windows.Visibility.Hidden;
                //HiddenBlock block = new HiddenBlock("Block", colliderArgs.collider2.parent.Transform.Position);
                colliderArgs.collider2.parent.Shape.Fill = resourses.Sprites["emptyBlock.jpg"];
                //AddObjectOnScene(block);
                score += 100;
                label.Content = "Score: " + score;
                colliderArgs.collider2.parent.Collider.OnCollisionEnter -= onCollisionEnter;
            }
        }
    }
}
