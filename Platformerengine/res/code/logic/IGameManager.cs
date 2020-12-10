using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Platformerengine.res.code.logic {
    public interface IGameManager {
        void StartPosition(Point start);
        void Update();
        void End();
        void SetWindowSize(Size size);
        void SetParent(GameObject parent);

        void SetStatus(string status);
    }
}
