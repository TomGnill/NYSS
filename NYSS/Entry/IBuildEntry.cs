using System;
using System.Collections.Generic;
using System.Text;

namespace NYSS_Lab1.Entry
{
    interface IBuildEntry
    {
        public void AddMainInfo(string surname, string name, string phoneNumber, string country);

        public void AddPatrymic(string str);

        public void AddNote(string str);

        public void AddOrganization(string str);

        public void AddPosition(string str);

        public void AddDateOfBirth(string str);

        public PhonebookEntry ReturnInfo();
    }
}
