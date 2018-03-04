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
    public class FirewallException:ISerializable
    {
        private string Name = "";
        private WAttributes Options = new WAttributes();
        private string[] builtin = { "RemoteAddress", "Port" };
        public FirewallException()
        {
            Options.AddElement("RemoteAddress", " ");
        }
        public FirewallException(string name, string remoteaddress)
        {
            Name = name;
            Options.AddElement("RemoteAddress", remoteaddress);
        }
        public FirewallException(string name, string remoteaddress, string port): this(name, remoteaddress)
        {            
            Options.AddElement("Port", port);
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", Name, typeof(string));
            info.AddValue("options", Options, typeof(WAttributes));
        }
        public FirewallException(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("name", typeof(string));
            Options = (WAttributes)info.GetValue("options", typeof(WAttributes));
        }
        public void SetRemoteAddress(string remoteaddress)
        {           
            Options[0].SetValue(remoteaddress.Trim());
        }
        public void AddtoRemoteAddress(string additionaladdress)
        {
            Options[0].SetValue($"{Options[0].GetValue()},{additionaladdress}");
        }
        private bool isthere(string label, out int index)
        {
            index = -1;
            return Options.FindLabel(label, out index);
        }
        public void SetPort(string port)
        {
            if (isthere("Port", out int index))
                Options[index].SetValue(port);
            else
               Options.AddElement("Port", port);
        }
        public void AddOptionalElement(string label, string value)
        {
            if (isthere(label, out int index))
                Options[index].SetValue(value);
            else
                Options.AddElement(label, value);
        }
        public string GetLine()
        {
            string line = $", new FirewallException(\"{Name}\"){Environment.NewLine}";
            line += $"{{ {Environment.NewLine} RemoteAddress = \"{Options[0].GetValue()}\".Split(',')";
            for (int index = 1; index < Options.Count; index++)
                line += $", {Environment.NewLine} {Options[index].GetLabel()} = \"{Options[index].GetValue()}\"";
            line += $"{Environment.NewLine}}}";
            return line;
        }
        public string GetName()
        {
            return Name;
        }
        public string GetRemoteAddress()
        {
            return GetValue("RemoteAddress");
        }
        public string GetValue(string label)
        {
            if (isthere(label, out int index))
                return Options[index].GetValue();
            else
                return "";
        }
        public string GetPort()
        {
            return GetValue("Port");
        }
        public void SetName(string nm)
        {
            Name = nm;
        }
        public ObservableCollection<WAttribute> GetCustomFirewallExceptionlist()
        {
            ObservableCollection<WAttribute> temp = new ObservableCollection<WAttribute>();
            List<string> BuiltIn = new List<string>(builtin);
            for (int index = 0; index < Options.Count; index++)
            {
                if (!(BuiltIn.Contains(Options[index].GetLabel())))
                    temp.Add(Options[index]);
            }
            return temp;
        }
        public void UpdateCustomElement(string oldlabel, string oldvalue, string label, string value)
        {
            bool found = false;
            for (int index = 0; index < Options.Count; index++)
                if ((Options[index].GetLabel().Equals(oldlabel)) && (!found))
                {
                    if (Options[index].GetValue().Equals(oldvalue))
                    {
                        found = true;
                        Options[index].SetLabel(label);
                        Options[index].SetValue(value);
                    }
                }
        }
        public void RemoveCustomElement(string oldlabel, string oldvalue)
        {
            int index = 0;
            bool found = false;
            while ((Options.FindLabel(oldlabel, index, out index)) && (!found))
            {
                if (Options[index].GetValue().Equals(oldvalue))
                {
                    Options.RemoveAt(index);
                    found = true;
                }
            }         
        }
        public void AddCustomElement(WAttribute attri)
        {
            Options.AddElement(attri);
        }
        public override string ToString()
        {
            return $"{Name}";
        }

    }
}
