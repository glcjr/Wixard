using System;
using System.Collections.Generic;
using System.Text;
using WIXSharpHelper;
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
namespace WixSharpScriptBuilder
{
    public static class SharedMethods
    {
        public static string GetStandardUsings(Elements WElements, RegistryValues Registryvalues)
        {
            string line = $"using System;{Environment.NewLine}using WixSharp;{Environment.NewLine}";
            if (Registryvalues.Count > 0)
                line += $"{Environment.NewLine}using Microsoft.Win32;";
            return line;
        }
        public static string GetUsings(SetupOptions Options, Elements WElements, RegistryValues Registryvalues)
        {
            string line = $"using System;{Environment.NewLine}using WixSharp;{Environment.NewLine}";
            line += $"using WixSharp.CommonTasks;{Environment.NewLine}using WixSharp.Bootstrapper; {Environment.NewLine}";
            if (Options.GetCustomActions())
                line += $"using Microsoft.Deployment.WindowsInstaller; {Environment.NewLine}using System.Windows.Forms;";
            if (WElements.Count > 0)
                line += $"using System.Linq;{Environment.NewLine}using System.Xml;{Environment.NewLine}using System.Xml.Linq; ";
            if (Registryvalues.Count > 0)
                line += $"{Environment.NewLine}using Microsoft.Win32;";
            if (Options.GetPromptReboot())
                line += $"{Environment.NewLine}using System.Diagnostics;";
            line += $"{Environment.NewLine}";
            return line;
        }
        public static string adduninstallmethod(string installdir)
        {
            return $"{Environment.NewLine}static public void Project_AfterInstall(SetupEventArgs e){Environment.NewLine}{{ {Environment.NewLine} \tif (e.IsUninstalling) {Environment.NewLine} {{  {Environment.NewLine} \tif (System.IO.Directory.Exists(@\"{installdir}\")) {Environment.NewLine} \tSystem.IO.Directory.Delete(@\"{installdir}\", recursive: true); {Environment.NewLine} }} {Environment.NewLine} }}";
        }
        public static string GetCustomActions(SetupOptions Options)
        {
            string line = "";
            if (Options.GetCustomActions())
            {
                line += $"{Environment.NewLine}public class CustomActions {Environment.NewLine}{{ {Environment.NewLine} \t";
                if (Options.GetOptionalDesktopShortcut())
                {
                    line += $"[CustomAction] {Environment.NewLine} public static ActionResult DesktopShortcut(Session session){Environment.NewLine} {{ {Environment.NewLine}\t";
                    line += $" if (DialogResult.Yes == MessageBox.Show(\"Do you want to install desktop shortcut\", \"Installation\", MessageBoxButtons.YesNo)) {Environment.NewLine}\tsession[\"INSTALLDESKTOPSHORTCUT\"] = \"yes\"; {Environment.NewLine} \t return ActionResult.Success; {Environment.NewLine} }} {Environment.NewLine}";
                }
                if (Options.GetPromptReboot())
                {
                    line += $"[CustomAction]{Environment.NewLine}  public static ActionResult PromptToReboot(Session session){Environment.NewLine}    {{ {Environment.NewLine}\t";
                    line += $"if (DialogResult.Yes == MessageBox.Show(\"You need to reboot the system. Do you want to reboot now?\", \"ReboolTest\", MessageBoxButtons.YesNo))";
                    line += $"{Environment.NewLine} {{ {Environment.NewLine} \tProcess.Start(\"shutdown.exe\", \"-r -t 30 -c \\\"Reboot has been requested from RebootTest.msi\\\"\");";
                    line += $"{Environment.NewLine} }} {Environment.NewLine} \treturn ActionResult.Success; }}";
                }
                line += $"}} {Environment.NewLine}";
            }
            return line;
        }
    }
}
