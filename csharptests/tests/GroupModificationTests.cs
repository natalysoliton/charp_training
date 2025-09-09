using NUnit.Framework;
//using NUnit.Framework.Legacy;
using System.Collections.Generic;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            if (!app.Groups.IsGroupPresent()) 
            {
                GroupData group = new GroupData("Test Group");
                app.Groups.Create(group);
            }
            GroupData newData = new GroupData("b");
            newData.Header = "bc";
            newData.Footer = "bkc";

            List<GroupData> oldGroups = app.Groups.GetGroupList(); 
            GroupData oldData = oldGroups[0]; 

            app.Groups.Modify(0, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount()); 

            List<GroupData> newGroups = app.Groups.GetGroupList(); 
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name); 
                }
            }
        }
    }
}