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
        private static string[] _symbol = new string[5] 
        {
               "  ▀▄   ▄▀  ",
               " ▄█▀███▀█▄ ",
               "█▀███████▀█",
               "█ █▀▀▀▀▀█ █",
               "   ▀▀ ▀▀   ",
        };
        private static string[] _void = new string[5]
        {
               "          ",
               "          ",
               "          ",
               "          ",
               "          ",
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

            GameUpdate(player);
        }


        public void GameUpdate(Player player)
        {
            Console.SetCursorPosition(player.X, player.Y);
            Console.Write("O");

            while (this._game)
            {

                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.RightArrow) 
                {
                    Console.SetCursorPosition(player.X, player.Y);
                    Console.Write(" ");
                    player.X += player.Speed;
                    Console.SetCursorPosition(player.X, player.Y);
                    Console.Write("O");

                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    Console.SetCursorPosition(player.X, player.Y);
                    Console.Write(" ");
                    player.X -= player.Speed;
                    Console.SetCursorPosition(player.X, player.Y);
                    Console.Write("O");

                }


                //Thread.Sleep(1000);
            }
           


        }
    }
}
