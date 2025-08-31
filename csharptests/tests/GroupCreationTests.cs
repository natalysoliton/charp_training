using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("aa");
            group.Header = "bb";
            group.Footer = "sdv";

            List<GroupData> oldGroups = app.Groups.GetGroupList(); 

            app.Groups.Create(group); 

            ClassicAssert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList(); 
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            ClassicAssert.AreEqual(oldGroups, newGroups); 
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            ClassicAssert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount()); 

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            ClassicAssert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void BadGroupCreationTest()
        {
            GroupData group = new GroupData("a'b");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            ClassicAssert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount()); 

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            ClassicAssert.AreEqual(oldGroups, newGroups);
        }
    }
}