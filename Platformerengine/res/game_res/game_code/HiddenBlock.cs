using Platformerengine.res.code.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Platformerengine.res.game_res.game_code {
    class HiddenBlock : GameObject {
        //public IGameManager hiddenBlockScript { get; set; }
        public HiddenBlock(string id, Point point, Size size) : base(id, "Block", new Rectangle(), point, size){
            //hiddenBlockScript = new HiddenBlockScript();
            SpriteRepository resourses = SpriteRepository.getInstance();
            Shape shape = new Rectangle();
            shape.Height = size.Height;
            shape.Width = size.Width;
            shape.Fill = resourses.Sprites["check.jpg"];
            Shape = shape;
        }
    }
}
