using NUnit.Framework;
using NUnit.Framework.Legacy;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void ContactInformationTest()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromFrom = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(fromTable, fromFrom);
            Assert.AreEqual(fromTable.Address, fromFrom.Address);
            Assert.AreEqual(fromTable.AllEmail, fromFrom.AllEmail);
            Assert.AreEqual(fromTable.AllPhones, fromFrom.AllPhones);
        }
    }
}
