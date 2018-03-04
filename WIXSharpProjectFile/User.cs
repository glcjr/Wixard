using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

/*********************************************************************************************************************************
Copyright and Licensing Message

This code is copyright 2018 Gary Cole Jr. 

This code is licensed by Gary Cole to others under the GPLv.3 https://opensource.org/licenses/GPL-3.0 
If you find the code useful or just feel generous a donation is appreciated.

Donate with this link: paypal.me/GColeJr
Please choose Friends and Family

Alternative Licensing Options

If you prefer to license under the LGPL for a project, https://opensource.org/licenses/LGPL-3.0
Single Developers working on their own project can do so with a donation of $20 or more. 
Small and medium companies can do so with a donation of $50 or more. 
Corporations can do so with a donation of $1000 or more.


If you prefer to license under the MS-RL for a project, https://opensource.org/licenses/MS-RL
Single Developers working on their own project can do so with a donation of $40 or more. 
Small and medium companies can do so with a donation of $100 or more.
Corporations can do so with a donation of $2000 or more.


if you prefer to license under the MS-PL for a project, https://opensource.org/licenses/MS-PL
Single Developers working on their own project can do so with a donation of $1000 or more. 
Small and medium companies can do so with a donation of $2000 or more.
Corporations can do so with a donation of $10000 or more.


If you use the code in more than one project, a separate license is required for each project.


Any modifications to this code must retain this message. 
*************************************************************************************************************************************/
namespace WIXSharpHelper 
{
    [Serializable]
    public class User: ISerializable
    {
        private string Name = "";
        private string Password = "";
        private string Domain = "";
        private bool Passwordneverexpire = true;

        public User()
        { }
        public User(string name, string password, string domain = "Environment.MachineName", bool pwneverexpire = true)
        {
            Name = name;
            Password = password;
            Domain = domain;
            Passwordneverexpire = pwneverexpire;
        }
        public User(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("name", typeof(string));
            Password = (string)info.GetValue("password", typeof(string));
            Domain = (string)info.GetValue("domain", typeof(string));            
            Passwordneverexpire = (bool)info.GetValue("pwnever", typeof(bool));
        }
        public string GetName()
        {
            return Name;
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public string GetPassword()
        {
            return Password;
        }
        public void SetPassword(string pw)
        {
            Password = pw;
        }
        public string GetDomain()
        {
            return Domain;
        }
        public void SetDomain(string dm)
        {
            Domain = dm;
        }
        public bool GetPasswordNeverExpires()
        {
            return Passwordneverexpire;
        }
        public void SetPasswordNeverExpires(bool doesit)
        {
            Passwordneverexpire = doesit;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", Name, typeof(string));
            info.AddValue("password", Password, typeof(string));
            info.AddValue("domain", Domain, typeof(string));            
            info.AddValue("pwnever", Passwordneverexpire, typeof(bool));
        }
        public string GetUserLine()
        {
            string line = $",{Environment.NewLine}new User(\"{Name}\") {Environment.NewLine} {{ Domain = {Domain},  Password = \"{Password}\",   PasswordNeverExpires = {Passwordneverexpire.ToString().ToLower()}, CreateUser = true {Environment.NewLine}            }}";
            return line;
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
