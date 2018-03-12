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
    public class SetupOptions: ISerializable
    {
        private string needednetwixid = "";
        private string netwixidtoinstall = "";
        private bool includeuninstall = true;
        private bool includeoptionaldesktopshortcut = false;
        private bool customactions = false;
        private bool build64 = false;
        private bool promptreboot = false;

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("needednetwixid", needednetwixid, typeof(string));
            info.AddValue("netwixidtoinstall", netwixidtoinstall, typeof(string));
            info.AddValue("includeuninstall", includeuninstall, typeof(bool));
            info.AddValue("optionaldesktopshortcut", includeoptionaldesktopshortcut, typeof(bool));
            info.AddValue("customactions", customactions, typeof(bool));
            info.AddValue("build64", build64, typeof(bool));
            info.AddValue("promptreboot", promptreboot, typeof(bool));
        }
        public SetupOptions(SerializationInfo info, StreamingContext context)
        {
            needednetwixid = (string)info.GetValue("needednetwixid", typeof(string));
            netwixidtoinstall = (string)info.GetValue("netwixidtoinstall", typeof(string));
            includeuninstall = (bool)info.GetValue("includeuninstall", typeof(bool));
            includeoptionaldesktopshortcut = (bool)info.GetValue("optionaldesktopshortcut", typeof(bool));
            customactions = (bool)info.GetValue("customactions", typeof(bool));
            build64 = (bool)info.GetValue("build64", typeof(bool));
            promptreboot = (bool)info.GetValue("promptreboot", typeof(bool));
        }
        public SetupOptions()
        {
            needednetwixid = "";
            netwixidtoinstall = "";
            includeuninstall = true;
        }
        public void SetIncludeUninstall(bool uninstall)
        {
            includeuninstall = uninstall;
        }
        public void SetMinimumNetVersion(string WixNetID)
        {
            needednetwixid = WixNetID;
        }
        public void SetOptionalDesktopShortcut(bool desktopshortcut)
        {
            includeoptionaldesktopshortcut = desktopshortcut;
            if (desktopshortcut)
                customactions = true;
        }
        
        public void SetBuild64(bool value)
        {
            build64 = value;
        }
        public void SetPromptReboot(bool value)
        {
            promptreboot = value;
            if (promptreboot)
                customactions = true;
        }
        public bool GetPromptReboot()
        {
            return promptreboot;
        }
        public void NetVersionToInstall(string WixCommandID)
        {
            netwixidtoinstall = WixCommandID;
        }
        public bool GetIncludeUninstall()
        {
            return includeuninstall;
        }
        public string GetMinimumNetVersion()
        {
            return needednetwixid;
        }
        public string GetNettoInstall()
        {
            return netwixidtoinstall;
        }
        public bool GetOptionalDesktopShortcut()
        {
            return includeoptionaldesktopshortcut;
        }
        public string GetShortcutDesktopLines()
        {
            string line = $",{Environment.NewLine}new Property(\"INSTALLDESKTOPSHORTCUT\", \"no\"),{Environment.NewLine}new ManagedAction(CustomActions.DesktopShortcut, Return.ignore, When.Before, Step.LaunchConditions, Condition.NOT_Installed, Sequence.InstallUISequence)";
            return line;
        }
        public string GetRebootLine()
        {
            string line = $", {Environment.NewLine}new ManagedAction(CustomActions.PromptToReboot)";
            return line;
        }
        public bool GetBuild64()
        {
            return build64;
        }
        public bool GetCustomActions()
        {
            return customactions;
        }

        internal void SetCustomActions(bool v)
        {
            customactions = v;
        }
    }
}
