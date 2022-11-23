﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyNvader
{
    internal class Enemy
    {

        /// <summary>
        /// Tableau de charactère représentant un ennemi
        /// </summary>
        private static string[] _ennemi = new string[5]
       {
               "  ▀▄   ▄▀  ",
               " ▄█▀███▀█▄ ",
               "█▀███████▀█",
               "█ █▀▀▀▀▀█ █",
               "   ▀▀ ▀▀   ",
       };

        /// <summary>
        /// Tableau de charactère représentant du vide
        /// </summary>
        private static string[] _void = new string[5]
       {
               "           ",
               "           ",
               "           ",
               "           ",
               "           ",
       };

        /// <summary>
        /// Position X de l'ennemi
        /// </summary>
        private int _xPose;

        /// <summary>
        /// Position Y de l'ennemi
        /// </summary>
        private int _yPose;

        /// <summary>
        /// Vitesse de l'ennemi
        /// </summary>
        private int _speed = 1;

        /// <summary>
        /// true = est vivant / False = est mort
        /// </summary>
        private bool _alive;

        /// <summary>
        /// true = est en train de tirer / False = Ne tire pas
        /// </summary>
        private bool _isShooting;

        /// <summary>
        /// Id de l'ennemi
        /// </summary>
        private int _id;

        /// <summary>
        /// Direction de l'ennemi, 1 = droite / 2 = gauche
        /// </summary>
        private int _direction;


        /// <summary>
        /// Constructeur Custom
        /// </summary>
        /// <param name="xPose"></param>
        /// <param name="yPose"></param>
        /// <param name="speed"></param>
        /// <param name="alive"></param>
        /// <param name="isShooting"></param>
        /// <param name="id"></param>
        public Enemy(int xPose, int yPose, int speed, bool alive, bool isShooting, int id)
        {
            _xPose = xPose;
            _yPose = yPose;
            _speed = speed;
            _alive = alive;
            _isShooting = isShooting;
            _direction = 1;
            _id = id;
        }


       
        /// <summary>
        /// Getter Setter de Xpose
        /// </summary>
        public int XPose
        {
            get { return _xPose; }
            set { _xPose = value; }
        }

        /// <summary>
        /// Getter Setter de YPose
        /// </summary>
        public int YPose
        {
            get { return _yPose; }
            set { _yPose = value; }
        }

        /// <summary>
        /// Getter Setter de Speed
        /// </summary>
        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        /// <summary>
        /// Getter Setter de Alive
        /// </summary>
        public bool Alive
        {
            get { return _alive; }
            set { _alive = value; }
        }

        /// <summary>
        /// Getter Setter de IsShooting
        /// </summary>
        public bool IsShooting
        {
            get { return _isShooting; }
            set { _isShooting = value; }
        }
        /// <summary>
        /// Getter Setter de ID
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        /// <summary>
        /// Getter Setter de Direction
        /// </summary>
        public int Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }



        /// <summary>
        /// Méthode que affiche l'ennemi
        /// </summary>
        public void DisplayEnnemi()
        {
            // Regarde si l'ennemi est vivant
            if(_alive)
            {
                for (int i = 0; i < _ennemi.Length; i++)
                {
                    Console.SetCursorPosition(_xPose, _yPose + i);
                    Console.Write(_ennemi[i]);
                }
            }
        }

        /// <summary>
        /// Méthode qui efface l'ennemi
        /// </summary>
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