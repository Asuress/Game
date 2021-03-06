﻿using Platformerengine.res.code.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Platformerengine.res.game_res.game_code {
    class Background : GameObject {
        public Background(): base("Background", "Background", new Rectangle(), new Point(-100, 0), new Size(8000, 4000)) {
            SpriteRepository resourses = SpriteRepository.getInstance();
            Shape shape = new Rectangle();
            shape.Height = 1080;
            shape.Width = 8000;
            Collider = null;
            shape.Fill = resourses.Sprites["bg.jpg"];
            Shape = shape;
        }
    }
}
