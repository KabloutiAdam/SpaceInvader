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

        private const string DIFFICULTY = @"
               ___  _______________________  ____ __________
              / _ \/  _/ __/ __/  _/ ___/ / / / //_  __/ __/
             / // // // _// _/_/ // /__/ /_/ / /__/ / / _/  
            /____/___/_/ /_/ /___/\___/\____/____/_/ /___/  
                                               ";

        private const string SOUND = @"
                               ________  _  __
                              / __/ __ \/ |/ /
                             _\ \/ /_/ /    / 
                            /___/\____/_/|_/ ";

        private static string[] oui = new string[4]
        {
            "  ____   __  ______",
            " / __/  / / / /  _/",
            "/ /_/  / /_/ // /  ",
            " ____/ ____/ ___/   ",

        };

        private static string[] non = new string[4]
        {
            "    _  ______  _  __ ",
            "   / |/ / __  / |/ / ",
            "  /    / /_/ /    /  ",
            " /_/|_/ ____/_/|_/   ",
        };


        private static string[] slash = new string[4]
        {
            "       __",
            "    _/_/ ",
            " _/_/    ",
            "/_/      ",
        };
                            
                                       


        public int CursorPosX = 64;
        public int CursorPosY = 3;
        public int difficulty = 0; // difficulty dépendra du choix dans les options 
        public int sound = 0;      // "
        public int[] arrOption = new int[2];

        public void MainMenu()
        {
            MainMenuDisplay();


            int arrowPosBase = 0;
            int arrowPos = Input(arrowPosBase,64, 23, 3);
            
            

            switch(arrowPos)
            {
                case 0:
                    StartGame();
                    break;
                case 1:
                    Console.Clear();
                    arrOption = ShowOption(difficulty, sound);
                    difficulty = arrOption[0];
                    sound = arrOption[1];
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
        public void OptionMenuDisplay()
        {
            Console.WriteLine(DIFFICULTY);
            Console.WriteLine(SOUND);


            for(int i = 0; i < oui.Length; i++)
            {
                if (sound == 0)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(13, 15 + i);
                Console.Write(oui[i]);
            }

            for (int i = 0; i < non.Length; i++)
            {
                if (sound == 1)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(35, 15 + i);
                Console.Write(non[i]);
            }


        }

        public int Input(int arrowPos, int cursorPoseX, int CursorPosYMax, int CursorPosYMin)
        {
            while(true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);


                if (key.Key == ConsoleKey.DownArrow && CursorPosY < CursorPosYMax)
                {
                    Console.SetCursorPosition(cursorPoseX - 3, CursorPosY);
                    Console.Write("       ");
                    CursorPosY += 5;
                    Console.SetCursorPosition(cursorPoseX, CursorPosY);
                    Console.Write("<---");
                    arrowPos++;
                }
                else if(key.Key == ConsoleKey.UpArrow && CursorPosY > CursorPosYMin)
                {
                    Console.SetCursorPosition(cursorPoseX - 3, CursorPosY);
                    Console.Write("       ");
                    CursorPosY -= 5;
                    Console.SetCursorPosition(cursorPoseX, CursorPosY);
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


        public int[] ShowOption(int difficulty, int sound)
        {

            OptionMenuDisplay();
            switch(Input(0, 64, 23, 3))
            {
                case 1:
                    OptionMenuDisplay();
                    break;
            }

            int[] option = new int[2];




            return option;
        }



    }
}
