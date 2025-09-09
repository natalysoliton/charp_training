using System.Text.RegularExpressions;


namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmail;
        private string allNames;
        private string textInDetails;

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
            return Firstname == other.Firstname 
                 && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() 
                & Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "firstname=" + Firstname 
                   + "\nlastname=" + Lastname;

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
                // return LastName.CompareTo(other.LastName);
                return 0;
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
        public ContactData()
        {
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string AllNames
        {
            get
            {
                if (allNames != null)
                {
                    return allNames;
                }
                else
                {
                    return (FirstName + " " + LastName).Trim();
                }
            }
            set
            {
                allNames = value;
            }
        }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone) + CleanUpPhone(WorkPhone)).Trim(); 
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmail
        {
            get
            {
                if (allEmail != null)
                {
                    return allEmail;
                }
                else
                {
                    return (CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3)).Trim();
                }
            }
            set
            {
                allEmail = value;
            }
        }

        public string TextInDetails
        {
            get
            {
                if (textInDetails != null)
                {
                    return textInDetails;
                }
                else
                {
                    return (
                        (CleanUpNameInDetails(FirstName) + " " + CleanUpNameInDetails(LastName)).Trim() + "\r\n"
                        + CleanUpAddressInDetails(Address)
                        + CleanUpPhoneInDetails(HomePhone, MobilePhone, WorkPhone)
                        + CleanUpTextInDetails(Email)
                        + CleanUpTextInDetails(Email2)
                        + CleanUpTextInDetails(Email3))
                        .Trim();
                }
            }
            set
            {
                textInDetails = value;
            }
        }

        private string CleanUpNameInDetails(object lastName)
        {
            throw new NotImplementedException();
        }

        public object LastName { get; private set; }
        public string FirstName { get; private set; }

        private string CleanUpPhoneInDetails(string homePhone, string mobilePhone, string workPhone)
        {
            var phones = new List<string>();

            if (!string.IsNullOrEmpty(homePhone))
            {
                phones.Add("H: " + homePhone);
            }

            if (!string.IsNullOrEmpty(mobilePhone))
            {
                phones.Add("M: " + mobilePhone);
            }

            if (!string.IsNullOrEmpty(workPhone))
            {
                phones.Add("W: " + workPhone);
            }

            if (phones.Count > 0)
            {
                return string.Join("\r\n", phones) + "\r\n\r\n";
            }

            return string.Empty;
        }

        private string CleanUpAddressInDetails(string address)
        {
            if (address == null || address == "")
            {
                return "\r\n";
            }
            return address + "\r\n\r\n";
        }
        private string CleanUpNameInDetails(string name)
        {
            if (name == null || name == "")
            {
                return "";
            }
            return name;
        }
        private string CleanUpTextInDetails(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return text + "\r\n";
        }
        private string CleanUpPhone(string phone)
        {
            if (phone == null || phone == "") 
            {
                return "";
            }

            return Regex.Replace(phone, "[ \\-()]", "") + "\r\n"; 
        }
        private string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }
    }
}
