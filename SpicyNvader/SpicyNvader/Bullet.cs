using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyNvader
{
    internal class Bullet
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
        private int _speed = 1;

        /// <summary>
        /// Booléen de contact du missile
        /// </summary>
        private bool _contact = false;


        /// <summary>
        /// Constructeur Custom
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Bullet(int x, int y)
        {
            _x = x + 7;
            _y = y - 4;
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

    }
}
