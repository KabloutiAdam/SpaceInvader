using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyNvader
{
    public class Menu
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Menu()
        {

        }



        private const string PLAY = @"
                             ______  __  _________ 
                         __ / / __ \/ / / / __/ _ \
                        / // / /_/ / /_/ / _// , _/
                        \___/\____/\____/___/_/|_|";

        private const string OPTION = @"
                      ____  ___  ______________  _  __
                     / __ \/ _ \/_  __/  _/ __ \/ |/ /
                    / /_/ / ___/ / / _/ // /_/ /    / 
                    \____/_/    /_/ /___/\____/_/|_/  ";

        private const string HIGHSCORE = @"
                   __ _____________ _______________  ___  ____
                  / // /  _/ ___/ // / __/ ___/ __ \/ _ \/ __/
                 / _  // // (_ / _  /\ \/ /__/ /_/ / , _/ _/  
                /_//_/___/\___/_//_/___/\___/\____/_/|_/___/  ";

        private const string APROPOS = @"
                   ___     ___  ___  ____  ___  ____  ____
                  / _ |   / _ \/ _ \/ __ \/ _ \/ __ \/ __/
                 / __ |  / ___/ , _/ /_/ / ___/ /_/ /\ \  
                /_/ |_| /_/  /_/|_|\____/_/   \____/___/  ";

        private const string EXIT = @"
                           _____  ____________
                          / __/ |/_/  _/_  __/
                         / _/_>  <_/ /  / /   
                        /___/_/|_/___/ /_/    ";

        private const string ARROW = @"     
              __              
             / /___  ___  ___ 
            < <(___)(___)(___)
             \_\              ";



        public int CursorPosX = 64;
        public int CursorPosY = 3;
        public string difficulty = "normal"; // difficulty dépendra du choix dans les options 
        public bool sound = false; // "

        public void MainMenu()
        {
            MainMenuDisplay();

            int arrowPosBase = 0;
            int arrowPos = Input(arrowPosBase);

            switch(arrowPos)
            {
                case 0:
                    StartGame();
                    break;
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
            }
        }

        /// <summary>
        /// Display Menu
        /// </summary>
        public void MainMenuDisplay()
        {
            Console.WriteLine(PLAY);
            Console.WriteLine(OPTION);
            Console.WriteLine(HIGHSCORE);
            Console.WriteLine(APROPOS);
            Console.WriteLine(EXIT);

            Console.SetCursorPosition(CursorPosX, CursorPosY);
            Console.Write("<---");
        }

        public int Input(int arrowPos)
        {
            while(true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);


                if (key.Key == ConsoleKey.DownArrow && CursorPosY < 23)
                {
                    Console.SetCursorPosition(CursorPosX - 3, CursorPosY);
                    Console.Write("       ");
                    CursorPosY += 5;
                    Console.SetCursorPosition(CursorPosX, CursorPosY);
                    Console.Write("<---");
                    arrowPos++;
                }
                else if(key.Key == ConsoleKey.UpArrow && CursorPosY > 3)
                {
                    Console.SetCursorPosition(CursorPosX - 3, CursorPosY);
                    Console.Write("       ");
                    CursorPosY -= 5;
                    Console.SetCursorPosition(CursorPosX, CursorPosY);
                    Console.Write("<---");
                    arrowPos--;
                }
                else if(key.Key == ConsoleKey.Enter)
                {
                    return arrowPos;
                }

                
            }
            

        }
        

        public void StartGame()
        {
            Console.Clear();

            Console.SetWindowSize(130, 50);
            Console.BufferHeight = 50;
            Console.BufferWidth = 130;

            Console.CursorVisible = false;

            Game game = new Game(difficulty, sound);
            game.StartGame();


        }






    }
}
