<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Platformerengine.res.code.physics {
    class Physics : IComponent
    {
        private Vector g = new Vector(0, -9.81);
        private Vector Acceleration = new Vector(0, 0);
        private LinkedList<Vector> Forces = new LinkedList<Vector>();

        public Vector Force { get; private set; }
        public Vector Speed { get; set; }
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

        public void addForce(Vector force, ForceMode mode = ForceMode.Force)
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
            Forces.AddLast(new Vector(Mass * g.X, Mass * g.Y));
            Forces.AddLast(new Vector(-Acceleration.X * g.Y * Friction, -Acceleration.Y * g.Y * Friction));
            Force = forcesSumm();
            accelerationCalculate();
        }

        private Vector forcesSumm()
        {
            Vector summ = new Vector();

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
=======
<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Platformerengine.res.code.physics {
    class Physics {
        private Vector g = new Vector(0, -9.81);
        private Vector Acceleration = new Vector(0, 0);
        private LinkedList<Vector> Forces = new LinkedList<Vector>();

        public Vector Force { get; private set; }
        public Vector Speed { get; set; }
        public double Mass { get; set; }
        public double Friction { get; set; }

        public enum ForceMode {
            Force,
            Impulse
        }
        public Physics(double mass = 1, double friction = 0) {
            Mass = mass;
            Friction = friction;
            init();
        }

        public void addForce(Vector force, ForceMode mode = ForceMode.Force) {
            switch (mode) {
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

        private void init() {
            Forces.AddLast(new Vector(Mass * g.X, Mass * g.Y));
            Forces.AddLast(new Vector(-Acceleration.X * g.Y * Friction, -Acceleration.Y * g.Y * Friction));
            Force = forcesSumm();
            accelerationCalculate();
        }

        private Vector forcesSumm() {
            Vector summ = new Vector();

            foreach (var v in Forces) {
                summ += v;
            }

            return summ;
        }

        private void accelerationCalculate() {
            Acceleration = Force / Mass;
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Platformerengine.res.code.physics {
    class Physics : IComponent
    {
        private Vector g = new Vector(0, -9.81);
        private Vector Acceleration = new Vector(0, 0);
        private LinkedList<Vector> Forces = new LinkedList<Vector>();

        public Vector Force { get; private set; }
        public Vector Speed { get; set; }
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

        public void addForce(Vector force, ForceMode mode = ForceMode.Force)
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
            Forces.AddLast(new Vector(Mass * g.X, Mass * g.Y));
            Forces.AddLast(new Vector(-Acceleration.X * g.Y * Friction, -Acceleration.Y * g.Y * Friction));
            Force = forcesSumm();
            accelerationCalculate();
        }

        private Vector forcesSumm()
        {
            Vector summ = new Vector();

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
>>>>>>> Scene
>>>>>>> Stashed changes
