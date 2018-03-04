﻿using System;
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
    public class EnvironmentVar : ISerializable
    {
        private string Name = "";
        private string Directory= "[INSTALLDIR]";
        private string Placement = "EnvVarPart.last";
        private string Condition = "";

        public EnvironmentVar()
        {  }
        public EnvironmentVar(string varnm, string dir = "[INSTALLDIR]", string placement = "EnvVarPart.last", string condition = "")
        {
            Name = varnm;
            Directory = dir;
            Placement = placement;
            Condition = condition;
        }
        public EnvironmentVar(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("name", typeof(string));
            Directory = (string)info.GetValue("dir", typeof(string));
            Placement = (string)info.GetValue("placement", typeof(string));
            Condition = (string)info.GetValue("condition", typeof(string));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name", Name, typeof(string));
            info.AddValue("dir", Directory, typeof(string));
            info.AddValue("placement", Placement, typeof(string));
            info.AddValue("condition", Condition, typeof(string));
        }
        public void SetName(string nm)
        {
            Name = nm;
        }
        public void SetDirectory(string dir)
        {
            Directory = dir;
        }
        public void SetPlacement(string placement)
        {
            Placement = placement;
        }
        public void SetCondition(string condition)
        {
            Condition = condition;
        }
        public string GetName()
        {
            return Name;
        }
        public string GetDirectory()
        {
            return Directory;
        }
        public string GetPlacement()
        {
            return Placement;
        }
        public string GetCondition()
        {
            return Condition;
        }
        public string GetLine()
        {
            string line = $", {Environment.NewLine}new EnvironmentVariable(\"{Name}\", \"{Directory}\")";
            if ((Placement != string.Empty) || (Condition != string.Empty))
            {
                line += $"{{";
                if (Placement != string.Empty)
                {
                    line += $"Part = {Placement}";
                    if (Condition != string.Empty)
                        line += ",";
                }
                if (Condition != string.Empty)
                {
                    line += $"Condition = {Condition}";
                }
                line += $"}}";
            }
            return line;
        }
        public override string ToString()
        {
            return $"{Name}";
        }

    }
}
