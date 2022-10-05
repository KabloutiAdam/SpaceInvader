using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyNvaderUnitTest
{
    internal class Player
    {


        int _x, _y;
        int _speed = 20;
        public Player(int _x, int _y, int _speed)
        {

        }

       

        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

    }
}
