using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyNvader
{
    internal class ScoreComparer : IComparer<string>
    {

        public int Compare(string x, string y)
        {
            // Sépare le string en name et score 
            string[] xParts = x.Split(';');
            string[] yParts = y.Split(';');

            // Parse le score
            int xScore = int.Parse(xParts[1]);
            int yScore = int.Parse(yParts[1]);

           
            return yScore.CompareTo(xScore);
        }
    }
}
