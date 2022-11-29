using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyNvader
{
    internal class Player
    {
        /// <summary>
        /// Position X du joueur
        /// </summary>
        private int _x;
        
        /// <summary>
        /// Position Y du joueur
        /// </summary>
        private int _y;

        /// <summary>
        /// Temps de recharge du joueur
        /// </summary>
        private int _recoil = 0;

        /// <summary>
        /// Vitesse du joueur
        /// </summary>
        private int _speed = 2;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Player()
        {
            this._x = 70;
            this._y = 57;

        }


        /// <summary>
        /// Getter Setter de X
        /// </summary>
        public int X
        {
            get { return this._x; }
            set { this._x = value; }
        }

        /// <summary>
        /// Getter Setter de Y 
        /// </summary>
        public int Y
        {
            get { return this._y; }
            set { this._y = value; }
        }

        /// <summary>
        /// Getter Setter de Speed
        /// </summary>
        public int Speed
        {
            get { return this._speed; }
            set { this._speed = value; }
        }

        /// <summary>
        /// Getter Setter de Recoil
        /// </summary>
        public int Recoil
        {
            get { return this._recoil; }
            set { this._recoil = value; }
        }
    }
}
