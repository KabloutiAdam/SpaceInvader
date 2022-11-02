using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyNvader
{
    internal class Bullet
    {
        private int _x;
        private int _y;
        private int _speed = 1;
        private bool _contact = false;


        public Bullet(int x, int y)
        {
            _x = x + 7;
            _y = y - 4;
        }


        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

    }
}
