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




            



























           // var contacts = Contact.GetAllContacts();   

            /* Contact.AddContact("Ons Hamad", "11111111", "test1@test.com");              
             Contact.AddContact("Asma Najjar", "22222222", "test2@test.com");
             Contact.AddContact("Hana Halouani", "33333333", "test3@test.com");
             Contact.AddContact("Jaafour Ben Naser", "44444444", "test4@test.com");
             Contact.AddContact("Barhoum Samali", "55555555", "test5@test.com");
             Contact.AddContact("Hedya Chennaoui", "66666666", "test6@test.com");

          Contact.AddContact("Ons", "77777777", "test7@test.com");
          Contact.AddContact("Asma", "88888888", "test8@test.com");
          Contact.AddContact("Hana", "99999999", "test9@test.com");
          Contact.AddContact("Jaafour", "00000000", "test10@test.com");*/

            //Contact.ViewContact();


            /*Contact.RemoveContact("ahlem");


             Contact.ViewContact();*/



            //Contact.RemoveAllContacts();



           /* if (Contact.CheckExistContact("BaRhOuM SaMaLi"))  // if true asks to update
            {
                Console.WriteLine("This contact exists on your phone book ");
            }
            else
            {
                Console.WriteLine("this contact doesn't exist");
            } */




            //Contact.PartialName("LoUa");




            
                
           

            



            Console.ReadKey();
        }
    }
}
