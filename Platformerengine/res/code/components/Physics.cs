using Platformerengine.res.code.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Platformerengine.res.code.physics {
    class Physics : IComponent
    {
        private Vector2 g = new Vector2(0, -9.81);
        private Vector2 Acceleration = new Vector2(0, 0);
        private LinkedList<Vector2> Forces = new LinkedList<Vector2>();

        public Vector2 Force { get; private set; }
        public Vector2 Speed { get; set; }
        public double Mass { get; set; }
        public double Friction { get; set; }

        public enum ForceMode
        {
            Force,
            Impulse
        }
        public Physics(double mass = 1, double friction = 0)
        {
            Mass = mass;
            Friction = friction;
            init();
        }

        public void addForce(Vector2 force, ForceMode mode = ForceMode.Force, double time = 1)
        {
            switch (mode)
            {
                case ForceMode.Force:
                    //temporary solution
                    Force += force;
                    break;
                case ForceMode.Impulse:
                    Force += force;
                    break;
                default:
                    break;
            }
        }

        private void init()
        {
            Forces.AddLast(new Vector2(Mass * g.X, Mass * g.Y));
            Forces.AddLast(new Vector2(-Acceleration.X * g.Y * Friction, -Acceleration.Y * g.Y * Friction));
            Force = forcesSumm();
            accelerationCalculate();
        }

        private Vector2 forcesSumm()
        {
            Vector2 summ = new Vector2();

            foreach (var v in Forces)
            {
                summ += v;
            }

            return summ;
        }

        private void accelerationCalculate()
        {
            Acceleration = Force / Mass;
        }
    }
}
