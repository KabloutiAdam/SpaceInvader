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
            //Redimensionne la fenêtre de la console 
            Console.SetWindowSize(170, 50);
            Console.BufferHeight = 50;
            Console.BufferWidth = 170;

            //Rend le curseur invisible
            Console.CursorVisible = false;

            //Instancie un objet "Menu"
            Menu mainMenu = new Menu();
            
            mainMenu.MainMenu();

            

            Console.ReadLine();
        }
    }
}
