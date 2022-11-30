using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyNvader
{
    internal class Squad
    {

        /// <summary>
        /// Nombre d'ennemis par ligne
        /// </summary>
        private int _numberOfEnnemiByRow;

        /// <summary>
        /// Nombre de ligne d'ennemis
        /// </summary>
        private int _numberOfRow;

        private int _enemySpeed;

        /// <summary>
        /// Liste de tous les ennemis de type Enemy
        /// </summary>
        private List<Enemy> _enemyList = new List<Enemy>();

        /// <summary>
        /// Limite déplacement des ennemis à droite
        /// </summary>
        private const int BORDERLIMITRIGHT = 155;

        /// <summary>
        ///  Limite de déplacement des ennemis à gauche
        /// </summary>
        private const int BORDERLIMITLEFT = 4;


        /// <summary>
        /// Constructeur Custom
        /// </summary>
        /// <param name="numberOfEnemyByRow"></param>
        /// <param name="numberOfRow"></param>
        public Squad(int numberOfEnemyByRow, int numberOfRow, int enemySpeed)
        {
            _numberOfEnnemiByRow = numberOfEnemyByRow;
            _numberOfRow = numberOfRow;
            _enemySpeed = enemySpeed;
        }


        /// <summary>
        /// Getter Setter de la liste des ennemis
        /// </summary>
        public List<Enemy> EnemyList
        {
            get { return _enemyList; }
            set { _enemyList = value; }
        }


        /// <summary>
        /// Méthode pour créer les ennemis selon le nombre de ligne et le nombre d'ennemis par ligne 
        /// </summary>
        public void CreateEnnemi()
        {
            for(int i = 0; i < this._numberOfRow; i++)
            {
                for (int u = 0; u < this._numberOfEnnemiByRow; u++)
                {
                    //ajoute à la liste les nouveaux ennemis
                    _enemyList.Add(new Enemy(enemySpeed: _enemySpeed,xPose: u * 13 + 5, yPose: i * 6 + 5, alive: true, isShooting: false, id: i * _numberOfEnnemiByRow + u)); 
                }
            }
            
            // Affiche chaque ennemis dans la console
            foreach (Enemy enemy in this._enemyList)
            {
                enemy.DisplayEnnemi();
            }


            
            
           
        }

        /// <summary>
        /// Méthode que mets les ennemis en mouvement
        /// </summary>
        public void EnnemiMovement()
        {
            // Pour chaque ennemis de la liste 
            foreach (Enemy enemy in this._enemyList)
            {
                // Regarde s'il est vivant 
                if(enemy.Alive) 
                {
                    // Efface l'ennemis
                    enemy.EreaseEnnemi();

                    if (enemy.Direction == 1)
                        enemy.XPose += enemy.EnemySpeed;
                    else
                        enemy.XPose -= enemy.EnemySpeed;
                }
                



            }

            foreach (Enemy enemy in this._enemyList)
            {
                if (enemy.Alive)
                {
                    // Affiche les ennemis vivant
                    enemy.DisplayEnnemi();
                }
                else
                {
                    
                }
            }
        }


        /// <summary>
        /// Méthode qui fait les collisions des vaisseaux ennemis avec les bords de la console
        /// </summary>
        /// <returns>
        /// Retourn un vrai s'il touche un bord, un faux s'il ne touche rien 
        /// </returns>
        public bool CheckBorder()
        {
            // Pour chaque ennemis de la liste
            foreach (Enemy enemy in this._enemyList)
            {
                // Regarde si un ennemi a un contacte avec le bord de la console et est vivant
                if (((enemy.XPose <= BORDERLIMITLEFT && enemy.Direction == 2) || (enemy.XPose >= BORDERLIMITRIGHT && enemy.Direction == 1)) && enemy.Alive)
                {
                    foreach (Enemy enemies in this._enemyList)
                    {
                        // Efface chaque ennemi, les descend d'une ligne puis change leur direction
                        enemies.EreaseEnnemi();
                        enemies.YPose += 6;
                        if (enemies.Direction == 1)
                        {
                            enemies.Direction = 2;
                        }
                        else
                        {
                            enemies.Direction = 1;
                        }
                    }

                    // Réaffiche tous les ennemis vivant à leur nouvelle place
                    foreach (Enemy enemies in this._enemyList)
                    {
                        if(enemies.Alive)
                        {
                            enemies.DisplayEnnemi();
                        }
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
