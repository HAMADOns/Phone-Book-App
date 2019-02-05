using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PhoneBookConsole
{
    class MenuRemove
    {
        
        public static void MenuR()
        {
            String name;
            int response; 
            do
            {
                Console.WriteLine(" Enter the contact to remove : ");
                name = Console.ReadLine();

            } while (String.IsNullOrEmpty(name));

            var test = Contact.CheckExistContact(name);

            if (test)
            {
                do
                {
                    Console.WriteLine(" Are you sure to remove {0} : 0/1 ?", name);
                    response = Convert.ToInt32(Console.ReadLine());
                } while (response < 0 && response > 1);

                switch (response)
                {
                    case 1:
                        Contact.RemoveContact(name);
                        break;
                    case 0:
                        Menu.getMainMenu();
                        break;
                }

            }
            else
            {
                Console.WriteLine(" Contact doen't existe to remove ");
            }
            

        }
    }
}
