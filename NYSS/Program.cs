using System;
using NYSS_Lab1;

namespace NYSS
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneBook newBook1 = new PhoneBook();
            PhonebookEntry entry1 = new PhonebookEntry("Гошин", "Гоша", "12223334455", "США");
            PhonebookEntry entry2 = new PhonebookEntry("Гошин1", "Гоша1", "12223334456", "США");
            PhonebookEntry entry3 = new PhonebookEntry("Гошин2", "Гоша2", "12223334457", "США");

            newBook1.CreateEntry(entry1);
            newBook1.CreateEntry(entry2);
            newBook1.CreateEntry(entry3);
            newBook1.ShowAllContacts();
            

        }
    }
}
