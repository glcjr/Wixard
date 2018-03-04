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
    public class SigningInfo : ISerializable
    {
        private bool signinstaller = false;
        private string certificatepath = "";
        private string timestampurl = "";
        private string certpassword = "";
        private string options = "";
        private string WixWellKnownLocation = "";

        public SigningInfo()
        {
            signinstaller = false;
            certificatepath = "";
            timestampurl = "";
            certpassword = "";
            options = "";
            WixWellKnownLocation = Environment.GetEnvironmentVariable("WIX");
            if (WixWellKnownLocation == null)
                WixWellKnownLocation = "";
        }
        public SigningInfo(string path, string timestamp, string password, string option)
        {
            signinstaller = true;
            certificatepath = path;
            timestampurl = timestamp;
            certpassword = password;
            options = option;
            WixWellKnownLocation = Environment.GetEnvironmentVariable("WIX");
            if (WixWellKnownLocation == null)
                WixWellKnownLocation = "";
        }
        public SigningInfo(SerializationInfo info, StreamingContext context)
            {
            signinstaller = (bool)info.GetValue("signinstall", typeof(bool));
            certificatepath = (string) info.GetValue("certpath", typeof(string));
            timestampurl = (string)info.GetValue("timestamp", typeof(string));
            certpassword = (string)info.GetValue("certpassword", typeof(string));
            options = (string)info.GetValue("options", typeof(string));
            WixWellKnownLocation = (string)info.GetValue("wixlocation", typeof(string));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("signinstall", signinstaller, typeof(bool));
            info.AddValue("certpath", certificatepath, typeof(string));
            info.AddValue("timestamp", timestampurl, typeof(string));
            info.AddValue("certpassword", certpassword, typeof(string));
            info.AddValue("options", options, typeof(string));
            info.AddValue("wixlocation", WixWellKnownLocation, typeof(string));
        }
        public void SignInstaller()
        {
            signinstaller = true;
        }
        public void SetCertificatePath(string path)
        {
            certificatepath = path;
        }
        public void SetTimestampUrl(string url)
        {
            timestampurl = url;
        }
        public void SetCertificatePassword(string password)
        {
            certpassword = password;
        }
        public void SetOptions(string option)
        {
            options = option;
        }
        public void SetWixWellKnownLocation(string location, bool makeenvironment = false)
        {
            WixWellKnownLocation = location;
            if (makeenvironment)
                SetWixEnvironmentVariable();            
        }
        public void SetWixEnvironmentVariable()
        {
            Environment.SetEnvironmentVariable("WIX", WixWellKnownLocation);
        }
        public string GetWixWellKnownLocation()
        {
            return WixWellKnownLocation;
        }
        public string GetSigningLine(string filetosign)
        {
            string temp = "";
            if (signinstaller)
            {
                temp = $"Tasks.DigitalySign({filetosign}, @\"{certificatepath}\", \"{timestampurl}\", \"{certpassword}\", \"{options}\");{Environment.NewLine}";
            }
            return temp;
        }
        public bool GetSignInstaller()
        {
            return signinstaller;
        }
        public string GetCertificatePath()
        {
            return certificatepath;
        }
        public string GetCertPassword()
        {
            return certpassword;
        }
        public string GetTimestamp()
        {
            return timestampurl;
        }
        public string GetOptions()
        {
            return options;
        }
        public void SetSignInstaller(bool value)
        {
            signinstaller = value;
        }
       
    }
   
}
