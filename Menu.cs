using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PhoneBookConsole
{
    class Menu
    {
        public static int getMainMenu()
        {

            int choice;
            
            
            do
            {
            Console.WriteLine(".............................................................................................................");
            Console.WriteLine(" ");
            Console.WriteLine(" ");            
            Console.WriteLine("Give a choice : ");
            Console.WriteLine(" 1 - List of contacts : ");
            Console.WriteLine(" 2 - Add a contact : ");
            Console.WriteLine(" 3 - Remove a contact : ");
            Console.WriteLine(" 4 - Update a contact : ");
            Console.WriteLine(" 5 - Serach for a contact : ");
            Console.WriteLine(" 6 - Serach for a contact with partial name : ");
            Console.WriteLine(" 7 - Remove all contacts : ");
            Console.WriteLine(" 8 - Exit Application : ");


                choice = Convert.ToInt32(Console.ReadLine());
            }
            while ((choice < 1) && (choice > 8));
            return (choice);
        }


      

        public static void MenuFunctions(int choice)
        {
            string name, mobil, email;
            switch (choice)
            {
                case 1:
                    Console.WriteLine("");
                    Console.WriteLine("The list of Contact : ");
                    Contact.ViewContact();
                    break;
                case 2:
                    Console.WriteLine("");
                    Console.WriteLine("Enter a name to add");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter his phone number");
                    mobil = Console.ReadLine();
                    Console.WriteLine("Enter his email adress");
                    email = Console.ReadLine();

                    Contact.AddContact(name,mobil,email);
                    Console.WriteLine("Contact has been added ");
                    break;
                case 3:
                    Console.WriteLine("");
                    MenuRemove.MenuR();
                    break;
                case 4:
                    Console.WriteLine("");
                    Contact.UpdateContacts();
                    Console.WriteLine("Contact has been updated");
                    
                    break;
                case 5:
                    Console.WriteLine("");
                    Console.WriteLine("Enter a name to search");
                    name = Console.ReadLine();
                    if (Contact.CheckExistContact(name))
                    {
                        Console.WriteLine("this contact exist in your Phone book");
                        Contact.ViewOneContact(name);
                    }
                    else
                    {
                        Console.WriteLine("this contact doesn't exist");
                    }
                    break;
                case 6:
                    Console.WriteLine("");
                    Contact.PartialName();
                    break;
                case 7:
                    Console.WriteLine("");
                    Contact.RemoveAllContacts();
                    break;
                case 8:
                    Console.WriteLine("");
                    Console.WriteLine("************************************************* Fin PhoneBook *************************************************");
                    //Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Bad choice, try again" ); 
                    break;
                    }
            
        }
        
    }
}
