using System;

namespace NYSS_Lab1.Entry
{
   public class PhonebookEntry
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public long PhoneNumber { get; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Organization { get; set; }
        public string Position { get; set; }
        public string Note { get; set; }

        public PhonebookEntry() { }

        public PhonebookEntry(string surname, string name, string phoneNumber, string country)
        {
            Surname = surname;
            Name = name;
            PhoneNumber = long.Parse(phoneNumber);
            Country = country;
        }
        public override string ToString()
        {

            string ret = $"Surname: {Surname}\n"
                         + $"Name: {Name}\n"
                         + $"Phone number: {PhoneNumber}\n"
                         + $"Country: {Country}\n";
            if (!String.IsNullOrEmpty(Patronymic))
            {
                ret += $"Patronymic: {Patronymic}\n";
            }

            if (!String.IsNullOrEmpty(Position))
            {
                ret += $"Position: {Position}\n";
            }

            if (!String.IsNullOrEmpty(Organization))
            {
                ret += $"Organization: {Organization}\n";
            }

            if (!String.IsNullOrEmpty(Note))
            {
                ret += $"Note: {Note}\n";
            }

            if (DateOfBirth != DateTime.MinValue)
            {
                ret += $"Date of birth: {(DateOfBirth == DateTime.MinValue ? string.Empty : DateOfBirth.ToShortDateString())}\n";
            }

            return ret;

        }
    }
}
