using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyNvader
{
    internal class Player
    {
        private int _x, _y;
        private int _recoil = 0;
        private int _speed = 1;

        public Player()
        {
            this._x = 30;
            this._y = 49;

        }



        public int X
        {
            get { return this._x; }
            set { this._x = value; }
        }

        public int Y
        {
            get { return this._y; }
            set { this._y = value; }
        }
        public int Speed
        {
            get { return this._speed; }
            set { this._speed = value; }
        }
        public int Recoil
        {
            get { return this._recoil; }
            set { this._recoil = value; }
        }


    }
}
