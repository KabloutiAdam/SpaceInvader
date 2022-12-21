using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyNvader
{
    public class Bullet
    {
        /// <summary>
        /// Position X du missile
        /// </summary>
        private int _x;

        /// <summary>
        /// Position Y du missile
        /// </summary>
        private int _y;

        /// <summary>
        /// Vitesse du missile (ligne/update)
        /// </summary>
        private int _speed;

        /// <summary>
        /// Booléen de contact du missile
        /// </summary>
        private bool _contact = false;


        /// <summary>
        /// Constructeur Custom
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Bullet(int x, int y, int speed)
        {
            _x = x;
            _y = y;
            _speed = speed;
        }


        /// <summary>
        /// Getter Setter du X
        /// </summary>
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        /// <summary>
        /// Getter Setter du Y
        /// </summary>
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        /// <summary>
        /// Getter Setter de la vitesse
        /// </summary>
        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

    }
}
