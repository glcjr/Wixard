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
    public class EnvironmentVars:ISerializable
    {
        List<EnvironmentVar> Variables = new List<EnvironmentVar>();

        public EnvironmentVars()
        {
            Variables = new List<EnvironmentVar>();
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("evars", Variables, typeof(List<User>));
        }
        public EnvironmentVars(SerializationInfo info, StreamingContext context)
        {
            Variables = (List<EnvironmentVar>)info.GetValue("evars", typeof(List<EnvironmentVar>));
        }
        public void Add(string varnm, string dir = "[INSTALLDIR]", string placement = "", string condition = "")
        {
            Variables.Add(new EnvironmentVar(varnm, dir, placement, condition));
        }
        public void Add(EnvironmentVar var)
        {
            Variables.Add(var);
        }
        public void Remove(EnvironmentVar var)
        {
            Variables.Remove(var);
        }
        public void Remove(string nm)
        {
            foreach (var v in Variables)
                if (v.GetName().Equals(nm))
                    Variables.Remove(v);
        }
        public string GetLine()
        {
            string line = "";
            foreach (var v in Variables)
                line += v.GetLine();
            return line;
        }
        public ObservableCollection<EnvironmentVar> GetEvarslist()
        {
            var result = new ObservableCollection<EnvironmentVar>();
            foreach (var item in Variables)
                result.Add(item);
            return result;
        }
        public void Remove(int index)
        {
            Variables.RemoveAt(index);
        }
        public EnvironmentVar Get(int index)
        {
            return Variables[index];
        }
        public void Update(int index, EnvironmentVar evar)
        {
            Variables[index] = evar;
        }
    }
}
