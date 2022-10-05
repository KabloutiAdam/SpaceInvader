using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyNvader
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.SetWindowSize(70, 50);
            Console.BufferHeight = 50;
            Console.BufferWidth = 70;


            
            Menu mainMenu = new Menu();

            mainMenu.MainMenu();

            

            Console.ReadLine();
        }
    }
}
