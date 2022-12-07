using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyNvader
{
    internal class Wall
    {

        private int _id;

        private int _x;

        private int _y;

        private int _lifePoints = 3;

        private string _symbole = "▀";

        public Wall(int id, int x, int y)
        {
            _id = id;
            _x = x;
            _y = y;
            
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

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int LifePoints
        {
            get { return _lifePoints; }
            set { _lifePoints = value; }
        }

        public string Symbole
        {
            get { return _symbole; }
            set { _symbole = value; }
        }


    }
}
