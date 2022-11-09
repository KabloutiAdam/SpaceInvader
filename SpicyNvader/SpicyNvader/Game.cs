using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SpicyNvader
{
    internal class Game
    {

        private int _sound;
        private bool _game;
        private int _difficulty;
        

       
        private static string[] _player = new string[3]
        {
               "      ███     ",
               "  ███████████ ",
               "  ███████████ ",
        };
        private static string[] _void = new string[3]
        {
               "              ",
               "              ",
               "              ",
        };


        public Game()
        {

        }

        public Game(int difficulty, int sound)
        {
            this._difficulty = difficulty;
            this._sound = sound; 
            
        }

        public void StartGame()
        {
            Player player = new Player();
            this._game = true;

            Squad squad = new Squad();
            squad.CreateEnnemi();
            

            List<Bullet> bulletList = new List<Bullet>();


            GameUpdate(player, squad, bulletList);
        }


        /// <summary>
        /// A chaque frame
        /// </summary>
        /// <param name="player"></param>
        /// <param name="squad"></param>
        public void GameUpdate(Player player, Squad squad, List<Bullet> bulletList)
        {
            int ennemiCounter = 0;
            int bulletCounter = 0;
            
            while (this._game)
            {

                bulletList = InputPlayer(player, bulletList);
                if(player.Recoil > 0)
                {
                    player.Recoil--;
                }


                bulletCounter++;
                ennemiCounter++;
                if (ennemiCounter == 5000)
                {
                    if (!squad.CheckBorder())
                    {
                        squad.EnnemiMovement();
                    }

                   

                    ennemiCounter = 0;

                }

                if (bulletCounter == 1000)
                {
                    EreaseBullet(bulletList);
                    BulletMovement(bulletList);
                    DisplayBullet(bulletList);

                    bulletCounter = 0;
                }


                CheckBulletColision(squad, bulletList);

            }


                //Thread.Sleep(1000);
        }
           


        

        public List<Bullet> InputPlayer(Player player, List<Bullet> bullet)
        {
            
            DisplayPlayer(player.X, player.Y);

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.RightArrow)
                {
                    if (player.X >= 116)
                    {
                        Console.SetCursorPosition(player.X, player.Y);
                    }
                    else
                    {
                        EreasePlayer(player.X, player.Y);
                        player.X += player.Speed;
                        DisplayPlayer(player.X, player.Y);
                    }

                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (player.X <= 1)
                    {
                        Console.SetCursorPosition(player.X, player.Y);
                    }
                    else
                    {
                        EreasePlayer(player.X, player.Y);
                        player.X -= player.Speed;
                        DisplayPlayer(player.X, player.Y);
                    }


                }
                else if (key.Key == ConsoleKey.Spacebar)
                {
                    if(player.Recoil == 0)
                    {
                        player.Recoil = 10000;
                        bullet.Add(new Bullet(player.X, player.Y));
                    }
                    
                }

            }

            return bullet;
        }


        public void DisplayPlayer(int x, int y)
        {
            for(int i = 0; i < _player.Length; i++)
            {
                Console.SetCursorPosition(x, y - _player.Length + i);
                Console.Write(_player[i]);
            }
        }

        public void EreasePlayer(int x, int y)
        {
            for (int i = 0; i < _void.Length; i++)
            {
                Console.SetCursorPosition(x, y - _void.Length + i);
                Console.Write(_void[i]);
            }
        }



        public void CheckBulletColision(Squad squad, List<Bullet> bulletList)
        {
            foreach (Ennemi ennemi in squad.EnemyList)
            {
                foreach (Bullet bullet in bulletList)
                {

                    if (bullet.Y == ennemi.YPose + 4 && (bullet.X < ennemi.XPose + 11 && bullet.X > ennemi.XPose))
                    {
                        if (ennemi.Alive)
                        {
                            ennemi.EreaseEnnemi();
                            ennemi.Alive = false;
                            RemoveBullet(bulletList, bullet);
                            break;
                        }

                    }

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

        public void BulletMovement(List<Bullet> bulletList)
        {
            foreach (Bullet bullet in bulletList)
            {
                bullet.Y -= 1;
            }
        }

        public void DisplayBullet(List<Bullet> bulletList)
        {
            foreach(Bullet bullet in bulletList)
            {
                Console.SetCursorPosition(bullet.X, bullet.Y);
                Console.Write("0");
            }
        }

        public void EreaseBullet(List<Bullet> bulletList)
        {
            foreach (Bullet bullet in bulletList)
            {
                Console.SetCursorPosition(bullet.X, bullet.Y);
                Console.Write(" ");
            }
        }



        public void RemoveBullet(List<Bullet> bulletList, Bullet bullet)
        {
            bulletList.Remove(bullet);
        }
    }
}
