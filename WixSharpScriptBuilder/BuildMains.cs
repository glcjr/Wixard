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
    class BuildMains
    {
        SigningInfo SignInstaller;
            SetupOptions Options;
        BuildBootstrapperCode bootstrapper;
        ApplicationInfo AppInfo;

        public BuildMains(SigningInfo signinstaller, SetupOptions options, BuildBootstrapperCode bootstrap, ApplicationInfo appinfo)
        {
            SignInstaller = signinstaller;
            Options = options;
            bootstrapper = bootstrap;
            AppInfo = appinfo;
        }
        public BuildMains(WIXSharpProject project, BuildBootstrapperCode bootstrap)
        {
            SignInstaller = project.GetSignInstaller();
            Options = project.GetOptions();
            bootstrapper = bootstrap;
            AppInfo = project.GetApplication();
        }
        public BuildMains(WIXSharpProject project)
        {
            SignInstaller = project.GetSignInstaller();
            Options = project.GetOptions();
            bootstrapper = new BuildBootstrapperCode(project);
            AppInfo = project.GetApplication();
        }
        private string GetInsideMain()
        {
            string temp = "";
            
            temp += SignInstaller.GetSigningLine("msiproject");
            if (Options.GetMinimumNetVersion() != string.Empty)
            {
                temp += bootstrapper.GetBootStrapper("msiproject");
            }
            temp += $"{Environment.NewLine}return \"Successfully Created Script\";{Environment.NewLine}}} {Environment.NewLine}\tcatch (Exception ex) {Environment.NewLine}\t{{ return ex.Message; {Environment.NewLine}\t}}{Environment.NewLine}";
            return temp;
        }
        private string GetInitMain(string returntype)
        {
            string temp = $"public static {returntype} Process(params string[] Args) {Environment.NewLine} {{ {Environment.NewLine} \t try {Environment.NewLine}\t{{ {Environment.NewLine}";
            temp += $"OutputFile = @\"{System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Wixard\\{AppInfo.GetProductName()}{AppInfo.GetVersion()}\\{AppInfo.GetProductName()}\";{Environment.NewLine}";
            temp += $"//changing the OutputFile value will result in the compiler not being able to create the script after it compiles this script.\n // You'll need to download the wixsharp dlls to your new location and launch by hand {Environment.NewLine}";
            return temp;
        }
        public string GetMSIMain(string returntype="string")
        {
            string temp = GetInitMain(returntype);
            
            temp += "string msiproject = buildmsi();";
            temp += GetInsideMain();
            temp += $"}}{Environment.NewLine}";
            temp += addregularmain();
            return temp;
        }
        private string addregularmain()
        {
            string temp = $"public static void Main(params string[] Args){Environment.NewLine} {{{Environment.NewLine} Process(Args);{Environment.NewLine}}}{Environment.NewLine}";
            return temp;
        }
        public string GetWxsMain(string returntype="string")
        {
            string temp = GetInitMain(returntype);
            temp += "string msiproject = buildwxs();";
            temp += GetInsideMain();
            temp += $"}}{Environment.NewLine}";
            temp += addregularmain();
            return temp;
        }
    }
}
