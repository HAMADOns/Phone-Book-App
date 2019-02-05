using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PhoneBookConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("***********************------------------------------------------------------------------********************");
            Console.WriteLine("**********************************--------------------------------------------*******************************");
            Console.WriteLine("************************************************* PhoneBook *************************************************");
            Console.WriteLine("**********************************--------------------------------------------*******************************");
            Console.WriteLine("***********************-------------------------------------------------------------------*******************");

            int choice;
            do {
                choice = Menu.getMainMenu();

                Menu.MenuFunctions(choice);

            } while (choice != 8);                      
            
            Console.ReadKey();
        }
    }
}
