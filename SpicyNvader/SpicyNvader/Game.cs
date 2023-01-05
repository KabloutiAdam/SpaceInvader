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
        /// Vitesse de l'enemy
        /// </summary>
        private int _enemySpeed;

        /// <summary>
        /// Score du jouer
        /// </summary>
        private int _score = 0;

        /// <summary>
        /// Pseudo entré du joueur
        /// </summary>
        private string _pseudoPlayer;

        /// <summary>
        /// Nombre de vie du joueur
        /// </summary>
        private int _numberOfLives = 3;
        

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
        /// Const counter refresh des enemy
        /// </summary>
        private const int ENEMYCOUNTERMAX = 1200;

        /// <summary>
        /// Const counter refresh de bullets
        /// </summary>
        private const int BULLETCOUNTERMAX = 250;

        /// <summary>
        /// const Temps recharge de tir du joueur
        /// </summary>
        private const int PLAYERSHOOTINGRECOILMAX = 5000;


        /// <summary>
        /// Limite de la console à droite
        /// </summary>
        private const int PLAYERBORDERLIMITRIGHT = 155;

        /// <summary>
        /// Limite de la console à gauche
        /// </summary>
        private const int PLAYERBORDERLIMITLEFT = 1;

        private string _gameOverText = "vous etes mort, dopmmage ";

        
        /// <summary>
        /// Getter Setter du pseudo du joueur
        /// </summary>
        public string PseudoPlayer
        {
            get { return _pseudoPlayer; }
            set { _pseudoPlayer = value; }
        }

        /// <summary>
        /// Getter Setter du score
        /// </summary>
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }



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
        public Game(int difficulty, int sound, string pseudo)
        {
            this._difficulty = difficulty;
            this._sound = sound;
            this._pseudoPlayer = pseudo;
            
        }


        /// <summary>
        /// Méthode qui démarre le jeu 
        /// </summary>
        public void StartGame()
        {
            // Instancie le joueur
            Player player = new Player();
            StartOfGame(player);
            EndOfGame();
        }


        /// <summary>
        /// Méthode qui initie la parite
        /// </summary>
        /// <param name="player"></param>
        public void StartOfGame(Player player)
        {
            this._game = true;

            // Regarde les paramètre de la partie
            if (_difficulty == 1)
            {
                _numberOfEnemyByRow = 8;
                _numberOfRow = 3;
                _enemySpeed = 2;
            }
            else
            {
                _numberOfEnemyByRow = 5;
                _numberOfRow = 3;
                _enemySpeed = 1;
            }


            /* ------- Créer les murs ---------*/

            List<Wall> wallList = new List<Wall>();
            for(int i = 0; i < 6; i++)
            {
                Wall wall = new Wall(id: i, x: i * 25 + 10, y: 50);

                wallList.Add(wall);
            }
            DisplayWall(wallList);




            // Instancie la squad d'ennemis
            Squad squad = new Squad(_numberOfEnemyByRow, _numberOfRow, _enemySpeed);

            squad.CreateEnnemi();

            //Créé la liste de missile de type Bullet
            List<Bullet> bulletList = new List<Bullet>();
            DisplayInformationGame(player);


            GameUpdate(player, squad, bulletList, wallList);
        }


        public void EndOfGame()
        {
            Console.Clear();

            for (int i = 0; i < _gameOverText.Length; i++)
            {
                Console.SetCursorPosition(67 + i, 10);
                Console.Write(_gameOverText[i]);
                Thread.Sleep(10);
            }
        }

        /// <summary>
        /// Affiche les murs dans la console
        /// </summary>
        /// <param name="wallList"> La liste des murs </param>
        public void DisplayWall(List<Wall> wallList)
        {

            // Regarde tous les murs présents dans la liste
            foreach (Wall wall in wallList)
            {
               
                // Regarde selon le nombre de point de vie du mur
                switch (wall.LifePoints)
                {
                    case 0:
                        wall.Symbole = "               ";
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        break;

                }


                Console.SetCursorPosition(wall.X, wall.Y);
                Console.WriteLine(wall.Symbole);
                Console.ForegroundColor = ConsoleColor.White;


                
            }
           
        }

        /// <summary>
        /// Affiche les informations de la parite (point, nom du joueur, point de vie)
        /// </summary>
        /// <param name="player"> Le joueur</param>
        private void DisplayInformationGame(Player player)
        {
            // Bar 
            Console.SetCursorPosition(1, 3);
            Console.WriteLine("________________________________________________________________________________________________________________________________________________________________________");
            
            // Score du joueur
            Console.SetCursorPosition(5, 2);
            Console.Write("Score : {0}", _score);

            // Nom du joueur
            Console.SetCursorPosition(76, 2);
            Console.Write("Joueur : {0}", _pseudoPlayer);

            // No,bre de vie du joueur
            Console.SetCursorPosition(150, 2);
            Console.Write("Nombre de vie : ");

            for(int i = 0; i < _numberOfLives; i++)
            {
                Console.Write("♥");
            }
        }


        /// <summary>
        /// A chaque frame du jeu
        /// </summary>
        /// <param name="player"></param>
        /// <param name="squad"></param>
        public void GameUpdate(Player player, Squad squad, List<Bullet> bulletList, List<Wall> wallList)
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
                if (ennemiCounter == ENEMYCOUNTERMAX)
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
                if (bulletCounter == BULLETCOUNTERMAX)
                {
                    EreaseBullet(bulletList);
                    BulletMovement(bulletList);
                    DisplayBullet(bulletList);

                    // Reset le counter 
                    bulletCounter = 0;
                }

                bulletList = CheckEnemyShooting(squad, bulletList);

                // Regarde les collisions des missiles
                CheckBulletColision(squad, bulletList, wallList, player);
                CheckBulletColisionWithWall(wallList, bulletList);

                
                // Regarde si tous les ennemis sont morts
                if (CheckAllEnemiesKilled(squad))
                {
                    
                    
                    RestartRound(squad, wallList);
                }


                // Regarde si les ennemis ont touché le joueur (trop bas)
                if(CheckEnemiesHitPlayer(squad, player))
                {
                    this._game = false;
                }

                
            }

                
        }

        /// <summary>
        /// Regarde si les ennemis sont descendu assez bas pour toucher le joueur
        /// </summary>
        /// <param name="squad"> La squad d'ennemis </param>
        /// <param name="player">  Le joueur </param>
        /// <returns></returns>
        private bool CheckEnemiesHitPlayer(Squad squad, Player player)
        {
            foreach(Enemy enemy in squad.EnemyList)
            {
                if(enemy.YPose > 45 && enemy.Alive)
                {


                    _gameOverText = "Vous avez été envahi par les aliens !!";
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Regarde si un tir a eu contact avec un mur
        /// </summary>
        /// <param name="wallList"> Liste des murs </param>
        /// <param name="bulletList"> Liste des tirs</param>
        private void CheckBulletColisionWithWall(List<Wall> wallList, List<Bullet> bulletList)
        {
            bool founded = false;
            foreach (Bullet bullet in bulletList)
            {
                foreach (Wall wall in wallList)
                {
                   // Regarde si un mur a eu contact avec un tir et que le mur est encore en vie
                    if((bullet.X >= wall.X && bullet.X < wall.X + 15) && wall.Y == bullet.Y && wall.LifePoints != 0)
                    {

                        // Regarde si le tir vient du joueur ou de l'ennemi
                        if(bullet.Speed < 0)
                        {
                            wall.LifePoints--;
                            DisplayWall(wallList);
                            bulletList.Remove(bullet);
                            founded = true;
                            break;
                        }
                        else
                        { 
                            DisplayWall(wallList);
                            bulletList.Remove(bullet);
                            founded = true;
                            break;
                        }
                    }
                }
                if(founded)
                {
                    founded = false;
                    break; 
                }
            }
        }

        /// <summary>
        /// Méthode pour recommencer un round
        /// </summary>
        /// <param name="squad"> La squad d'ennemi </param>
        /// <param name="wallList"> La liste de mur </param>
        private void RestartRound(Squad squad, List<Wall> wallList)
        {

            // Recrée tous les ennemis
            for (int i = 0; i < this._numberOfRow; i++)
            {
                for (int u = 0; u < this._numberOfEnemyByRow; u++)
                {
                    squad.EnemyList[i* _numberOfEnemyByRow + u].Alive = true;
                    squad.EnemyList[i * _numberOfEnemyByRow + u].XPose = u * 13 + 5;
                    squad.EnemyList[i * _numberOfEnemyByRow + u].YPose = i * 6 + 5;
                    squad.EnemyList[i * _numberOfEnemyByRow + u].IsShooting = false;
                    squad.EnemyList[i * _numberOfEnemyByRow + u].Direction = 1;
                    squad.EnemyList[i * _numberOfEnemyByRow + u].EnemyRecoil();
                }
            }
        }
        
        /// <summary>
        /// Regarde si tous les ennemis sont morts 
        /// </summary>
        /// <param name="squad"> La squad d'ennemi</param>
        /// <returns></returns>
        private bool CheckAllEnemiesKilled(Squad squad)
        {
            bool allKilled = false;
            foreach(Enemy enemy in squad.EnemyList)
            {
                if(enemy.Alive == false)
                {
                    allKilled = true;
                }
                else
                {
                    allKilled = false;
                    break;
                }
            }
            return allKilled;
        }

        /// <summary>
        /// Regarde si l'ennemi est en capacité de tirer (uniquement ceux qui n'ont personne devant eux peuvent tirer)
        /// </summary>
        /// <param name="squad"> La squad d'ennemi </param>
        /// <param name="bulletList"> La liste de bullet </param>
        /// <returns> La liste de bullet </returns>
        private List<Bullet> CheckEnemyShooting(Squad squad, List<Bullet> bulletList)
        {
            

            foreach(Enemy enemy in squad.EnemyList)
            {
                enemy.IsShooting = true;
                foreach(Enemy teamMate in squad.EnemyList)
                {
                    // Regarde s'il y a un autre ennemi en vie devant lui 
                    if((teamMate.Id % _numberOfEnemyByRow == enemy.Id % _numberOfEnemyByRow)  && teamMate.Alive && teamMate.Id != enemy.Id && enemy.Id < teamMate.Id)
                    {
                        enemy.IsShooting = false;
                        break;
                    }
                }
                
                if (enemy.ShootingCooldown == 0 && enemy.IsShooting && enemy.Alive)
                {
                    bulletList.Add(new Bullet(enemy.XPose + 5 , enemy.YPose + 4, -1));
                    enemy.IsShooting = false;
                    enemy.EnemyRecoil();
                }

                if(enemy.IsShooting)
                {
                    enemy.ShootingCooldown--;
                }
                
            }

            return bulletList;
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
                    if (player.X >= PLAYERBORDERLIMITRIGHT)
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
                    if (player.X <= PLAYERBORDERLIMITLEFT)
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
                        player.Recoil = PLAYERSHOOTINGRECOILMAX;
                        bullet.Add(new Bullet(player.X + 7, player.Y - 4, 1));
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
        public void CheckBulletColision(Squad squad, List<Bullet> bulletList, List<Wall> wallList, Player player)
        {
            // Regarde tous les ennemis ainsi que tous les missiles
            foreach (Enemy ennemi in squad.EnemyList)
            {
                foreach (Bullet bullet in bulletList)
                {

                    // Regarde si la position du missile est la même que celle d'un ennemis
                    if ((bullet.Y == ennemi.YPose + 4 && (bullet.X < ennemi.XPose + 11 && bullet.X > ennemi.XPose) && bullet.Speed == 1))
                    {
                        // Si l'ennemi est vivant, l'efface, le considère comme mort et détruit le missile
                        if (ennemi.Alive)
                        {
                            ennemi.EreaseEnnemi();

                            ennemi.Alive = false;
                            RemoveBullet(bulletList, bullet);
                            this._score += 100;
                            DisplayInformationGame(player);

                            break;
                        }
                    }

                    // Détruit le missile s'il sort de la console
                    if ((bullet.Y == 4 && bullet.Speed == 1) || (bullet.Y == 56 && bullet.Speed == -1))
                    {
                        Console.SetCursorPosition(bullet.X, bullet.Y);
                        Console.Write(" ");
                        RemoveBullet(bulletList, bullet);
                        break;
                    }

                    
                }
            }

            foreach (Bullet bullet in bulletList)
            {
                // Regarde si la position du missile est la même que celle du joueur
                if ((bullet.Y == player.Y - 3 && (bullet.X > player.X && bullet.X < player.X + 12) && bullet.Speed == -1))
                {
                    _numberOfLives--;
                    for ( int i = bulletList.Count - 1; i >= 0; i--)
                    {
                        bulletList.Remove(bulletList[i]);
                    }
                    Console.Clear();
                    DisplayWall(wallList);
                    
                    foreach (Enemy enemy in squad.EnemyList)
                    {
                        enemy.DisplayEnnemi();
                    }
                    EreaseBullet(bulletList);
                    DisplayInformationGame(player);
                    if (_numberOfLives == 0)
                    {
                        this._game = false;
                        _gameOverText = "Vous avez été tués par les aliens";
                    }
                    Thread.Sleep(3000);
                    break;
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
                bullet.Y -= bullet.Speed;
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
