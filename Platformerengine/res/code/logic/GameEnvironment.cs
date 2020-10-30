using System;
using System.Windows.Media;

namespace Platformerengine.res.code.logic
{
    public abstract class GameEnvironment
    {
        public GameEnvironment() { }

        public void Start() {
            CompositionTarget.Rendering += GameLoop;
        }

        private void GameLoop(object sender, EventArgs e)
        {
            EarlyUpdate();
            Update();
            LateUpdate();
        }

        protected virtual void EarlyUpdate() { }
        protected virtual void Update() { }
        protected virtual void LateUpdate() { }
    }
}
