﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NYSS_Lab1
{
    class PhoneBook
    {
        public Dictionary<long, PhonebookEntry> Book;

        public PhoneBook()
        {
            Book = new Dictionary<long, PhonebookEntry>();
        }

        public PhoneBook(Dictionary<long, PhonebookEntry> oldBook)
        {
            Book = oldBook;
        }

        public void CreateEntry(PhonebookEntry newEntry)
        {
            Book.Add(newEntry.PhoneNumber, newEntry);
        }

        public void EditEntry(PhonebookEntry editedEntry)
        {
            if (Book.ContainsKey(editedEntry.PhoneNumber))
            {
                Book[editedEntry.PhoneNumber] = editedEntry;
            }
            else
            {
                CreateEntry(editedEntry);
            }
        }

        public void DelEntry(string phoneNumber)
        {
            Book.Remove(long.Parse(phoneNumber));
        }

        public void ShowInfo(string phoneNumber)
        {
            Console.WriteLine(Book[long.Parse(phoneNumber)].ToString());
        }
    }
}