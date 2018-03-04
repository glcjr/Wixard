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
    public class Features :ISerializable
    {
        List<Feature> FeatureList = new List<Feature>();
        public Features()
        {
            FeatureList = new List<Feature>();
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("featurelist", FeatureList, typeof(List<Feature>));
        }
        public Features(SerializationInfo info, StreamingContext context)
        {
            FeatureList = (List<Feature>)info.GetValue("featurelist", typeof(List<Feature>));
        }
        public ObservableCollection<Feature> GetFeatureslist()
        {
            var result = new ObservableCollection<Feature>();
            foreach (var item in FeatureList)
                result.Add(item);
            return result;
        }
        public ObservableCollection<string> GetFeaturesVariableNames()
        {
            var result = new ObservableCollection<string>();
            result.Add("None");
            foreach (var item in FeatureList)
                result.Add(item.GetVariableName());
            return result;
        }
        public void Add(Feature feature)
        {
            if (!(IsThere(feature.GetVariableName())))
                FeatureList.Add(feature);
        }
        public void Add(string variable, string name, string description = "", bool enabled = true, bool allowchange = true, string configurableDir = "")
        {
            Feature feature = new Feature(variable, name, description, enabled, allowchange, configurableDir);
            Add(feature);
        }
        public void Remove(Feature feature)
        {
            FeatureList.Remove(feature);
        }
        public void Remove(string variablename)
        {
            foreach (var f in FeatureList)
                if (f.GetVariableName().Equals(variablename))
                    FeatureList.Remove(f);
        }
        public bool IsThere(string variablename)
        {
            foreach (var f in FeatureList)
                if (f.GetVariableName().Equals(variablename))
                    return true;
            return false;
        }
        public string GetLine()
        {
            string line = "";
            foreach (var f in FeatureList)
                line += f.GetDeclareLine();
            return line;
        }
        public void Remove(int index)
        {
            FeatureList.RemoveAt(index);
        }
        public Feature Get(int index)
        {
            return FeatureList[index];
        }
        public void Update(int index, Feature feat)
        {
            FeatureList[index] = feat;
        }
    }
}
