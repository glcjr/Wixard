using System;
using System.Collections.Generic;
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
    //public class WIXSharpScriptBuilder
    //{
    //    private ApplicationInfo application = new ApplicationInfo();
    //    private string installdir = "";
    //    private string progfiles = "";
    //    private string progmenu = "";
    //    private SetupOptions Options = new SetupOptions();
    //    private SourceFiles Sourcefiles = new SourceFiles();
    //    private SigningInfo SignInstaller = new SigningInfo();
    //    private Certificates Certs = new Certificates();
    //    private Users users = new Users();
    //    private EnvironmentVars EnvironmentVariables = new EnvironmentVars();
    //    private Elements WElements = new Elements();
    //    private Features Feature = new Features();
    //    private FirewallExceptions FireExcept = new FirewallExceptions();
    //    private FileAssociations GlobalFileAssociations = new FileAssociations();
    //    private RegistryValues Registryvalues = new RegistryValues();
    //    public WIXSharpScriptBuilder(WIXSharpProject project)
    //    {
    //        application = project.GetApplication();
    //        installdir = project.GetInstallDir();
    //        progfiles = project.GetProgFiles();
    //        progmenu = project.GetProgMenu();
    //        Options = project.GetOptions();
    //        Sourcefiles = project.GetSourceFiles();
    //        SignInstaller = project.GetSignInstaller();
    //        Certs = project.GetCerts();
    //        users = project.GetUsers();
    //        EnvironmentVariables = project.GetEnvironmentVars();
    //        WElements = project.GetElements();
    //        Feature = project.GetFeatures();
    //        FireExcept = project.GetFirewallExceptions();
    //        GlobalFileAssociations = project.GetGlobalFileAssociations();
    //        Registryvalues = project.GetRegistryValues();
    //    }
    //    private string adduninstallmethod()
    //    {
    //        return $"{Environment.NewLine}static void Project_AfterInstall(SetupEventArgs e){Environment.NewLine}{{ {Environment.NewLine} if (e.IsUninstalling) {Environment.NewLine} {{  {Environment.NewLine} if (System.IO.Directory.Exists(@\"{installdir}\")) {Environment.NewLine} System.IO.Directory.Delete(@\"{installdir}\", recursive: true); {Environment.NewLine} }}  }}";
    //    }
    //    private string directorynamecheck(string dir)
    //    {
    //        switch(dir)
    //        {
    //            case "SystemFolder": return $"new Id(\"SystemFolder\"), \"System\"";
    //            default:
    //                return $"@\"{dir}\"";
    //        }
    //    }
    //    private string GetProjectStructure()
    //    {
    //        string line = GlobalFileAssociations.GetLine(); 
    //            line += $", {Environment.NewLine}new Dir(@\"{installdir}\",{Environment.NewLine}{Sourcefiles.GetMainExecutableLicenseReadMeLine(application.GetProductName(), progmenu)}";
    //        line += FireExcept.GetLine();
    //        if (Options.GetIncludeUninstall())
    //            line += $", {Environment.NewLine} new ExeFileShortcut(\"Uninstall {application.GetProductName()}\", \"[System64Folder]msiexec.exe\", \"/x [ProductCode]\")";
    //        string directory = Sourcefiles.GetAppMainDirectory();
    //        foreach (var file in Sourcefiles.GetSourceFiles(directory))
    //            line += $", {Environment.NewLine} {file.GetFileLine()}";
    //        line += Sourcefiles.GetSubdirectoryfiles();
    //        line += Certs.GetCertificatesLine();
    //        line += EnvironmentVariables.GetLine();
    //        line += Registryvalues.GetLine();
    //        line += ")";
    //        foreach (var newdirectory in Sourcefiles.GetDirectories(true))
    //        {
    //            line += $", new Dir({directorynamecheck(newdirectory)}";
    //            foreach (var file in Sourcefiles.GetSourceFiles(newdirectory))
    //                line += $",{Environment.NewLine} {file.GetFileLine()}";
    //            line += ")";
    //        }
    //        if (Options.GetOptionalDesktopShortcut())
    //            line += Options.GetShortcutDesktopLines();
    //        if (Options.GetPromptReboot())
    //            line += Options.GetRebootLine();
    //        line += users.GetUsersLine();
    //        return line;
    //    }
    //    public string GetBuildMSIMethod()
    //    {
    //        string temp = $"{Environment.NewLine} static string buildmsi() {Environment.NewLine} {{ {Environment.NewLine}";
    //        temp += Feature.GetLine();
    //        temp += GetInitializeProject();
    //        temp += GetMainProjectInfo();
    //        temp += $"return project.BuildMsi();{Environment.NewLine}}}{Environment.NewLine}";
    //        return temp;
    //    }
    //    private string GetInitializeProject()
    //    {
    //        return $"var project = new ManagedProject(\"{application.GetProductName()}\"{GetProjectStructure()});{Environment.NewLine}";

    //    }
    //    private string AddIfNotEmpty(string line, string value)
    //    {
    //        string temp = "";
    //        if (value != string.Empty)
    //            temp = $"{line.Replace("//INSERTTEXTHERE//", value)}{Environment.NewLine}";
    //        return temp;
    //    }
    //    private string GetMainProjectInfo()
    //    {
    //        string temp = AddIfNotEmpty("project.GUID = new Guid(\"//INSERTTEXTHERE//\");", application.GetProductGuid());
    //        temp += AddIfNotEmpty("project.LicenceFile = @\"//INSERTTEXTHERE//\";", Sourcefiles.GetLicensePath());
    //        temp += AddIfNotEmpty("project.Version = new System.Version(//INSERTTEXTHERE//);", application.GetVersion());
    //        temp += AddIfNotEmpty("project.ControlPanelInfo.Comments = \"//INSERTTEXTHERE// msi\";", application.GetProductName());
    //        temp += AddIfNotEmpty("project.ControlPanelInfo.Readme = @\"//INSERTTEXTHERE//\";", Sourcefiles.GetReadMePath());
    //        temp += AddIfNotEmpty("project.ControlPanelInfo.HelpLink = @\"//INSERTTEXTHERE//\";", application.GetLink());
    //        temp += AddIfNotEmpty("project.ControlPanelInfo.Manufacturer = \"//INSERTTEXTHERE//\";", application.GetPublisher());
    //        temp += $"project.ControlPanelInfo.InstallLocation = \"[INSTALLDIR]\";{Environment.NewLine}";
    //        if (Options.GetIncludeUninstall())
    //            temp += $"project.AfterInstall += Project_AfterInstall;{Environment.NewLine}";
    //        if (Options.GetBuild64())            
    //            temp += $" if (Environment.GetEnvironmentVariable(\"buid_as_64\") != null) {Environment.NewLine}project.Platform = Platform.x64; ";            
    //        if (WElements.Count > 0)
    //            temp += $"project.WixSourceGenerated += InjectElements;{Environment.NewLine}";
    //        return temp;
    //    }
    //    private string GetInitializeBootstrapper(string msiproject)
    //    {
    //        return $"var bootstrapper = new Bundle(\"{application.GetProductName()}\", new PackageGroupRef(\"{Options.GetNettoInstall()}\"), new MsiPackage({msiproject}) {{DisplayInternalUI = true}});{Environment.NewLine} ";
    //    }
    //    private string GetBootstrapperInfo()
    //    {
    //        string temp = AddIfNotEmpty("bootstrapper.Condition = \"//INSERTTEXTHERE//\";",Options.GetMinimumNetVersion());
    //        temp += AddIfNotEmpty("bootsrapper.Version = new System.Version(//INSERTTEXTHERE//);", application.GetVersion());
    //        temp += AddIfNotEmpty("bootstrapper.UpgradeCode = new System.Guid(\"//INSERTTEXTHERE//\");", application.GetBootstapperGuid());
    //        temp += AddIfNotEmpty("bootstrapper.Manufacturer = \"//INSERTTEXTHERE//\";", application.GetPublisher());
    //        temp += AddIfNotEmpty("bootstrapper.HelpUrl = \"//INSERTTEXTHERE//\";", application.GetLink());
    //        temp += AddIfNotEmpty("bootstrapper.IconFile = @\"//INSERTTEXTHERE//\";", application.GetIcon());
    //        temp += AddIfNotEmpty("bootstrapper.OutFileName = \"//INSERTTEXTHERE//netfx\";", application.GetProductName().Replace(" ", ""));
    //        return temp;
    //    }
    //    public string GetBootStrapper(string msiproject)
    //    {
    //        string temp = GetInitializeBootstrapper(msiproject);
    //        temp += GetBootstrapperInfo();
    //        temp += "bootstrapper.Build();";
    //        return temp;
    //    }
    //    public string GetBootstrapperSigning()
    //    {
    //        string temp = $"ExternalTool ig = new ExternalTool();{Environment.NewLine}";
    //        temp += AddIfNotEmpty("ig.WellKnownLocations = @\"//INSERTTEXTHERE//\";", SignInstaller.GetWixWellKnownLocation() );
    //        temp += $"ig.ExePath = \"insignia.exe\";{Environment.NewLine}";
    //        temp += $"ig.Arguments = \" - ib {application.GetProductName().Replace(" ","")}netfx.exe -o engine.exe\"; {Environment.NewLine}";
    //        temp += $"ig.ConsoleRun();{Environment.NewLine}";
    //        temp += SignInstaller.GetSigningLine("\"engine.exe\"");
    //        temp += $"ig.Arguments = \" -ab engine.exe {application.GetProductName().Replace(" ", "")}netfx.exe -o {application.GetProductName().Replace(" ", "")}netfx.exe\"; {Environment.NewLine}";
    //        temp += $"ig.ConsoleRun();{Environment.NewLine}";
    //        return temp;

    //    }
    //    private string GetUsings()
    //    {
    //        string line = $"using System;{Environment.NewLine}using WixSharp;{Environment.NewLine}using WixSharp.CommonTasks;{Environment.NewLine}using WixSharp.Bootstrapper; {Environment.NewLine}";
    //        if (Options.GetCustomActions())
    //            line += $"using Microsoft.Deployment.WindowsInstaller; {Environment.NewLine}using System.Windows.Forms;";
    //        if (WElements.Count > 0)
    //            line += $"using System.Linq;{Environment.NewLine}using System.Xml;{Environment.NewLine}using System.Xml.Linq; ";
    //        if (Registryvalues.Count > 0)
    //            line += $"{Environment.NewLine}using Microsoft.Win32;";
    //        if (Options.GetPromptReboot())
    //            line += $"{Environment.NewLine}using System.Diagnostics;";
    //        line += $"{Environment.NewLine}";
    //        return line;
    //    }
    //    private string GetMain()
    //    {
    //        string temp = $"static public void Main() {Environment.NewLine} {{ {Environment.NewLine} ";
    //        temp += "string msiproject = buildmsi();";
    //        temp += SignInstaller.GetSigningLine("msiproject");
    //        if (Options.GetMinimumNetVersion() != string.Empty)
    //        {
    //            temp += GetBootStrapper("msiproject");
    //            temp += GetBootstrapperSigning();
    //        }
    //        temp += $"}}{Environment.NewLine}";
    //        return temp;
    //    }
    //    private string GetCustomActions()
    //    {
    //        string line = "";
    //        if (Options.GetCustomActions())
    //        {
    //            line += $"public class CustomActions {Environment.NewLine}{{ {Environment.NewLine} ";
    //            if (Options.GetOptionalDesktopShortcut())
    //            {
    //                line += $"[CustomAction] {Environment.NewLine} public static ActionResult DesktopShortcut(Session session){Environment.NewLine} {{ {Environment.NewLine}";
    //                line += $" if (DialogResult.Yes == MessageBox.Show(\"Do you want to install desktop shortcut\", \"Installation\", MessageBoxButtons.YesNo)) {Environment.NewLine}session[\"INSTALLDESKTOPSHORTCUT\"] = \"yes\"; {Environment.NewLine}  return ActionResult.Success; {Environment.NewLine} }} {Environment.NewLine}";
    //            }
    //            if (Options.GetPromptReboot())
    //            {
    //                line += $"[CustomAction]{Environment.NewLine}  public static ActionResult PromptToReboot(Session session){Environment.NewLine}    {{ {Environment.NewLine}";
    //                line += $"if (DialogResult.Yes == MessageBox.Show(\"You need to reboot the system. Do you want to reboot now?\", \"ReboolTest\", MessageBoxButtons.YesNo))";
    //                line += $"{Environment.NewLine} {{ {Environment.NewLine} Process.Start(\"shutdown.exe\", \"-r -t 30 -c \\\"Reboot has been requested from RebootTest.msi\\\"\");";
    //                line += $"{Environment.NewLine} }} {Environment.NewLine} return ActionResult.Success; }}";
    //            }
    //            line += $"}} {Environment.NewLine}";
    //        }
    //        return line;
    //    }
    //    public string GetScript()
    //    {
    //        string temp = GetUsings();
    //        temp += $"namespace WixSharpSetUp {Environment.NewLine}{{ {Environment.NewLine}class Script {Environment.NewLine}{{ {Environment.NewLine}";
    //        temp += adduninstallmethod();
    //        temp += GetBuildMSIMethod();
    //        temp += GetMain();
    //        temp += WElements.GetElementMethod();

    //        temp += $"}}{Environment.NewLine} }}";
    //        temp += GetCustomActions();
    //        return temp;
    //    }
    //}
}
