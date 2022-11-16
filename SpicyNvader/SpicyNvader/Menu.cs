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

        private const string RETOUR = @"



                     ___  ______________  __  _____ 
                    / _ \/ __/_  __/ __ \/ / / / _ \
                   / , _/ _/  / / / /_/ / /_/ / , _/
                  /_/|_/___/ /_/  \____/\____/_/|_|  ";

        private static string[] oui = new string[4]
        {
            "   _____  __  ______ ",
            "  / __  // / / /  _/ ",
            " / /_/ // /_/ // /   ",
            "/_____//_____/___/   ",

        };

        private static string[] non = new string[4]
        {
            "    _  ______  _  __ ",
            "   / |/ / __  / |/ / ",
            "  /    / /_/ /    /  ",
            " /_/|_/|____/_/|_/   ",
        };


        private static string[] slash = new string[4]
        {
            "       __",
            "    _/_/ ",
            " _/_/    ",
            "/_/      ",
        };

        private static string[] jedi = new string[4]
        {
            "     _________ ____  ",
            " __ / / __/ _  /  _/ ",
            "/ // / _// // // /   ",
            " ___/___/____/___/   ",
        };

        private static string[] padawan = new string[4]
        {
            "   ___  ___   ___  ___ _      _____   _  __",
            "  / _ |/ _ | / _ |/ _ | | /| / / _ | / |/ /",
            " / ___/ __ |/ // / __ | |/ |/ / __ |/    / ",
            "/_/  /_/ |_/____/_/ |_|__/|__/_/ |_/_/|_/  ",


        };






        public int CursorPosX = 64;
        public int CursorPosY = 3;
        public int difficulty = 1; // difficulty dépendra du choix dans les options 
        public int sound = 1;      // "
        public int[] arrOption = new int[2];

        public void MainMenu()
        {
            MainMenuDisplay();


            int arrowPosBase = 0;
            int arrowPos = Input(arrowPosBase,64,3, 23, 3, 5);
            
            

            switch(arrowPos)
            {
                case 0:
                    StartGame();
                    break;
                case 1:
                    Console.Clear();
                    ShowOption();
                    
                    break;
                case 2:
                    Console.Clear();
                    ShowHighScore();
                    break;
                case 3:
                    Console.Clear();
                    ShowAbout();
                    break;
                case 4:
                    Console.Clear();
                    ShowExit();
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
            for (int i = 0; i < jedi.Length; i++)
            {
                if (this.difficulty == 0)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(5, 7 + i);
                Console.Write(jedi[i]);
                Console.ForegroundColor = ConsoleColor.White;
            }

            for (int i = 0; i < padawan.Length; i++)
            {
                if (this.difficulty == 1)
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(25, 7 + i);
                Console.Write(padawan[i]);
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine(SOUND);


            for(int i = 0; i < oui.Length; i++)
            {
                if (this.sound == 0)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(13, 20 + i);
                Console.Write(oui[i]);
                Console.ForegroundColor = ConsoleColor.White;
            }

            for (int i = 0; i < non.Length; i++)
            {
                if (this.sound == 1)
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(35, 20 + i);
                Console.Write(non[i]);
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine(RETOUR);

        }

        public int Input(int arrowPos, int cursorPoseX, int cursorPoseY, int CursorPosYMax, int CursorPosYMin, int interval)
        {
            while(true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);


                if (key.Key == ConsoleKey.DownArrow && cursorPoseY < CursorPosYMax)
                {
                    Console.SetCursorPosition(cursorPoseX - 3, cursorPoseY);
                    Console.Write("       ");
                    cursorPoseY += interval;
                    Console.SetCursorPosition(cursorPoseX, cursorPoseY);
                    Console.Write("<---");
                    arrowPos++;
                }
                else if(key.Key == ConsoleKey.UpArrow && cursorPoseY > CursorPosYMin)
                {
                    Console.SetCursorPosition(cursorPoseX - 3, cursorPoseY);
                    Console.Write("       ");
                    cursorPoseY -= interval;
                    Console.SetCursorPosition(cursorPoseX, cursorPoseY);
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

            Game game = new Game(this.difficulty, this.sound);
            game.StartGame();


        }


        public void ShowOption()
        {
            int yCursor = 3;
            int arrowPose = 0;
            bool option = true;
            while (option)
            {

                
                OptionMenuDisplay();
                Console.SetCursorPosition(64, yCursor);
                Console.Write("<---");
                

                switch (Input(arrowPose, 64,yCursor, 29, 3, 13))
                {
                    case 0:
                        if (this.difficulty == 0)
                            this.difficulty = 1;
                        else
                            this.difficulty = 0;
                        yCursor = 3;
                        arrowPose = 0;

                        Console.Clear();
                        break;
                    case 1:
                        if (this.sound == 0)
                            this.sound = 1;
                        else
                            this.sound = 0;

                        yCursor = 16;
                        arrowPose = 1;


                        Console.Clear();
                        break;
                    case 2:
                        option = false;
                        break;
                        

                }
                
            }
            Console.Clear();
            MainMenu();






        }

        public void ShowHighScore()
        {

        }

        public void ShowAbout()
        {

        }

        public void ShowExit()
        {

        }



    }
}
