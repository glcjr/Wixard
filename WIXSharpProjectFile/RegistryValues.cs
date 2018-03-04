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
    public class RegistryValues : ISerializable
    {
        private List<RegistryValue> Registryvalues = new List<RegistryValue>();

        public RegistryValues()
        {
            Registryvalues = new List<RegistryValue>();
        }

        public RegistryValues(List<RegistryValue> registryvalues)

        {
            Registryvalues = registryvalues;
        }    
        public int Count
        {
            get
            {
                return Registryvalues.Count;
            }
        }
        public RegistryValues(SerializationInfo info, StreamingContext ctxt)
        {
            Registryvalues = (List<RegistryValue>)info.GetValue("Registryvalues", typeof(List<RegistryValue>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Registryvalues", this.Registryvalues);
        }

        public List<RegistryValue> GetRegistryvalues()
        {
            return Registryvalues;
        }

        public void SetRegistryvalues(List<RegistryValue> value)
        {
            Registryvalues = value;
        }
        public void Add(RegistryValue regvalue)
        {
            Registryvalues.Add(regvalue);
        }
        public void Add(RegistryHive root, string key, string nm, object value)
        {
            Registryvalues.Add(new RegistryValue(root, key, nm, value));
        }
        public string GetLine()
        {
            string line = "";
            foreach (var r in Registryvalues)
                line += r.GetLine();
            return line;
        }
        public ObservableCollection<RegistryValue> GetRegistryValueslist()
        {
            var result = new ObservableCollection<RegistryValue>();
            foreach (var item in Registryvalues)
                result.Add(item);
            return result;
        }
        public void Remove(int index)
        {
            Registryvalues.RemoveAt(index);
        }
        public RegistryValue Get(int index)
        {
            return Registryvalues[index];
        }
        public void Update(int index, RegistryValue elem)
        {
            Registryvalues[index] = elem;
        }
    }
}
