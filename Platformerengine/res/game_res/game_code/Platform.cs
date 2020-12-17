using Platformerengine.res.code.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Platformerengine.res.game_res.game_code {
    class Platform : GameObject {
        public Platform(string _id, Point Point, Size anySize) : base(_id, "Platform", new Rectangle(), Point, anySize) {
            SpriteRepository resourses = SpriteRepository.getInstance();
            Shape shape = new Rectangle();
            shape.Height = anySize.Height;
            shape.Width = anySize.Width;
            Random rand = new Random(DateTime.Now.Second);
            
            shape.Fill = resourses.Platforms[rand.Next(0, resourses.Platforms.Count)];
            Shape = shape;
        }
    }
}
