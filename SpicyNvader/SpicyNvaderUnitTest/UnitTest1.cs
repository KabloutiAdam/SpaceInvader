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
            Bullet bullet = new Bullet();

            Assert.IsTrue(bullet.HitCheck());

        }



    }
}
