using Platformerengine.res.code.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformerengine.res.game_res.game_code {
    class CoinScript : IGameManager {
        public GameObject parent { get; set; }
        public void End() {
            throw new NotImplementedException();
        }

        public void SetParent(GameObject parent) {
            this.parent = parent;
            parent.Collider.OnCollisionEnter += Collider_OnCollisionEnter;
        }

        private void Collider_OnCollisionEnter(code.physics.Collider.ColliderEventArgs colliderArgs) {
            if (colliderArgs.Collider.parent.Tag == "Player") {
                parent.Shape.Visibility = System.Windows.Visibility.Hidden;
                parent.Transform.Position.Y = -100;
            }

              
        }

        public void SetStatus(string status) {
            throw new NotImplementedException();
        }

        public void SetWindowSize(Size size) {
            throw new NotImplementedException();
        }

        public void StartPosition(Point start) {
            throw new NotImplementedException();
        }

        public void Update() {
        }
    }
}
