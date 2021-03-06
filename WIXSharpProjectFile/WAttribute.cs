﻿using System;
using System.Runtime.Serialization;
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
    public class WAttribute:ISerializable
    {
        string Label = "";
        string Value = "";

        public WAttribute()
        { }
        public WAttribute(string label, string value)
        {
            Label = label;
            Value = value;
        }
        public WAttribute(SerializationInfo info, StreamingContext context)
        {
            Label = (string)info.GetValue("label", typeof(string));
            Value = (string)info.GetValue("value", typeof(string));            
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("label", Label, typeof(string));
            info.AddValue("value", Value, typeof(string));          
        }
        public string GetLabel()
        {
            return Label;
        }
        public void SetLabel(string label)
        {
            Label = label;
        }
        public string GetValue()
        {
            return Value;
        }
        public void SetValue(string val)
        {
            Value = val;
        }
        public string GetLine()
        {
            if (Value != string.Empty)
                return $",{Environment.NewLine}new XAttribute(\"{Label}\", \"{Value}\")";
            else
                return "";
        }
        public override string ToString()
        {
            return $"{Label}, {Value}";
        }
    }
}
