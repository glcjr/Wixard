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
    class BuildProjectCode
    {
        private SetupOptions Options = new SetupOptions();
        private FileAssociations GlobalFileAssociations = new FileAssociations();
        private RegistryValues Registryvalues = new RegistryValues();
        private FirewallExceptions FireExcept = new FirewallExceptions();
        private SourceFiles Sourcefiles = new SourceFiles();
        private Certificates Certs = new Certificates();
        private EnvironmentVars EnvironmentVariables = new EnvironmentVars();
        private ApplicationInfo application = new ApplicationInfo();
        private Users users = new Users();
        private Elements WElements = new Elements();
        private string installdir = "";
        private string progfiles = "";
        private string progmenu = "";

        public BuildProjectCode(SetupOptions options, FileAssociations fileassoc, RegistryValues registryvalues, FirewallExceptions firewallexceptions, SourceFiles sourcefiles,
            Certificates certs, EnvironmentVars envirvars, ApplicationInfo app, Users user, Elements elements, string dir, string files, string menu)
        {
            Options = options;
            GlobalFileAssociations = fileassoc;
            Registryvalues = registryvalues;
            FireExcept = firewallexceptions;
            Sourcefiles = sourcefiles;
            Certs = certs;
            EnvironmentVariables = envirvars;
            application = app;
            users = user;
            WElements = elements;
            installdir = dir;
            progfiles = files;
            progmenu = menu;
            addglobalfileassociations();
        }
        private void addglobalfileassociations()
        {
            foreach (var s in Sourcefiles.GetSourceFiles())
                if (s.GetIsMainExecutable())
                {
                    s.ClearFileAssociation();
                    foreach (var assoc in GlobalFileAssociations.getfileassociations())
                        s.AddFileAssociation(assoc);
                }
        }
        public BuildProjectCode(WIXSharpProject project)
        {
            Options = project.GetOptions();
            GlobalFileAssociations = project.GetGlobalFileAssociations();
            Registryvalues = project.GetRegistryValues();
            FireExcept = project.GetFirewallExceptions();
            Sourcefiles = project.GetSourceFiles();
            Certs = project.GetCerts();
            EnvironmentVariables = project.GetEnvironmentVars();
            application = project.GetApplication();
            users = project.GetUsers();
            WElements = project.GetElements() ;
            installdir = project.GetInstallDir();
            progfiles = project.GetProgFiles();
            progmenu = project.GetProgMenu();
        }
        private string GetProjectStructure()
        {
            string line = "";
            line += $", {Environment.NewLine}\tnew Dir(@\"{installdir}\",{Environment.NewLine}{Sourcefiles.GetMainExecutableLicenseReadMeLine(application.GetProductName(), progmenu)}";
            line += FireExcept.GetLine();
            if (Options.GetIncludeUninstall())
                line += $", {Environment.NewLine} \tnew ExeFileShortcut(\"Uninstall {application.GetProductName()}\", \"[System64Folder]msiexec.exe\", \"/x [ProductCode]\")";
            string directory = Sourcefiles.GetAppMainDirectory();
            foreach (var file in Sourcefiles.GetSourceFiles(directory))
                line += $", {Environment.NewLine} {file.GetFileLine()}";
            line += Sourcefiles.GetSubdirectoryfiles();
            
            line += ")";
            foreach (var newdirectory in Sourcefiles.GetDirectories(true))
            {
                line += $", new Dir({Utilities.directorynamecheck(newdirectory)}";
                foreach (var file in Sourcefiles.GetSourceFiles(newdirectory))
                    line += $",{Environment.NewLine}\t {file.GetFileLine()}";
                line += ")";
            }        
            line += Certs.GetCertificatesLine();
            line += EnvironmentVariables.GetLine();
            line += Registryvalues.GetLine();
            if (Options.GetOptionalDesktopShortcut())
                line += Options.GetShortcutDesktopLines();
            if (Options.GetPromptReboot())
                line += Options.GetRebootLine();
            line += users.GetUsersLine();
            return line;
        }
        private string GetInitializeProject()
        {
            return $"var project = new ManagedProject(\"{application.GetProductName()}\"{GetProjectStructure()});{Environment.NewLine}";

        }
        private string GetMainProjectInfo()
        {
            string temp = Utilities.AddIfNotEmpty("\tproject.GUID = new Guid(\"//INSERTTEXTHERE//\");", application.GetProductGuid());
            temp += Utilities.AddIfNotEmpty("\tproject.LicenceFile = @\"//INSERTTEXTHERE//\";", Sourcefiles.GetLicensePath());
            temp += Utilities.AddIfNotEmpty("\tproject.Version = new System.Version(\"//INSERTTEXTHERE//\");", application.GetVersion());
            temp += Utilities.AddIfNotEmpty("\tproject.ControlPanelInfo.Comments = \"//INSERTTEXTHERE// msi\";", application.GetProductName());
            temp += Utilities.AddIfNotEmpty("\tproject.ControlPanelInfo.Readme = @\"//INSERTTEXTHERE//\";", Sourcefiles.GetReadMePath());
            temp += Utilities.AddIfNotEmpty("\tproject.ControlPanelInfo.HelpLink = @\"//INSERTTEXTHERE//\";", application.GetLink());
            temp += Utilities.AddIfNotEmpty("\tproject.ControlPanelInfo.Manufacturer = \"//INSERTTEXTHERE//\";", application.GetPublisher());
            temp += Utilities.AddIfNotEmpty("\tproject.ControlPanelInfo.ProductIcon = @\"//INSERTTEXTHERE//\";", application.GetIcon());
            temp += "\tproject.OutFileName = OutputFile; ";
            temp += $"\tproject.ControlPanelInfo.InstallLocation = \"[INSTALLDIR]\";{Environment.NewLine}";
            if (Options.GetIncludeUninstall())
                temp += $"\tproject.AfterInstall += Project_AfterInstall;{Environment.NewLine}";
            if (Options.GetBuild64())
                temp += $" \tif (Environment.GetEnvironmentVariable(\"buid_as_64\") != null) {Environment.NewLine}\tproject.Platform = Platform.x64; ";
            if (WElements.Count > 0)
                temp += $"\tproject.WixSourceGenerated += InjectElements;{Environment.NewLine}";
            return temp;
        }
        public string GetProjectCode()
        {
            string line = GetInitializeProject();
            line += GetMainProjectInfo();
            return line;
        }

    }
}
