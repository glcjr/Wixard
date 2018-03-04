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
    public class Element:ISerializable
    {
        private string XMLRoot = "";
        private string ElementName = "";
        private WAttributes Attributes = new WAttributes();
        private string[] builtin = { "ID", "Title", "Value", "Absent", "Level", "Guid" };

        public Element()
        { }
        public Element(string EleName, string Id, string val, string Root="Product")
        {
            XMLRoot = Root;
            ElementName = EleName;
            Attributes.AddElement("ID", Id);
            Attributes.AddElement("Value", val);
        }
        public Element(string EleName, string Id, bool assignguid = false, string value = "", string title = "", string absent = "", string level = "", string root = "Product")
        {
            XMLRoot = root;
            ElementName = EleName;
           
            AddElement("ID", Id);
            AddElement("Title", title);
            AddElement("Value", value);
            AddElement("Absent", absent);
            AddElement("Level", level);
            if (assignguid)
                AddElement("Guid", Guid.NewGuid().ToString());            
        }
        public ObservableCollection<WAttribute> GetCustomElementlist()
        {
            ObservableCollection<WAttribute> temp = new ObservableCollection<WAttribute>();
            List<string> BuiltIn = new List<string>(builtin);
            for (int index = 0; index < Attributes.Count; index++)
            {
                if (!(BuiltIn.Contains(Attributes[index].GetLabel())))
                    temp.Add(Attributes[index]);
            }
            return temp;
        }
        public WAttributes GetAttributes()
        {
            return Attributes;
        }
        public void SetAttributes(WAttributes attributes)
        {
            Attributes = attributes;
        }
        private void AddElement(string label, string value)
        {
            if (value != string.Empty)
                Attributes.AddElement(label, value);
        }
        public Element(SerializationInfo info, StreamingContext context)
        {
            XMLRoot = (string)info.GetValue("xmlroot", typeof(string));
            ElementName = (string)info.GetValue("ename", typeof(string));
            Attributes = (WAttributes)info.GetValue("waattributes", typeof(WAttributes));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("xmlroot", XMLRoot, typeof(string));
            info.AddValue("ename", ElementName, typeof(string));
            info.AddValue("waatributes", Attributes, typeof(List<WAttribute>));

        }
        public string GetElementName()
        {
            return ElementName;
        }
        public void SetElementName(string nm)
        {
            ElementName = nm;
        }
        public string GetXMLRoot()
        {
            return XMLRoot;
        }
        public void SetXMLRoot(string root)
        {
            XMLRoot = root;
        }        
        public void SetID(string id)
        {
            AddElement("ID", id);
        }
        
        public void SetValue(string val)
        {
            AddElement("Value", val); 
        }
        public void SetTitle(string title)
        {
            AddElement("Title", title);
        }
        public void SetAbsent(string absent)
        {
            AddElement("Absent", absent);
        }
        public void AddCustomElement(string label, string value)
        {
            AddElement(label, value);
        }
        public void AddCustomElement(WAttribute elem)
        {
            Attributes.AddElement(elem);
        }
        public void UpdateCustomElement(string oldlabel, string oldvalue, string label, string value)
        {
            bool found = false;
            for (int index = 0; index < Attributes.Count; index++)
                if ((Attributes[index].GetLabel().Equals(oldlabel))&&(!found))
                {
                    if (Attributes[index].GetValue().Equals(oldvalue))
                    {
                        found = true;
                        Attributes[index].SetLabel(label);
                        Attributes[index].SetValue(value);
                    }
                }
        }
        public void RemoveCustomElement(string oldlabel, string oldvalue)
        {
            int index = 0;
            bool found = false;
            while ((Attributes.FindLabel(oldlabel, index, out index))&&(!found))
            {
                if (Attributes[index].GetValue().Equals(oldvalue))
                {
                    Attributes.RemoveAt(index);
                    found = true;
                }
            }
            //bool found = false;
            //for (int index = 0; index < Attributes.Count; index++)
            //    if ((Attributes[index].GetLabel().Equals(oldlabel)) && (!found))
            //    {
            //        if (Attributes[index].GetValue().Equals(oldvalue))
            //        {
            //            found = true;
            //            Attributes.RemoveAt(index);
                        
            //        }
            //    }
        }
        public void SetLevel(string level)
        {
            AddElement("Level", level);
        }
        
        public void SetAssignGuid(string guid="")
        {
            if (guid == string.Empty)
                AddElement("Guid", Guid.NewGuid().ToString());
            else
                AddElement("Guid", guid);            
        }
        public string GetID()
        {
            return GetElement("ID");
        }
        public string GetValue()
        {
            return GetElement("Value");
        }
        public string GetTitle()
        {
            return GetElement("Title");
        }
        public string GetAbsent()
        {
            return GetElement("Absent");
        }
        public string GetLevel()
        {
            return GetElement("Level");
        }
        public string GetGuid()
        {
            return GetElement("Guid");
        }
        public string GetCustomElement(string elem)
        {
            return GetElement(elem);
        }
        private string GetElement(string elenm)
        {
            bool found = false;
            int index = 0;
            while ((!found) && (index < Attributes.Count))
            {
                if (Attributes[index].GetLabel().Equals(elenm))
                {
                    found = true;
                    return Attributes[index].GetValue();
                }
                index++;
            }
            return "";
        }
        public string GetLine()
        {
            string line = "";
            line = $"{Environment.NewLine}productElement = document.Root.Select(\"{XMLRoot}\");{Environment.NewLine}productElement.Add(new XElement(\"{ElementName}\"";
            line += Attributes.GetLine();
            line += "));";
            return line;
        }
        public override string ToString()
        {
            return $"{ElementName}";
        }

    }
}
