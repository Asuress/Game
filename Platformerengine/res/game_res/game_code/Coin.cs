using Platformerengine.res.code.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Platformerengine.res.game_res.game_code {
    class Coin : GameObject {
        public CoinScript Script { get; set; }
        public Coin(string id, Point point) : base(id, "Coin", new Ellipse(), point, new Size(50, 50)) {
            Script = new CoinScript();

            SpriteRepository resourses = SpriteRepository.getInstance();
            Shape shape = new Rectangle();
            shape.Height = 50;
            shape.Width = 50;
            Random rand = new Random(DateTime.Now.Second);

            shape.Fill = resourses.Sprites["bronze_2.jpg"];
            Shape = shape;
        }

    }
}
