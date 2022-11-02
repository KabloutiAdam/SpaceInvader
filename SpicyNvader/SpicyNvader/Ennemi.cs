using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyNvader
{
    internal class Ennemi
    {
        private static string[] _ennemi = new string[5]
       {
               "  ▀▄   ▄▀  ",
               " ▄█▀███▀█▄ ",
               "█▀███████▀█",
               "█ █▀▀▀▀▀█ █",
               "   ▀▀ ▀▀   ",
       };
        private static string[] _void = new string[5]
       {
               "           ",
               "           ",
               "           ",
               "           ",
               "           ",
       };


        private int _xPose;
        private int _yPose;
        private int _speed = 1;
        private bool _alive;
        private bool _isShooting;
        private int _id;
        private int _direction; // 1 = droite  /  2 = gauche



        public Ennemi(int xPose, int yPose, int speed, bool alive, bool isShooting, int id)
        {
            _xPose = xPose;
            _yPose = yPose;
            _speed = speed;
            _alive = alive;
            _isShooting = isShooting;
            _direction = 1;
            _id = id;
        }


       

        public int XPose
        {
            get { return _xPose; }
            set { _xPose = value; }
        }
        public int YPose
        {
            get { return _yPose; }
            set { _yPose = value; }
        }
        public int Speeed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public bool Alive
        {
            get { return _alive; }
            set { _alive = value; }
        }
        public bool IsShooting
        {
            get { return _isShooting; }
            set { _isShooting = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        public int Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }




        public void DisplayEnnemi()
        {
            
            if(_alive)
            {
                for (int i = 0; i < _ennemi.Length; i++)
                {
                    Console.SetCursorPosition(_xPose, _yPose + i);
                    Console.Write(_ennemi[i]);
                }



               
            }
            
            
            
        }

        public void EreaseEnnemi()
        {
            for (int i = 0; i < _void.Length; i++)
            {
                Console.SetCursorPosition(_xPose, _yPose + i );
                Console.Write(_void[i]);
            }
        }
    }
}
