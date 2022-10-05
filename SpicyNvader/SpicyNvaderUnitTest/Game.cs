using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyNvaderUnitTest
{
    internal class Game
    {

        int _scorePlayer = 0;

        public Game()
        {

        }





        public int IncrementScore(int score)
        {

            return _scorePlayer += score;
        }

    }
}
