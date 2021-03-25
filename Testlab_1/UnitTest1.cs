using NUnit.Framework;
using NYSS_Lab1;

namespace Testlab_1
{
    public class Tests
    {
        
            PhoneBook newBook1 = new PhoneBook();
            PhonebookEntry entry1 = new PhonebookEntry("Гошин", "Гоша", "12223334455", "США");
            PhonebookEntry entry2 = new PhonebookEntry("Гошин1", "Гоша1", "12223334456", "США");
            PhonebookEntry entry3 = new PhonebookEntry("Гошин2", "Гоша2", "12223334457", "США");
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            newBook1.CreateEntry(entry1);
            Assert.AreEqual("12223334455", newBook1.Book[12223334455].PhoneNumber.ToString());
        }
        [Test]
        public void Test2()
        {
            newBook1.CreateEntry(entry1);
            newBook1.CreateEntry(entry2);
            Assert.AreEqual(2, newBook1.Book.Count);
        }

    }
}