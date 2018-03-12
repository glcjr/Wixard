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
    class BuildBootstrapperCode
    {
        private ApplicationInfo application = new ApplicationInfo();
        private SetupOptions Options = new SetupOptions();
        private SigningInfo SignInstaller = new SigningInfo();

        public BuildBootstrapperCode(ApplicationInfo app, SetupOptions options, SigningInfo sinstaller)
        {
            application = app;
            Options = options;
            SignInstaller = sinstaller;
        }
        public BuildBootstrapperCode(WIXSharpProject project)
        {
            application = project.GetApplication();
            Options = project.GetOptions();
            SignInstaller = project.GetSignInstaller();
        }
        private string GetInitializeBootstrapper(string msiproject)
        {
            return $"var bootstrapper = new Bundle(\"{application.GetProductName()}\", new PackageGroupRef(\"{Options.GetNettoInstall()}\"), new MsiPackage({msiproject}) {{DisplayInternalUI = true}});{Environment.NewLine} ";
        }
        private string GetBootstrapperInfo()
        {
            string temp = Utilities.AddIfNotEmpty("\tbootstrapper.Condition = \"NOT //INSERTTEXTHERE//\";", Options.GetMinimumNetVersion());
            //temp += $"\tbootstrapper.Version =Tasks.GetVersionFromFile(msiproject);\n";
            temp += Utilities.AddIfNotEmpty("\tbootstrapper.Version = new System.Version(\"//INSERTTEXTHERE//\");", application.GetVersion());
            temp += Utilities.AddIfNotEmpty("\tbootstrapper.UpgradeCode = new System.Guid(\"//INSERTTEXTHERE//\");", application.GetBootstapperGuid());
            temp += Utilities.AddIfNotEmpty("\tbootstrapper.Manufacturer = \"//INSERTTEXTHERE//\";", application.GetPublisher());
            temp += Utilities.AddIfNotEmpty("\tbootstrapper.HelpUrl = \"//INSERTTEXTHERE//\";", application.GetLink());
            temp += Utilities.AddIfNotEmpty("\tbootstrapper.IconFile = @\"//INSERTTEXTHERE//\";", application.GetIcon());
            //  temp += Utilities.AddIfNotEmpty("\tbootstrapper.OutFileName = \"//INSERTTEXTHERE//netfx\";", application.GetProductName().Replace(" ", ""));
            temp += $"\tbootstrapper.OutFileName = OutputFile +\"netfx\";{Environment.NewLine}";
            return temp;
        }
        public string GetBootStrapper(string msiproject)
        {
            string temp = GetInitializeBootstrapper(msiproject);
            temp += GetBootstrapperInfo();
            temp += "\tbootstrapper.Build();";
            temp += GetBootstrapperSigning();
            return temp;
        }
        private string GetBootstrapperSigning()
        {
            string temp = "";
            if (SignInstaller.GetSignInstaller())
            {
                temp += $"\tExternalTool ig = new ExternalTool();{Environment.NewLine}";
                temp += Utilities.AddIfNotEmpty("\tig.WellKnownLocations = @\"//INSERTTEXTHERE//\";", SignInstaller.GetWixWellKnownLocation());
                temp += $"\tig.ExePath = \"insignia.exe\";{Environment.NewLine}";
                //temp += $"\tig.Arguments = \" - ib {application.GetProductName().Replace(" ", "")}netfx.exe -o engine.exe\"; {Environment.NewLine}";
                temp += $"\tig.Arguments = \" - ib \"+OutputFile + \"netfx.exe -o engine.exe\"; {Environment.NewLine}";
                temp += $"\tig.ConsoleRun();{Environment.NewLine}\t";
                temp += SignInstaller.GetSigningLine("\"engine.exe\"");
                //temp += $"\tig.Arguments = \" -ab engine.exe {application.GetProductName().Replace(" ", "")}netfx.exe -o {application.GetProductName().Replace(" ", "")}netfx.exe\"; {Environment.NewLine}";
                temp += $"\tig.Arguments = \" -ab engine.exe \" + OutputFile + \"netfx.exe -o \" + OutputFile + \"netfx.exe\"; {Environment.NewLine}";
                temp += $"\tig.ConsoleRun();{Environment.NewLine}";
            }
            return temp;

        }
    }
}
