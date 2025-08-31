using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class ContactData
    {
        private string firstname;
        private string lastname = "";
        private string address = "";
        private string email = "";
        private string mobile = "";

        public ContactData(string firstname)
        {
            this.firstname = firstname;
        }
        public ContactData(string firstname, string address, string lastname, string email, string mobile)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.address = address;
            this.email = email;
            this.mobile = mobile;

        }
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;

            }
        }
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
    }
}

