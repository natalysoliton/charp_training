using NUnit.Framework;

//using NUnit.Framework.Legacy;
//using System.Security.Cryptography;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void AddAddressTest()
        {
            ContactData contact = new ContactData("Тест");
            contact.Lastname = "Тестов";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(oldContacts, newContacts);
        }
    }
}