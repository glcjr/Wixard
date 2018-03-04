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
    public class WAttributes:ISerializable
    {
        List<WAttribute> Attributes = new List<WAttribute>();

        public WAttribute this[int index]
        {
            get
            {
                return Attributes[index];
            }
            set
            {
                Attributes[index] = value;
            }
        }
        public int Count
        {
            get
            {
                return Attributes.Count;
            }
        }
        public bool FindLabel(string Label, out int index)
        {
            return FindLabel(Label, 0, out index);
            //bool found = false;
            //int i = 0; index = -1;
            //foreach (var option in Attributes)
            //{
            //    if (option.GetLabel().Equals(Label))
            //    {
            //        found = true;
            //        index = i;
            //    }
            //    i++;
            //}
            //return found;
        }
        public bool FindLabel(string Label, int start, out int index)
        {
            bool found = false;
            int i = 0; index = -1;
            foreach (var option in Attributes)
            {
                if (i >= start)
                {
                    if (option.GetLabel().Equals(Label))
                    {
                        found = true;
                        index = i;
                    }
                }
                i++;
            }
            return found;
        }
        public WAttributes()
        {
            Attributes = new List<WAttribute>();
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("attribs", Attributes, typeof(List<WAttribute>));
        }
        public WAttributes(SerializationInfo info, StreamingContext context)
        {
            Attributes = (List<WAttribute>)info.GetValue("attribs", typeof(List<WAttribute>));
        }
        public void AddElement(string label, string value)
        {
            if (value != string.Empty)
                Attributes.Add(new WAttribute(label, value));
        }
        public void AddElement(WAttribute elem)
        {
            Attributes.Add(elem);
        }
        public string GetLine()
        {
            string line = "";            
            foreach (var w in Attributes)
                line += w.GetLine();
            return line;
        }
        public bool RemoveAt(int index)
        {
            try
            {
                Attributes.RemoveAt(index);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
