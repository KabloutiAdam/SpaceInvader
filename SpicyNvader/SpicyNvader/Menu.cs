﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

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

        /// <summary>
        /// Const texte "SPACE INVADER" en ascii font
        /// </summary>
        private const string TITLE = @"
   ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄       ▄▄▄▄▄▄▄▄▄▄▄  ▄▄        ▄  ▄               ▄  ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄   ▄▄▄▄▄▄▄▄▄▄▄  ▄▄▄▄▄▄▄▄▄▄▄ 
  ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     ▐░░░░░░░░░░░▌▐░░▌      ▐░▌▐░▌             ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░▌ ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌
  ▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀▀▀       ▀▀▀▀█░█▀▀▀▀ ▐░▌░▌     ▐░▌ ▐░▌           ▐░▌ ▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀█░▌
  ▐░▌          ▐░▌       ▐░▌▐░▌       ▐░▌▐░▌          ▐░▌                    ▐░▌     ▐░▌▐░▌    ▐░▌  ▐░▌         ▐░▌  ▐░▌       ▐░▌▐░▌       ▐░▌▐░▌          ▐░▌       ▐░▌
  ▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄█░▌▐░▌          ▐░█▄▄▄▄▄▄▄▄▄           ▐░▌     ▐░▌ ▐░▌   ▐░▌   ▐░▌       ▐░▌   ▐░█▄▄▄▄▄▄▄█░▌▐░▌       ▐░▌▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄█░▌
  ▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌▐░▌          ▐░░░░░░░░░░░▌          ▐░▌     ▐░▌  ▐░▌  ▐░▌    ▐░▌     ▐░▌    ▐░░░░░░░░░░░▌▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌
   ▀▀▀▀▀▀▀▀▀█░▌▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀▀▀▀█░▌▐░▌          ▐░█▀▀▀▀▀▀▀▀▀           ▐░▌     ▐░▌   ▐░▌ ▐░▌     ▐░▌   ▐░▌     ▐░█▀▀▀▀▀▀▀█░▌▐░▌       ▐░▌▐░█▀▀▀▀▀▀▀▀▀ ▐░█▀▀▀▀█░█▀▀ 
            ▐░▌▐░▌          ▐░▌       ▐░▌▐░▌          ▐░▌                    ▐░▌     ▐░▌    ▐░▌▐░▌      ▐░▌ ▐░▌      ▐░▌       ▐░▌▐░▌       ▐░▌▐░▌          ▐░▌     ▐░▌  
   ▄▄▄▄▄▄▄▄▄█░▌▐░▌          ▐░▌       ▐░▌▐░█▄▄▄▄▄▄▄▄▄ ▐░█▄▄▄▄▄▄▄▄▄       ▄▄▄▄█░█▄▄▄▄ ▐░▌     ▐░▐░▌       ▐░▐░▌       ▐░▌       ▐░▌▐░█▄▄▄▄▄▄▄█░▌▐░█▄▄▄▄▄▄▄▄▄ ▐░▌      ▐░▌ 
  ▐░░░░░░░░░░░▌▐░▌          ▐░▌       ▐░▌▐░░░░░░░░░░░▌▐░░░░░░░░░░░▌     ▐░░░░░░░░░░░▌▐░▌      ▐░░▌        ▐░▌        ▐░▌       ▐░▌▐░░░░░░░░░░▌ ▐░░░░░░░░░░░▌▐░▌       ▐░▌
   ▀▀▀▀▀▀▀▀▀▀▀  ▀            ▀         ▀  ▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀       ▀▀▀▀▀▀▀▀▀▀▀  ▀        ▀▀          ▀          ▀         ▀  ▀▀▀▀▀▀▀▀▀▀   ▀▀▀▀▀▀▀▀▀▀▀  ▀         ▀ ";

        /// <summary>
        /// Const texte "JOUER" en ascii font
        /// </summary>
        private const string PLAY = @"
                                                                             ______  __  _________ 
                                                                         __ / / __ \/ / / / __/ _ \
                                                                        / // / /_/ / /_/ / _// , _/
                                                                        \___/\____/\____/___/_/|_|";

        /// <summary>
        /// Const texte "OPTION" en ascii font
        /// </summary>
        private const string OPTION = @"
                                                                       ____  ___  ______________  _  __
                                                                      / __ \/ _ \/_  __/  _/ __ \/ |/ /
                                                                     / /_/ / ___/ / / _/ // /_/ /    / 
                                                                     \____/_/    /_/ /___/\____/_/|_/  ";

        /// <summary>
        /// Const texte "HIGHSCORE" en ascii font
        /// </summary>
        private const string HIGHSCORE = @"
                                                                  __ _____________ _______________  ___  ____
                                                                 / // /  _/ ___/ // / __/ ___/ __ \/ _ \/ __/
                                                                / _  // // (_ / _  /\ \/ /__/ /_/ / , _/ _/  
                                                               /_//_/___/\___/_//_/___/\___/\____/_/|_/___/  ";

        /// <summary>
        /// Const texte "A PROPOS" en ascii font
        /// </summary>
        private const string APROPOS = @"
                                                                   ___     ___  ___  ____  ___  ____  ____
                                                                  / _ |   / _ \/ _ \/ __ \/ _ \/ __ \/ __/
                                                                 / __ |  / ___/ , _/ /_/ / ___/ /_/ /\ \  
                                                                /_/ |_| /_/  /_/|_|\____/_/   \____/___/  ";

        /// <summary>
        /// Const texte "EXIT" en ascii font
        /// </summary>
        private const string EXIT = @"
                                                                            _____  ____________
                                                                           / __/ |/_/  _/_  __/
                                                                          / _/_>  <_/ /  / /   
                                                                         /___/_/|_/___/ /_/    ";

        

        /// <summary>
        /// Const texte "DIFFICULTE" en ascii font
        /// </summary>
        private const string DIFFICULTY = @"
                                                                ___  _______________________  ____ __________
                                                               / _ \/  _/ __/ __/  _/ ___/ / / / //_  __/ __/
                                                              / // // // _// _/_/ // /__/ /_/ / /__/ / / _/  
                                                             /____/___/_/ /_/ /___/\___/\____/____/_/ /___/  
                                                                                               ";

        /// <summary>
        /// Const texte "SON" en ascii font
        /// </summary>
        private const string SOUND = @"



                                                                            ________  _  __
                                                                           / __/ __ \/ |/ /
                                                                          _\ \/ /_/ /    / 
                                                                         /___/\____/_/|_/ ";

        /// <summary>
        /// Const texte "RETOUR" en ascii font
        /// </summary>
        private const string RETOUR = @"



                                                                   ___  ______________  __  _____ 
                                                                  / _ \/ __/_  __/ __ \/ / / / _ \
                                                                 / , _/ _/  / / / /_/ / /_/ / , _/
                                                                /_/|_/___/ /_/  \____/\____/_/|_|  ";


        /// <summary>
        /// Tableau de string "<---" en ascii font
        /// </summary>
        private static string[] arrow = new string[4]
        {
            "    __              ",
            "   / /___  ___  ___ ",
            "  < <(___)(___)(___)",
            "   |_|              ",
        };

        /// <summary>
        /// Tableau de vide remplacant la flèche en ascii font
        /// </summary>
        private static string[] voidArrow = new string[4]
       {
            "                    ",
            "                    ",
            "                    ",
            "                    ",
       };



        /// <summary>
        /// Tableau de string "OUI" en ascii font
        /// </summary>
        private static string[] oui = new string[4]
        {
            "   _____  __  ______ ",
            "  / __  // / / /  _/ ",
            " / /_/ // /_/ // /   ",
            "/_____//_____/___/   ",

        };

        /// <summary>
        /// Tableau de string "NON" en ascii font
        /// </summary>
        private static string[] non = new string[4]
        {
            "    _  ______  _  __ ",
            "   / |/ / __  / |/ / ",
            "  /    / /_/ /    /  ",
            " /_/|_/|____/_/|_/   ",
        };


        /// <summary>
        /// Tableau de string "/" en ascii font
        /// </summary>
        private static string[] slash = new string[4]
        {
            "       __",
            "    _/_/ ",
            " _/_/    ",
            "/_/      ",
        };

        /// <summary>
        /// Tableau de string "JEDI" en ascii font
        /// </summary>
        private static string[] jedi = new string[4]
        {
            "     _________ ____  ",
            " __ / / __/ _  /  _/ ",
            "/ // / _// // // /   ",
            " ___/___/____/___/   ",
        };

        /// <summary>
        /// Tableau de string "PADAWAN" en ascii font
        /// </summary>
        private static string[] padawan = new string[4]
        {
            "   ___  ___   ___  ___ _      _____   _  __",
            "  / _ |/ _ | / _ |/ _ | | /| / / _ | / |/ /",
            " / ___/ __ |/ // / __ | |/ |/ / __ |/    / ",
            "/_/  /_/ |_/____/_/ |_|__/|__/_/ |_/_/|_/  ",


        };


        /// <summary>
        /// Position X du curseur
        /// </summary>
        public int CursorPosX = 110;

        /// <summary>
        /// Position Y du curseur
        /// </summary>
        public int CursorPosY = 13;

        /// <summary>
        /// Difficulté de la partie. 0 = Facile / 1 = Difficile
        /// </summary>
        public int difficulty = 0; 

        /// <summary>
        /// Son de la partie. 0 = activé / 1 = désactivé
        /// </summary>
        public int sound = 0;   
        
        /// <summary>
        /// Tableau qui contient les options du jeu (difficulté et son)
        /// </summary>
        public int[] arrOption = new int[2];

        /// <summary>
        /// Pseudo du joueur
        /// </summary>
        private string pseudo;

        /// <summary>
        /// List de type string qui contient le top 10 des meilleurs scores
        /// </summary>
        private List<string> listHighscore = new List<string>();




        #region Menu
        /// <summary>
        /// Menu du jeu
        /// </summary>
        public void MainMenu()
        {
            while (true)
            {
                MainMenuDisplay();


                int arrowPosBase = 0;
                int arrowPos = Input(arrowPosBase, 110, 13, 33, 13, 5);


                // Regarde quelle sur quelle position de la flèche lors de l'entrée de la touche "Enter"
                switch (arrowPos)
                {
                    case 0: // Option : Jouer
                        InsertPseudo();
                        break;
                    case 1: // Option : Option
                        Console.Clear();
                        ShowOption();
                        break;
                    case 2: // Option : Highscore
                        Console.Clear();
                        ShowHighScore();
                        break;
                    case 3: // Option : A propos
                        Console.Clear();
                        ShowAbout();
                        break;
                    case 4: // Option : Exit
                        Console.Clear();
                        ShowExit();
                        break;
                }
            }
           
        }


        /// <summary>
        /// Affiche le menu principal
        /// </summary>
        public void MainMenuDisplay()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(TITLE);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(PLAY);
            Console.WriteLine(OPTION);
            Console.WriteLine(HIGHSCORE);
            Console.WriteLine(APROPOS);
            Console.WriteLine(EXIT);

            Console.SetCursorPosition(CursorPosX, CursorPosY);
            for (int i = 0; i < arrow.Length; i++)
            {
                Console.SetCursorPosition(CursorPosX, CursorPosY + i);
                Console.Write(arrow[i]);
            }
            Console.SetCursorPosition(1, 48);
            Console.WriteLine("Version 1.0");
        }

        /// <summary>
        /// Méthode qui gère les inputs du joueur dans les menus
        /// </summary>
        /// <param name="arrowPos"> position de départ de la flèche (0, 1, 2...) </param>
        /// <param name="cursorPoseX"> Position X de la flèch e</param>
        /// <param name="cursorPoseY"> Position Y de départ de la flèche </param>
        /// <param name="CursorPosYMax"> Position Y maximum de la flèche </param>
        /// <param name="CursorPosYMin"> Position Y minimum de la flèche </param>
        /// <param name="interval"> Le nombre de ligne entre chaque option (nb de ligne du saut de la flèche) </param>
        /// <returns> Retourne la position de la flèche lors de l'appuie de "Enter" </returns>
        public int Input(int arrowPos, int cursorPoseX, int cursorPoseY, int CursorPosYMax, int CursorPosYMin, int interval)
        {
            while (true)
            {
                //Regarde quelle touche à été appuyée
                ConsoleKeyInfo key = Console.ReadKey(true);

                //Si touche = flèche du bas
                if (key.Key == ConsoleKey.DownArrow && cursorPoseY < CursorPosYMax)
                {

                    DrawArrow(cursorPoseX, cursorPoseY, interval);
                    cursorPoseY += interval;
                    arrowPos++;
                }
                //Si touche = flèche du haut
                else if (key.Key == ConsoleKey.UpArrow && cursorPoseY > CursorPosYMin)
                {
                    DrawArrow(cursorPoseX, cursorPoseY, -interval);
                    cursorPoseY -= interval;
                    arrowPos--;
                }
                //si flèche = Enter
                else if (key.Key == ConsoleKey.Enter)
                {
                    return arrowPos;
                }


            }


        }

        /// <summary>
        /// Méthode qui efface l'ancienne flèche et qui la redessine au nouvel endroit
        /// </summary>
        /// <param name="poseX"> Position X de l'ancienne flèche</param>
        /// <param name="poseY"> Position Y de l'ancienne flèche</param>
        /// <param name="interval"> intervale de ligne entre l'ancienne et la nouvelle flèche</param>
        public void DrawArrow(int poseX, int poseY, int interval)
        {


            for (int i = 0; i < voidArrow.Length; i++)
            {
                Console.SetCursorPosition(poseX, poseY + i);
                Console.Write(voidArrow[i]);
            }

            poseY += interval;

            for (int i = 0; i < arrow.Length; i++)
            {
                Console.SetCursorPosition(poseX, poseY + i);
                Console.Write(arrow[i]);
            }
        }


        #endregion


        #region Option
        /// <summary>
        /// Affiche le menu des options 
        /// </summary>
        public void OptionMenuDisplay()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(DIFFICULTY);
            Console.ForegroundColor = ConsoleColor.White;

            //Affiche le texte de la difficulté en couleur selon la difficulté (padawan : vert / jedi : rouge)
            for (int i = 0; i < jedi.Length; i++)
            {
                if (this.difficulty == 1)
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(95, 7 + i);
                Console.Write(jedi[i]);
                Console.ForegroundColor = ConsoleColor.White;
            }

            for (int i = 0; i < padawan.Length; i++)
            {
                if (this.difficulty == 0)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(40, 7 + i);
                Console.Write(padawan[i]);
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(SOUND);
            Console.ForegroundColor = ConsoleColor.White;

            
            //Affiche le texte de le son en couleur selon le son (oui : vert / non : rouge)
            for (int i = 0; i < oui.Length; i++)
            {
                if (this.sound == 0)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(53, 20 + i);
                Console.Write(oui[i]);
                Console.ForegroundColor = ConsoleColor.White;
            }

            for (int i = 0; i < non.Length; i++)
            {
                if (this.sound == 1)
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                Console.SetCursorPosition(87, 20 + i);
                Console.Write(non[i]);
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(RETOUR);
            Console.ForegroundColor = ConsoleColor.White;

        }


        /// <summary>
        /// Méthode qui ouvre le menu des options
        /// </summary>
        public void ShowOption()
        {
            int yCursor = 1;
            int arrowPose = 0;
            bool option = true;
            while (option)
            {


                OptionMenuDisplay();
                
                for (int i = 0; i < arrow.Length; i++)
                {
                    Console.SetCursorPosition(114, yCursor + i);
                    Console.Write(arrow[i]);
                }

                //Regarder quelle option a été sélectionnée
                switch (Input(arrowPose, 114, yCursor, 27, 3, 13))
                {
                    case 0: // Option : Difficulté
                        if (this.difficulty == 0)
                            this.difficulty = 1;
                        else
                            this.difficulty = 0;
                        yCursor = 1;
                        arrowPose = 0;

                        Console.Clear();
                        break;
                    case 1: // Option : Son
                        if (this.sound == 0)
                            this.sound = 1;
                        else
                            this.sound = 0;

                        yCursor = 14;
                        arrowPose = 1;


                        Console.Clear();
                        break;
                    case 2: // Option : Retour
                        option = false;
                        break;


                }

            }
            Console.Clear();

            //Retourne au menu principal
            MainMenu();
        }

        #endregion


        #region Jouer

        /// <summary>
        /// Méthode pour commencer la partie
        /// </summary>
        public void StartGame(string pseudo)
        {
            
            Console.Clear();
            Console.SetWindowSize(170, 60);
            Console.BufferHeight = 60;
            Console.BufferWidth = 170;


            Console.CursorVisible = false;

            //Instancie l'objet "Game" avec comme paramètre les options de la partie
            Game game = new Game(this.difficulty, this.sound, pseudo);
            game.StartGame();

            
            DisplayScore(game.Score, game.PseudoPlayer);


        }

        /// <summary>
        /// Page d'affichage pour que le joueur entre son pseudo
        /// </summary>
        public void InsertPseudo()
        {
            bool checkPseudo = true;
            string allowedCharacter = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_";
            string specialCharacterError = "Les caractères autre que alphabétiques, numériques ainsi que le '_' sont interdits";
            string toMuchCharacterError = "Veuillez ne pas entrer plus de 14 caractères";
            string notEnoughCharacterError = "Veuillez entrer au moins 2 charactères";
            do
            {
                
                Console.Clear();
                checkPseudo = true;
                Console.SetCursorPosition(50, 23);
                Console.Write("Entrez votre pseudo : ");
                Console.SetCursorPosition(77, 23);


                pseudo = Console.ReadLine();
                
                foreach (char c in pseudo)
                {
                    if(!allowedCharacter.Contains(c.ToString()))
                    {
                        checkPseudo = false;
                        

                        for(int i = 0; i < specialCharacterError.Length; i++)
                        {
                            Console.SetCursorPosition(50 + i, 27);
                            Console.Write(specialCharacterError[i]);
                            Thread.Sleep(10);
                        }
                        Thread.Sleep(1000);
                        break;
                    }
                }

                if(pseudo.Length > 14)
                {
                    checkPseudo = false;
                    for (int i = 0; i < toMuchCharacterError.Length; i++)
                    {
                        Console.SetCursorPosition(50 + i, 27);
                        Console.Write(toMuchCharacterError[i]);
                        Thread.Sleep(10);
                    }
                    Thread.Sleep(1000);
                }
                else if (pseudo.Length < 3)
                {
                    checkPseudo = false;
                    for (int i = 0; i < notEnoughCharacterError.Length; i++)
                    {
                        Console.SetCursorPosition(50 + i, 27);
                        Console.Write(notEnoughCharacterError[i]);
                        Thread.Sleep(10);
                    }
                    Thread.Sleep(1000);
                }
                
                   
              

                

            } while (!checkPseudo);
            

            StartGame(pseudo);
        }


        public void DisplayScore(int score, string pseudoPlayer)
        {



            

            Console.SetCursorPosition(70, 25);
            Console.WriteLine("Partie terminée");
            Console.SetCursorPosition(70, 27);
            Console.WriteLine("Joueur : " + pseudoPlayer);
            Console.SetCursorPosition(70, 29);
            Console.WriteLine("Score final : {0} point(s)", score);
            if (score > GetHighestScore())
            {
                Console.WriteLine("FELICITATION VOUS VENEZ DE BATTRE LE MEILLEUR SCORE");
                
            }

            listHighscore.Clear();

            foreach (string line in System.IO.File.ReadLines("../../../HighestScore.txt"))
            {
                listHighscore.Add(line);

            }

            if(listHighscore.Count < 10)
            {
                listHighscore.Add(pseudoPlayer + ";" + score);

                


            }
            else if(score > Convert.ToInt32(listHighscore.Last().Split(';').Last()))
            {
                listHighscore[listHighscore.Count() - 1] = pseudoPlayer + ";" +score.ToString();
            }

            listHighscore.Sort(new ScoreComparer());

            // Print the sorted list.

            System.IO.File.WriteAllLines("../../../HighestScore.txt", listHighscore);


            Console.SetCursorPosition(65,35);
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();
            Console.Clear();

        }

        #endregion


        #region Highscore
        /// <summary>
        /// Methode qui ouvre le menu "Highscore"
        /// </summary>
        public void ShowHighScore()
        {

            //string highestScoreInfo = System.IO.File.ReadLines("../../../HighestScore.txt").First();




            int yPose = 15;
            int position = 1;

            foreach (string line in System.IO.File.ReadLines("../../../HighestScore.txt"))
            {
                
                string name = line.Split(';').First();
                string score = line.Split(';').Last();

                Console.SetCursorPosition(70, yPose++);
                Console.Write(position++ + ") " + name + " " + score);

                yPose++;
            }

            Console.SetCursorPosition(1, 49);
            Console.WriteLine("Bounton \"Escape\" pour retourner au menu principal");

            while(true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if(key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    MainMenu();
                }
            }
        }

        public int GetHighestScore()
        {
            string highestScoreInfo = System.IO.File.ReadLines("../../../HighestScore.txt").First();
            string highestScoreName = highestScoreInfo.Split(';').First();
            string highestScoreScore = highestScoreInfo.Split(';').Last();

            return Convert.ToInt32(highestScoreScore);
        }

        #endregion


        #region About
        /// <summary>
        /// Méthode qui ouvre le menu "A propos"
        /// </summary>
        public void ShowAbout()
        {
            Console.Clear();

            Console.SetCursorPosition(0,1);
            Console.WriteLine("Adam Kablouti CIN2A");
            Console.SetCursorPosition(1, 49);
            Console.WriteLine("Bounton \"Escape\" pour retourner au menu principal");

            string textAbout = "Ce Space Invader est un projet de développement dans le cadre de l'apprentissage en informatique à l'ETML. Cette réédition doit contenir la plupart des fonctionnalités de base comme : Un menu option, un menu Highscore qui affiche le nom des 10 meilleurs joueurs, cette page 'à propos' qui décrit le projet, un bouton 'Quitter', aisni que le bouton 'jouer' Pour lancer une partie";

            for (int i = 0; i < 48; i++)
            {
                Console.SetCursorPosition(67 + i, 10);
                Console.Write(textAbout[i]);
                Thread.Sleep(10);
            }

            for (int i = 48; i < 97; i++)
            {
                Console.SetCursorPosition(67 + i - 48, 11);
                Console.Write(textAbout[i]);
                Thread.Sleep(10);
            }

            for (int i = 97; i < 137; i++)
            {
                Console.SetCursorPosition(67 + i - 97, 12);
                Console.Write(textAbout[i]);
                Thread.Sleep(10);
            }
            

            for (int i = 137; i < 184; i++)
            {
                Console.SetCursorPosition(67 + i - 137, 13);
                Console.Write(textAbout[i]);
                Thread.Sleep(10);
            }

            for (int i = 184; i < 230; i++)
            {
                Console.SetCursorPosition(67 + i - 184, 14);
                Console.Write(textAbout[i]);
                Thread.Sleep(10);
            }

            for (int i = 230; i < 274; i++)
            {
                Console.SetCursorPosition(67 + i - 230, 15);
                Console.Write(textAbout[i]);
                Thread.Sleep(10);
            }

            for (int i = 274; i < 317; i++)
            {
                Console.SetCursorPosition(67 + i - 274, 16);
                Console.Write(textAbout[i]);
                Thread.Sleep(10);
            }

            for (int i = 317; i < 368; i++)
            {
                Console.SetCursorPosition(67 + i - 317, 17);
                Console.Write(textAbout[i]);
                Thread.Sleep(10);
            }

            for (int i = 368; i < 378; i++)
            {
                Console.SetCursorPosition(67 + i - 368, 18);
                Console.Write(textAbout[i]);
                Thread.Sleep(10);
            }

            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            } while (key.Key != ConsoleKey.Escape);
            

            

            Console.Clear();
        }

        #endregion


        #region Exit
        /// <summary>
        /// Méthode qui quitte le jeu
        /// </summary>
        public void ShowExit()
        {
            Environment.Exit(0);
        }

        #endregion

    }
}
