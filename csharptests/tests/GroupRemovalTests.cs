using NUnit.Framework;
//using NUnit.Framework.Legacy;
using System.Collections.Generic;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            if (!app.Groups.IsGroupPresent()) 
            {
                GroupData group = new GroupData("Test Group");
                app.Groups.Create(group);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList(); 
            app.Groups.Remove(0);

            Assert.AreEqual(oldGroups.Count - +1, app.Groups.GetGroupCount()); 
            List<GroupData> newGroups = app.Groups.GetGroupList(); 
            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0); 
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id); 
            }
        }
    }
}