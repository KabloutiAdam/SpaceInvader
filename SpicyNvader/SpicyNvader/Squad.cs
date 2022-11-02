using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyNvader
{
    internal class Squad
    {


        private int _numberOfEnnemiByRow = 4;
        private int _numberOfRow = 2;
        private int _maxLeft = 0;
        private int _maxTop = 0;
        private List<Ennemi> _enemyList = new List<Ennemi>();

        public Squad()
        {

        }

        

        public List<Ennemi> EnemyList
        {
            get { return _enemyList; }
            set { _enemyList = value; }
        }



        public void CreateEnnemi()
        {
            for(int i = 0; i < this._numberOfRow; i++)
            {
                for (int u = 0; u < this._numberOfEnnemiByRow; u++)
                {
                    _enemyList.Add(new Ennemi(xPose: u * 13 + 5, yPose: i * 6 + 5, speed: 1, alive: true, isShooting: false, id: i * _numberOfEnnemiByRow + u)); 
                }
            }
            

            foreach (Ennemi enemy in this._enemyList)
            {
                enemy.DisplayEnnemi();
            }


            
            
           
        }

        public void EnnemiMovement()
        {
            foreach (Ennemi enemy in this._enemyList)
            {
                if(enemy.Alive)
                {
                    enemy.EreaseEnnemi();

                    if (enemy.Direction == 1)
                        enemy.XPose += 4;
                    else
                        enemy.XPose -= 4;
                }
                



            }

            foreach (Ennemi enemy in this._enemyList)
            {
                if (enemy.Alive)
                {
                    enemy.DisplayEnnemi();
                }
                else
                {
                    
                }
            }
        }

        public bool CheckBorder()
        {
            foreach (Ennemi enemy in this._enemyList)
            {
                if (((enemy.XPose <= 4 && enemy.Direction == 2) || (enemy.XPose >= 113 && enemy.Direction == 1)) && enemy.Alive)
                {
                    foreach (Ennemi enemies in this._enemyList)
                    {
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
                    foreach (Ennemi enemies in this._enemyList)
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
