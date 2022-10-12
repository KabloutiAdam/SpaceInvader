using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SpicyNvader
{
    internal class Game
    {

        private bool _sound;
        private bool _game;
        private string _difficulty;
        

       
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

        public Game(string difficulty, bool sound)
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




            GameUpdate(player, squad);
        }


        public void GameUpdate(Player player, Squad squad)
        {
            int timeCounter = 0;
            while (this._game)
            {
               
                 InputPlayer(player);

              
                
                timeCounter++;
                if(timeCounter == 5000)
                {
                    squad.CheckBorder();
                    squad.EnnemiMovement();
                    timeCounter = 0;
                    
                }

            }


                //Thread.Sleep(1000);
        }
           


        

        public void InputPlayer(Player player)
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
            }

            
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
    }
}
