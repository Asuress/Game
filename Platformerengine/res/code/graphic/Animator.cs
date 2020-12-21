using Platformerengine.res.code.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Platformerengine.res.code.graphic
{
    public class Animator : GameEnvironment
    {
        public Animator(GameObject parent, int duration, List<Brush> images)
        {
            Images = images;
            Parent = parent;
            Duration = duration;
            Frame = 0;
            CurrentImageIndex = 0;
        }
        List<Brush> Images;
        GameObject Parent;
        int Duration;
        int CurrentImageIndex;
        int Frame;
        protected override void LateUpdate()
        {
            Frame++;
            if(Frame == Duration/Images.Count)
            {
                Frame = 0;
                Parent.Shape.Fill = Images[CurrentImageIndex];
                CurrentImageIndex++;
                if (CurrentImageIndex == Images.Count)
                    CurrentImageIndex = 0;
            }
        }
    }
}
