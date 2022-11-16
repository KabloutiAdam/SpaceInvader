using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SpicyNvader
{
    internal class Game
    {
        

        /// <summary>
        /// Jeu actif, false = désactivé / true = activé
        /// </summary>
        private bool _game;

        /// <summary>
        /// Difficulté du jeu, 0 = facile / 1 = dificile
        /// </summary>
        private int _difficulty;

        /// <summary>
        /// Son du jeu, 0 = off / 1 = on
        /// </summary>
        private int _sound;

        /// <summary>
        /// Nombre d'ennemis par ligne
        /// </summary>
        private int _numberOfEnemyByRow;

        /// <summary>
        /// Nombre de ligne d'ennemis
        /// </summary>
        private int _numberOfRow;
        

       /// <summary>
       /// Tableau de charactère représentant le joueur
       /// </summary>
        private static string[] _player = new string[3]
        {
               "      ███     ",
               "  ███████████ ",
               "  ███████████ ",
        };

        /// <summary>
        /// Tableau de charactère représentant du vide 
        /// </summary>
        private static string[] _void = new string[3]
        {
               "              ",
               "              ",
               "              ",
        };


        /// <summary>
        /// constructeur par défaut
        /// </summary>
        public Game()
        {

        }

        /// <summary>
        /// Constructeur custom
        /// </summary>
        /// <param name="difficulty"></param>
        /// <param name="sound"></param>
        public Game(int difficulty, int sound)
        {
            this._difficulty = difficulty;
            this._sound = sound; 
            
        }


        /// <summary>
        /// Méthode qui démarre le jeu 
        /// </summary>
        public void StartGame()
        {
            // Instancie le joueur
            Player player = new Player();
            this._game = true;

            // Regarde les paramètre de la partie
            if(_difficulty == 1)
            {
                _numberOfEnemyByRow = 6;
                _numberOfRow = 3;
            }
            else
            {
                _numberOfEnemyByRow = 5;
                _numberOfRow = 2;
            }

            // Instancie la squad d'ennemis
            Squad squad = new Squad(_numberOfEnemyByRow, _numberOfRow);

            squad.CreateEnnemi();
            
            //Créé la liste de missile de type Bullet
            List<Bullet> bulletList = new List<Bullet>();

            
            GameUpdate(player, squad, bulletList);
        }


        /// <summary>
        /// A chaque frame du jeu
        /// </summary>
        /// <param name="player"></param>
        /// <param name="squad"></param>
        public void GameUpdate(Player player, Squad squad, List<Bullet> bulletList)
        {
            
            int ennemiCounter = 0;
            int bulletCounter = 0;
            
            // Pendant que le jeu est actif
            while (this._game)
            {
                // Regarde l'input du joueur
                bulletList = InputPlayer(player, bulletList);

                
                if(player.Recoil > 0)
                {
                    player.Recoil--;
                }


                bulletCounter++;
                ennemiCounter++;

                // Intervalle des déplacements des ennemis 
                if (ennemiCounter == 5000)
                {
                    // Regarde les bordures et effectue les mouvements
                    if (!squad.CheckBorder())
                    {
                        squad.EnnemiMovement();
                    }

                    // Reset le counter
                    ennemiCounter = 0;
                }

                // Intervalle des déplacement des missiles
                if (bulletCounter == 1000)
                {
                    EreaseBullet(bulletList);
                    BulletMovement(bulletList);
                    DisplayBullet(bulletList);

                    // Reset le counter 
                    bulletCounter = 0;
                }

                // Regarde les collisions des missiles
                CheckBulletColision(squad, bulletList);
            }
        }
        
        /// <summary>
        /// Méthode qui regarde les inputs du joueur
        /// </summary>
        /// <param name="player"></param>
        /// <param name="bullet"></param>
        /// <returns> Retourne la liste des missiles de type Bullet </returns>
        public List<Bullet> InputPlayer(Player player, List<Bullet> bullet)
        {
            // Affiche le joueur
            DisplayPlayer(player.X, player.Y);


            // Regarde la touche enfoncée par le joueur
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.RightArrow)
                {

                    // Regarde si le joueur se trouve au bord de la console
                    if (player.X >= 116)
                    {
                        Console.SetCursorPosition(player.X, player.Y);
                    }
                    else
                    {
                        // Effectue le déplacement 
                        EreasePlayer(player.X, player.Y);
                        player.X += player.Speed;
                        DisplayPlayer(player.X, player.Y);
                    }
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    // Regarde si le joueur se trouve au bord de la console
                    if (player.X <= 1)
                    {
                        Console.SetCursorPosition(player.X, player.Y);
                    }
                    else
                    {
                        // Effectue le déplacement
                        EreasePlayer(player.X, player.Y);
                        player.X -= player.Speed;
                        DisplayPlayer(player.X, player.Y);
                    }
                }
                else if (key.Key == ConsoleKey.Spacebar)
                {
                    // Regarde si le joueur a rechargé son tir et peut tirer
                    if(player.Recoil == 0)
                    {
                        // Instancie un nouveau "Bullet" et reset le temps de recharge
                        player.Recoil = 10000;
                        bullet.Add(new Bullet(player.X, player.Y));
                    }
                }
            }

            // Retourne la liste de Bullet
            return bullet;
        }


        /// <summary>
        /// Méthode pour afficher le joueur dans la console
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void DisplayPlayer(int x, int y)
        {
            for(int i = 0; i < _player.Length; i++)
            {
                Console.SetCursorPosition(x, y - _player.Length + i);
                Console.Write(_player[i]);
            }
        }


        /// <summary>
        /// Méthode pour effacer le joueur de la console
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void EreasePlayer(int x, int y)
        {
            for (int i = 0; i < _void.Length; i++)
            {
                Console.SetCursorPosition(x, y - _void.Length + i);
                Console.Write(_void[i]);
            }
        }


        /// <summary>
        /// Méthode pour regarder les collisions des missiles 
        /// </summary>
        /// <param name="squad"></param>
        /// <param name="bulletList"></param>
        public void CheckBulletColision(Squad squad, List<Bullet> bulletList)
        {
            // Regarde tous les ennemis ainsi que tous les missiles
            foreach (Enemy ennemi in squad.EnemyList)
            {
                foreach (Bullet bullet in bulletList)
                {

                    // Regarde si la position du missile est la même que celle d'un ennemis
                    if (bullet.Y == ennemi.YPose + 4 && (bullet.X < ennemi.XPose + 11 && bullet.X > ennemi.XPose))
                    {
                        // Si l'ennemi est vivant, l'efface, le considère comme mort et détruit le missile
                        if (ennemi.Alive)
                        {
                            ennemi.EreaseEnnemi();
                            ennemi.Alive = false;
                            RemoveBullet(bulletList, bullet);
                            break;
                        }
                    }

                    // Détruit le missile s'il sort de la console
                    if (bullet.Y == 1)
                    {
                        Console.SetCursorPosition(bullet.X, bullet.Y);
                        Console.Write(" ");
                        RemoveBullet(bulletList, bullet);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Méthode qui effectue les mouvements des missiles
        /// </summary>
        /// <param name="bulletList"></param>
        public void BulletMovement(List<Bullet> bulletList)
        {
            foreach (Bullet bullet in bulletList)
            {
                bullet.Y -= 1;
            }
        }

        /// <summary>
        /// Méthode qui affiche les missiles
        /// </summary>
        /// <param name="bulletList"></param>
        public void DisplayBullet(List<Bullet> bulletList)
        {
            foreach(Bullet bullet in bulletList)
            {
                Console.SetCursorPosition(bullet.X, bullet.Y);
                Console.Write("0");
            }
        }

        /// <summary>
        /// Méthode qui efface les missiles
        /// </summary>
        /// <param name="bulletList"></param>
        public void EreaseBullet(List<Bullet> bulletList)
        {
            foreach (Bullet bullet in bulletList)
            {
                Console.SetCursorPosition(bullet.X, bullet.Y);
                Console.Write(" ");
            }
        }


        /// <summary>
        /// Méthode qui suprrime un missile de la liste de missile 
        /// </summary>
        /// <param name="bulletList"></param>
        /// <param name="bullet"></param>
        public void RemoveBullet(List<Bullet> bulletList, Bullet bullet)
        {
            bulletList.Remove(bullet);
        }
    }
}
