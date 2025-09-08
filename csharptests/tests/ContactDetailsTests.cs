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
    public class ContactDetailsTests : AuthTestBase
    {
        [Test]
        public void ContactDetailsTest()
        {
            ContactData fromDetails = app.Contacts.GetContactInformationFromDetails(0);
            ContactData fromFrom = app.Contacts.GetContactInformationFromEditForm(0);

          Assert.AreEqual(fromDetails.AllNames, fromFrom.AllNames);
          Assert.AreEqual(fromDetails.TextInDetails, fromFrom.TextInDetails);
        }
    }
}
