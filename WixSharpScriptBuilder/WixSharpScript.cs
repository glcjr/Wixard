using System;
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
    public class WixSharpScript
    {
        BuildProjectCode projectcode;
        BuildWixBuildMethods buildmethods;
        BuildBootstrapperCode bootstrapper;
        BuildMains mains;
        RegistryValues Registryvalues;
        SetupOptions Options;
        Elements WElements;
        string installdir;

        public WixSharpScript(WIXSharpProject project)
        {
            installdir = project.GetInstallDir();
            Options = project.GetOptions();
            WElements = project.GetElements();
            Registryvalues = project.GetRegistryValues();
            projectcode = new BuildProjectCode(Options, project.GetGlobalFileAssociations(), Registryvalues, project.GetFirewallExceptions(), project.GetSourceFiles(), 
                project.GetCerts(), project.GetEnvironmentVars(), project.GetApplication(), project.GetUsers(), WElements, installdir, project.GetProgFiles(), 
                project.GetProgMenu());
            buildmethods = new BuildWixBuildMethods(projectcode, project.GetFeatures());
            bootstrapper = new BuildBootstrapperCode(project.GetApplication(), Options, project.GetSignInstaller());
            mains = new BuildMains(project.GetSignInstaller(), Options, bootstrapper, project.GetApplication());
        }            
        private string GetBeginning()
        {
            string temp = "";
            temp += SharedMethods.GetUsings(Options, WElements, Registryvalues);
            temp += $"namespace WixSharpSetUp {Environment.NewLine}{{ {Environment.NewLine}class Script {Environment.NewLine}{{ {Environment.NewLine} private static string OutputFile = \"\"; {Environment.NewLine}";
            temp += SharedMethods.adduninstallmethod(installdir);
            return temp;
        }
        private string GetEnding()
        {
            string temp = "";
            temp += WElements.GetElementMethod();
            temp += $"}}{Environment.NewLine} }}";
            temp += SharedMethods.GetCustomActions(Options);
            return temp;
        }
        public string GetMSIScript(string returntype="string")
        {
            string temp = GetBeginning(); 
            temp += buildmethods.GetBuildMSIMethod();
            temp += mains.GetMSIMain(returntype);
            temp += GetEnding();
            return temp;
        }
        public string GetWxsScript(string returntype = "string")
        {
            string temp = GetBeginning();
            temp += buildmethods.GetBuildWxsMethod();
            temp += mains.GetWxsMain(returntype);
            temp += GetEnding();
            return temp;
        }
    }
}
