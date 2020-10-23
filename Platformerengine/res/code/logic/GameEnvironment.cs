using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Platformerengine.res.code.logic
{
    public abstract class GameEnvironment
    {
        public GameEnvironment()
        {
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
