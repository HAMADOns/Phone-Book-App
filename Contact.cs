using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PhoneBookConsole
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Mobil { get; set; }
        public string Email { get; set; }




        /******************************* Add contact to list then Apdate File *************************************************/



        public static Contact AddContact(string name, string mobile, string email)
        {
            var contacts = Contact.GetAllContacts();        // recuperer le fichier ds une liste pour manipuler

            Contact contact = new Contact() { ContactID = contacts.Count + 1, Name = name, Mobil = mobile, Email = email }; // creation d'un objet

            contacts.Add(contact);
            using (StreamWriter file = new StreamWriter(@"../../ListOfContact.json"))    // transfert des données dans le fichier
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, contacts);
            }
            return contact;

        }





        /***************************** data in file to  list *********************************************************/


        public static List<Contact> GetAllContacts()
        {

            using (StreamReader data = File.OpenText(@"../../ListOfContact.json"))
            {

                var stringListOfContact = data.ReadToEnd();

                var ObjectsJsonList = JsonConvert.DeserializeObject<List<Contact>>(stringListOfContact);

                return ObjectsJsonList.OrderBy(c => c.Name).ToList();
            }



        }




        /************************Remove a contact with name ************************************************************/


        public static void RemoveContact(string RemoveName)  // suppression d'un element selon le nom
        {
            var contacts = Contact.GetAllContacts();
            var test = false;


            var contactToRemove = contacts.Where(s => s.Name.ToLower().Contains(RemoveName.ToLower())).ToList();

            foreach (var contact in contactToRemove)
            {
                var RN = RemoveName.ToLower();
                if (contact.Name.ToLower().Equals(RN))
                {
                    contacts.Remove(contact);
                    test = true;
                }
            }

            if (test == true)
            {
                Console.WriteLine(" the contact has been removed ");

                using (StreamWriter file = new StreamWriter(@"../../ListOfContact.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, contacts);
                }
            }
            else
            {
                Console.WriteLine("contact doesn't exist to remove");
            }

        }

        /************************************ RemoveAllContacts****************************************************************/



        public static void RemoveAllContacts()      // fonctionnelle
        {
            var contacts = Contact.GetAllContacts();
            contacts.Clear();

            using (StreamWriter file = new StreamWriter(@"../../ListOfContact.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, contacts);
            }
            Console.WriteLine("All contacts are removed");
        }


        /*************************************** Update a contact in the list ****************************************************/


        public static void UpdateContacts()
        {
            var contacts = Contact.GetAllContacts();

            string name, mobil, email;
            do
            {
                Console.WriteLine("What contact do you want to update ? ");
                name = Console.ReadLine();

                if (CheckExistContact(name))
                {
                    var CheckContact = contacts.Where(s => s.Name.ToLower().Equals(name.ToLower())).ToList();
                    foreach (var contact in CheckContact)
                    {

                        Console.WriteLine("Enter the new name : ");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter the new phone number : ");
                        mobil = Console.ReadLine();
                        Console.WriteLine("Enter the new email adress : ");
                        email = Console.ReadLine();

                        contact.Name = name;
                        contact.Mobil = mobil;
                        contact.Email = email;

                    }
                    using (StreamWriter file = new StreamWriter(@"../../ListOfContact.json"))    // transfert des données dans le fichier
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(file, contacts);
                    }
                }
                else
                {
                    Console.WriteLine("Contact doesn't exist, please try again ! ");
                }
            } while (!CheckExistContact(name));

        }
        /*************************************** Check for duplicate ***************************************************/


        public static bool CheckExistContact(string name)
        {

            var contacts = Contact.GetAllContacts();

            var test = false;

            var CheckContact = contacts.Where(s => s.Name.ToLower().Contains(name.ToLower())).ToList();

            foreach (var contact in CheckContact)
            {
                if (contact.Name.ToLower().Equals(name.ToLower()))
                {
                    test = true;
                    break;
                }
            }

            return (test);

        }


        /**************************************** View contacts ********************************************/


        public static void ViewContact()
        {
            var contacts = Contact.GetAllContacts();

            if (contacts.Any())
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine(CultureInfo.InvariantCulture.TextInfo.ToTitleCase($"{contact.Name} {contact.Mobil} {contact.Email}"));

                }
            }
            else
            {
                Console.WriteLine(" You have no contacts in your phone !!");
            }
        }



        /****************************** Partial Name **********************************************************/


        public static void PartialName()
        {
            var contacts = Contact.GetAllContacts();
            var test = false;
            string name;

            Console.WriteLine("Enter a partial name : ");
            name = Console.ReadLine();

            var CheckContact = contacts.Where(s => s.Name.ToLower().Contains(name.ToLower())).ToList();

            foreach (var check in CheckContact)
            {
                Console.WriteLine("{0} in {1} {2} {3}", name, check.Name, check.Mobil, check.Email);
                test = true;
            }
            if (test == false)
            {
                Console.WriteLine("{0} doesn't exist in any contact ", name);
            }

        }
        /***************************************************************************************************/

        public static void ViewOneContact(string name)
        {
            var contacts = Contact.GetAllContacts();
            foreach (var contact in contacts)
            {
                if (contact.Name.ToLower().Equals(name.ToLower()))
                {
                    Console.WriteLine(" Name : {0} ", contact.Name);
                    Console.WriteLine(" Phone number : {0} ", contact.Mobil);
                    Console.WriteLine(" Adress email : {0} ", contact.Email);
                }


            }

        }
    }
    
}
