using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SpicyNvader;

namespace SpicyNvaderUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckIfMenuIsNotNull()
        {

            Menu menu = new Menu();

            Assert.IsNotNull(menu);

        }

        [TestMethod]
        public void GetplayerSpeed()
        {
            int playerSpeed = 20;
            Player player = new Player(5,4,playerSpeed);

            Assert.AreEqual(player.Speed, playerSpeed);
        }

        [TestMethod]
        public void IncrementPlayerScore()
        {
            Game game = new Game();
            int score = 50;
            int newScore = game.IncrementScore(score);

            Assert.AreEqual(score, newScore);
        }

        [TestMethod]
        public void BulletEnnemiContact()
        {
            bool hit = false;

            SpicyNvader.Bullet bullet = new SpicyNvader.Bullet(10,24,1);
            SpicyNvader.Enemy enemy = new SpicyNvader.Enemy(-1,10,20,true,false,1);
            if ((bullet.Y == enemy.YPose + 4 && (bullet.X < enemy.XPose + 11 && bullet.X >= enemy.XPose) && bullet.Speed == 1))
            {
                // Si l'ennemi est vivant, l'efface, le considère comme mort et détruit le missile
                if (enemy.Alive)
                {
                    enemy.Alive = false;
                    hit = true;
                }
            }
            

            Assert.IsTrue(hit);

        }



    }
}
