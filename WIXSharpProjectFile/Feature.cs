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
    public class Feature : ISerializable
    {
        private string VariableName = "";
        private string Name = "";
        private string Description = "";
        private bool IsEnabled = true;
        private bool AllowChanges = true;
        private string ConfigurableDir = "";

        public Feature()
        { }
        public Feature(string variable, string name, string description = "", bool enabled = true, bool allowchange = true, string configurableDir = "")
        {
            VariableName = variable;
            Name = name;
            Description = description;
            IsEnabled = enabled;
            AllowChanges = allowchange;
            ConfigurableDir = configurableDir;
        }
        public Feature(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("name", typeof(string));
            VariableName = (string)info.GetValue("variablename", typeof(string));
            Description = (string)info.GetValue("description", typeof(string));
            ConfigurableDir = (string)info.GetValue("configurabledir", typeof(string));
            IsEnabled = (bool)info.GetValue("isenabled", typeof(bool));
            AllowChanges = (bool)info.GetValue("allowchanges", typeof(bool));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", Name, typeof(string));
            info.AddValue("variablename", VariableName, typeof(string));
            info.AddValue("description", Description, typeof(string));
            info.AddValue("configurabledir", ConfigurableDir, typeof(string));
            info.AddValue("isenabled", IsEnabled, typeof(bool));
            info.AddValue("allowchanges", AllowChanges, typeof(bool));
        }
        public string GetDeclareLine()
        {
            string line = ");";
            bool addrest = false;
            if (ConfigurableDir != string.Empty)
            {
                line = $",\"{ConfigurableDir}\"{line}";
                addrest = true;
            }
            if ((AllowChanges == false)||(addrest))
            {
                line = $",{AllowChanges.ToString().ToLower()}{line}";
                addrest = true;
            }
            if ((IsEnabled == false)||(addrest))
            {
                line = $",{IsEnabled.ToString().ToLower()}{line}";
                addrest = true;
            }
            if ((Description != string.Empty)||(addrest))
                {
                line = $",\"{Description}\"{line}";
                addrest = true;
            }
            return $"var {VariableName}= new Feature(\"{Name}\"{line}{Environment.NewLine}";
        }
        public string GetVariableName()
        {
            return VariableName;
        }
        public string GetName()
        {
            return Name;
        }
        public string GetDescription()
        {
            return Description;
        }
        public string GetConfigurableDir()
        {
            return ConfigurableDir;
        }
        public bool ReturnIsEnabled()
        {
            return IsEnabled;
        }
        public bool ReturnAllowChanges()
        {
            return AllowChanges;
        }
        public void SetVariableName(string nm)
        {
            VariableName = nm;
        }
        public void SetName(string nm)
        {
            Name = nm;
        }
        public void SetDescription(string desc)
        {
            Description = desc;
        }
        public void SetConfigurableDir(string dir)
        {
            ConfigurableDir = dir;
        }
        public void SetIsEnabled(bool enabled)
        {
            IsEnabled = enabled;
        }
        public void SetAllowChanges(bool allow)
        {
            AllowChanges = allow;
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
