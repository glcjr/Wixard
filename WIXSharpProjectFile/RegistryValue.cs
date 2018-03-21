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
    public enum RegistryHive { ClassesRoot, CurrentConfig, CurrentUser, DynData, LocalMachine, PerformanceData, Users };
    [Serializable]
    public class RegistryValue:ISerializable
    {        
        private RegistryHive Root = RegistryHive.CurrentUser;
        private string Key = "";
        private string Name = "";
        private object Value = "";
        private string FeatureName = "";

        public RegistryValue()
        { }
        public RegistryValue(RegistryHive root, string key, string nm, object value)
        {
            Root = root;
            Key = key;
            Name = nm;
            Value = value;
        }
        public RegistryValue(SerializationInfo info, StreamingContext ctxt)
        {
            Root = (RegistryHive)info.GetValue("Root", typeof(RegistryHive));
            Key = (string)info.GetValue("Key", typeof(string));
            Name = (string)info.GetValue("Name", typeof(string));
            Value = (object)info.GetValue("Value", typeof(object));
            FeatureName = (string)info.GetValue("FeatureName", typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Root", this.Root, typeof(RegistryHive));
            info.AddValue("Key", this.Key, typeof(string));
            info.AddValue("Name", this.Name, typeof(string));
            info.AddValue("Value", this.Value, typeof(object));
            info.AddValue("FeatureName", this.FeatureName, typeof(string));
        }

        public void SetRoot(RegistryHive root)
        {
            Root = root;
        }
        public RegistryHive GetRoot()
        {
            return Root;
        }
        public void SetKey(string key)
        {
            Key = key;
        }
        public string GetKey()
        {
            return Key;
        }
        public void SetName(string nm)
        {
            Name = nm;
        }
        public string GetName()
        {
            return Name;
        }
        public void SetValue(object val)
        {
            Value = val;
        }
        public object GetValue()
        {
            return Value;
        }
        public void SetFeature(string featname)
        {
            FeatureName = featname;
        }
        private string GetRootName()
        {
            switch (Root)
            {
                case RegistryHive.ClassesRoot:
                    return "RegistryHive.ClassesRoot";
                case RegistryHive.CurrentConfig:
                    return "RegistryHive.CurrentConfig";
                case RegistryHive.CurrentUser:
                    return "RegistryHive.CurrentUser";
                case RegistryHive.DynData:
                    return "RegistryHive.DynData";
                case RegistryHive.LocalMachine:
                    return "RegistryHive.LocalMachine";
                case RegistryHive.PerformanceData:
                    return "RegistryHive.PerformanceData";
                case RegistryHive.Users:
                    return "RegistryHive.Users";
                default:
                    return "";
            }
        }
        public string GetLine()
        {
            string line = $", {Environment.NewLine}new RegValue(";
            if (FeatureName != string.Empty)
                line += $"{FeatureName},";
            line += $"{GetRootName()}, @\"{Key}\", \"{Name}\",";
            if (Value.GetType() == typeof(string))
                line += $"\"{Value}\"";
            else if (Value.GetType() == typeof(char))
                line += $"'{Value}'";
            else if (Value.GetType() == typeof(bool))
                line += $"{Value.ToString().ToLower()}";
            else
                line += $"{Value}";
            line+= $")"; 
            return line;
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
