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
    public class Certificate :ISerializable
    {
        private string Name = "";
        private string StoreLocation = "";
        private string StoreName = "";
        private string CertificatePath = "";
        private bool AuthorityRequest = false;
        public Certificate()
        {
        }
        public Certificate(string name, string certificatepath, string storelocation="localMachine", string storename= "personal", bool authorityrequest = false )
        {
            Name = name;
            CertificatePath = certificatepath;
            StoreLocation = $"StoreLocation.{storelocation}";
            StoreName = $"StoreName.{storename}";
            AuthorityRequest = authorityrequest;            
        }
        private void checkstore()
        {
            StoreLocation = StoreLocation.Replace("StoreLocation.StoreLocation.", "StoreLocation.");
            StoreName = StoreName.Replace("StoreName.StoreName.", "StoreName.");
        }
        public string GetCertificateLine()
        {
            checkstore();
            string ar = AuthorityRequest.ToString().ToLower();
            return $",{Environment.NewLine}new Certificate(\"{Name}\", {StoreLocation}, {StoreName}, @\"{CertificatePath}\", authorityRequest: {ar})";
        }
        public Certificate(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("name", typeof(string));
            StoreLocation = (string)info.GetValue("storelocation", typeof(string));
            StoreName = (string)info.GetValue("storename", typeof(string));
            CertificatePath = (string)info.GetValue("certificatepath", typeof(bool));
            AuthorityRequest = (bool)info.GetValue("authorityrequest", typeof(bool));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", Name, typeof(string));
            info.AddValue("storelocation", StoreLocation, typeof(string));
            info.AddValue("storename", StoreName, typeof(string));
            info.AddValue("certificatepath", CertificatePath, typeof(string));
            info.AddValue("authorityrequest", AuthorityRequest, typeof(bool));
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public void SetStoreLocation(string location)
        {
            StoreLocation = $"StoreLocation.{location}";
        }
        public void SetStoreName(string name)
        {
            StoreName = $"StoreName.{name}";
        }
        public void SetCertificatePath(string path)
        {
            CertificatePath = path;
        }
        public void SetAuthorityRequest(bool authorityrequest)
        {
            AuthorityRequest = authorityrequest;
        }
        public string GetName()
        {
            return Name;
        }
        public string GetStoreLocation()
        {
            checkstore();
            return StoreLocation;
        }
        public string GetStoreName()
        {
            checkstore();
            return StoreName;
        }
        public string GetCertificatePath()
        {
            return CertificatePath;
        }
        public bool GetAuthorityRequest()
        {
            return AuthorityRequest;
        }
        public override string ToString()
        {
            return $"{Name} {StoreName}";
        }

    }
}
