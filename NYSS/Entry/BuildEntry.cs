using System;
using System.Collections.Generic;
using System.Text;

namespace NYSS_Lab1.Entry
{
    class BuildEntry : IBuildEntry
    {
        public  PhonebookEntry newEntry = new PhonebookEntry();

        public BuildEntry()
        {
            this.Reset();
        }

        public void Reset()
        {
            this.newEntry = new PhonebookEntry();
        }

        public void AddMainInfo(string surname, string name, string phoneNumber, string country)
        {
            this.newEntry = new PhonebookEntry(surname, name, phoneNumber, country);
        }

        public void AddPatrymic(string str) 
        {
            this.newEntry.Patronymic = str;
        }

        public void AddOrganization(string str)
        {
            this.newEntry.Organization = str;
        }

        public void AddPosition(string str)
        {
            this.newEntry.Position = str;
        }

        public void AddDateOfBirth(string str)
        {
            this.newEntry.DateOfBirth = DateTime.Parse(str);
        }

        public void AddNote(string str)
        {
            this.newEntry.Note = str;
        }
        public PhonebookEntry ReturnInfo()
        {
            PhonebookEntry ourEntry = this.newEntry;
            Reset();
            return ourEntry;
        }


        

      

      

    }
}
