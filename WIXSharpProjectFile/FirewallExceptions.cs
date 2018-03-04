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
    public class FirewallExceptions : ISerializable
    {
        List<FirewallException> FirewallExcep = new List<FirewallException>();

        public FirewallExceptions()
        {
            FirewallExcep = new List<FirewallException>();
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("firewallexcep", FirewallExcep, typeof(List<FirewallException>));
        }
        public FirewallExceptions(SerializationInfo info, StreamingContext context)
        {
            FirewallExcep = (List<FirewallException>)info.GetValue("firewallexcep", typeof(List<FirewallException>));
        }
        public FirewallException this[int index]
        {
            get
            {
                return FirewallExcep[index];
            }
            set
            {
                FirewallExcep[index] = value;
            }
        }
        public int Count
        {
            get
            {
                return FirewallExcep.Count;
            }
        }
        public bool FindName(string name, out int index)
        {
            bool found = false;
            int i = 0; index = -1;
            foreach (var option in FirewallExcep)
            {
                if (option.GetName().Equals(name))
                {
                    found = true;
                    index = i;
                }
                i++;
            }
            return found;
        }
        public FirewallException GetFirewallException(string name)
        {
            if (FindName(name, out int index))
                return FirewallExcep[index];
            else
                return new FirewallException(name, "");
        }
        public void Add(FirewallException exception)
        {
            FirewallExcep.Add(exception);
        }
        public string GetLine()
        {
            string line = "";
            foreach (var excep in FirewallExcep)
                line += excep.GetLine();
            return line;
        }
        public ObservableCollection<FirewallException> GetFirewallExceptionslist()
        {
            var result = new ObservableCollection<FirewallException>();
            foreach (var item in FirewallExcep)
                result.Add(item);
            return result;
        }
        public void Remove(int index)
        {
            FirewallExcep.RemoveAt(index);
        }
        public FirewallException Get(int index)
        {
            return FirewallExcep[index];
        }
        public void Update(int index, FirewallException elem)
        {
            FirewallExcep[index] = elem;
        }
    }
}
