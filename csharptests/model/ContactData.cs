using System;
using System.Xml.Linq;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public bool Equals(ContactData other) 
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other)) 
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() & Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "firstname=" + Firstname + ", lastname=" + Lastname;

        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            int LastnameCompare = Lastname.CompareTo(other.Lastname);
            if (LastnameCompare != 0)
            {
                return LastnameCompare;
            }
            return Firstname.CompareTo(other.Firstname);
        }

        public ContactData(string firstname)
        {
            Firstname = firstname;
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}