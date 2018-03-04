using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class Certificates : ISerializable
    {
        private List<Certificate> Certs = new List<Certificate>();

        public Certificates()
        {
            Certs = new List<Certificate>();
        }
        public Certificates(List<Certificate> certs)
        {
            Certs = certs;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("certs", Certs, typeof(List<Certificate>));
        }
        public Certificates(SerializationInfo info, StreamingContext context)
        {
            Certs = (List<Certificate>)info.GetValue("certs", typeof(List<Certificate>));
        }
        public void Add(Certificate cert)
        {
            Certs.Add(cert);
        }
        public void Add(string name, string certificatepath, string storelocation = "localMachine", string storename = "personal", bool authorityrequest = false)
        {
            Certs.Add(new Certificate(name, certificatepath, storelocation, storename, authorityrequest));
        }
        public void Remove(Certificate cert)
        {
            Certs.Remove(cert);
        }
        public void Remove(int index)
        {
            Certs.RemoveAt(index);
        }
        public Certificate Get(int index)
        {
            return Certs[index];
        }
        public void Update(int index, Certificate cert)
        {
            Certs[index] = cert;
        }
        public List<Certificate> GetCerts()
        {
            return Certs;
        }
        public string GetCertificatesLine()
        {
            string line = "";
            if (Certs.Count > 0)
            {
                line = $",{Environment.NewLine}new Binary(new Id(\"mycert\"), @\"{Certs[0].GetCertificatePath()}\")";
                line += $"{Certs[0].GetCertificateLine().Replace($"@\"{Certs[0].GetCertificatePath()}\"", "\"mycert\"")}";
                for (int index = 1; index < Certs.Count; index++)
                    line += $"{Certs[index].GetCertificateLine()}";              
            }
            return line;
        }
        public ObservableCollection<Certificate> GetCertslist()
        {           
                var result = new ObservableCollection<Certificate>();
                foreach (var item in Certs)
                    result.Add(item);
                return result;            
        }
    }
}
