using Platformerengine.res.code.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformerengine.res.game_res.game_code {
    class HiddenBlockScript : IGameManager {
        public IGameManager controller;
        public GameObject hiddenBlock { get; set; }
        public void End() {
            
            throw new NotImplementedException();
        }

        public void SetParent(GameObject parent) {
            hiddenBlock = (HiddenBlock)parent;
            controller = new HiddenBlockScript();
            hiddenBlock.Collider.OnCollisionEnter += Collider_OnCollisionEnter;
        }

        private void Collider_OnCollisionEnter(code.physics.Collider.ColliderEventArgs colliderArgs) {
            if (colliderArgs.Collider.parent.Tag == "Player") {
                SpriteRepository sprites = SpriteRepository.getInstance();
                hiddenBlock.Shape.Fill = sprites.Sprites["carrot.jpg"];
                controller = new CoinScript();

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
            throw new NotImplementedException();
        }
    }
}
