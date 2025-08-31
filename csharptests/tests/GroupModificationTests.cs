using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;

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
            GroupData newData = new GroupData("z");
            newData.Header = "zx";
            newData.Footer = "zxc";

            List<GroupData> oldGroups = app.Groups.GetGroupList(); 
            GroupData oldData = oldGroups[0]; 

            app.Groups.Modify(0, newData);

            ClassicAssert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount()); 

            List<GroupData> newGroups = app.Groups.GetGroupList(); 
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            ClassicAssert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    ClassicAssert.AreEqual(newData.Name, group.Name); 
                }
            }
        }
    }
}