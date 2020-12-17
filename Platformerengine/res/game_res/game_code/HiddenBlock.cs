using Platformerengine.res.code.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Platformerengine.res.game_res.game_code {
    class HiddenBlock : GameObject {
        public IGameManager hiddenBlockScript { get; set; }
        public HiddenBlock(string id, Point point) : base(id, "HddenBlock", new Rectangle(), point, new Size(50, 50)){
            hiddenBlockScript = new HiddenBlockScript();
            SpriteRepository resourses = SpriteRepository.getInstance();
            Shape shape = new Rectangle();
            shape.Height = 50;
            shape.Width = 50;
            shape.Fill = resourses.Sprites["ground_wood_small.jpg"];
            Shape = shape;
        }
    }
}
