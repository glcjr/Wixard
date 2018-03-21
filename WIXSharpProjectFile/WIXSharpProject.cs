using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
    public class WIXSharpProject : ISerializable
    {
        private ApplicationInfo application = new ApplicationInfo();
        private string installdir = "";
        private string progfiles = "";
        private string progmenu = "";
        private SetupOptions Options = new SetupOptions();
        private SourceFiles Sourcefiles = new SourceFiles();
        private SigningInfo SignInstaller = new SigningInfo();
        private AdvancedOptions Advancedoptions = new AdvancedOptions();
        //private Certificates Certs = new Certificates();
        //private Users users = new Users();
        //private EnvironmentVars EnvironmentVariables = new EnvironmentVars();
        //private Elements WElements = new Elements();
        //private Features Feature = new Features();
        //private FirewallExceptions FirewallExcept = new FirewallExceptions();
        //private FileAssociations GlobalFileAssociations = new FileAssociations();
        //private RegistryValues Registryvalues = new RegistryValues();
        public WIXSharpProject()
        { }
        public ApplicationInfo GetApplication()
        {
            return application;
        }
        public EnvironmentVars GetEnvironmentVars()
        {
            return Advancedoptions.GetEnvironmentVars();
        }
        public FileAssociations GetGlobalFileAssociations()
        {
            return Advancedoptions.GetGlobalFileAssociations();
        }
        public string GetInstallDir()
        {
            return installdir;
        }
        public string GetProgFiles()
        {
            return progfiles;
        }
        public string GetProgMenu()
        {
            return progmenu;
        }
        public Certificates GetCerts()
        {
            return Advancedoptions.GetCerts();
        }
        public SetupOptions GetOptions()
        {
            return Options;
        }
        public SourceFiles GetSourceFiles()
        {
            return Sourcefiles;
        }
        public SigningInfo GetSignInstaller()
        {
            return SignInstaller;
        }
        public Users GetUsers()
        {
            return Advancedoptions.GetUsers();
        }
        public Elements GetElements()
        {
            return Advancedoptions.GetElements();
        }
        public Features GetFeatures()
        {
            return Advancedoptions.GetFeatures();
        }
        public FirewallExceptions GetFirewallExceptions()
        {
            return Advancedoptions.GetFirewallExceptions();
        }
        public RegistryValues GetRegistryValues()
        {
            return Advancedoptions.GetRegistryValues();
        }
        public AdvancedOptions GetAdvancedOptions()
        {
            return Advancedoptions;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("application", application, typeof(ApplicationInfo));
            info.AddValue("options", Options, typeof(SetupOptions));
            info.AddValue("Sourcefiles", Sourcefiles, typeof(SourceFiles));
            info.AddValue("signinstaller", SignInstaller, typeof(SigningInfo));
            info.AddValue("advancedoptions", Advancedoptions, typeof(AdvancedOptions));
        }
        public WIXSharpProject(SerializationInfo info, StreamingContext context)
        {
            application = (ApplicationInfo)info.GetValue("application", typeof(ApplicationInfo));
            Options = (SetupOptions)info.GetValue("options", typeof(SetupOptions));
            Sourcefiles = (SourceFiles)info.GetValue("Sourcefiles", typeof(SourceFiles));
            SignInstaller = (SigningInfo)info.GetValue("signinstaller", typeof(SigningInfo));
            Advancedoptions = (AdvancedOptions)info.GetValue("advancedoptions", typeof(AdvancedOptions));
            setdirectories();
        }
        public void SetSignIntaller(string certpath, string certpassword, string timestamp, string options)
        {
            SignInstaller = new SigningInfo(certpath, timestamp, certpassword, options);
        }
        public WIXSharpProject(string pubname, string producttitle)
        {
            application = new ApplicationInfo(pubname, producttitle);
            setdirectories();
        }
        public void setdirectories()
        {
            string pubname = application.GetPublisher();
            string producttitle = application.GetProductName();
            progfiles = @"%ProgramFiles%";
            installdir = progfiles + @"\" + pubname + @"\" + producttitle;
            progmenu = @"%ProgramMenu%\" + pubname + @"\" + producttitle;
        }
        public void SetIncludeUninstall(bool uninstall)
        {
            Options.SetIncludeUninstall(uninstall);
        }

        public void GenerateNewProductGuid()
        {
            application.GenerateNewProductGuid();
        }
        public void GenerateNewUpgradeGuid()
        {
            application.GenerateNewUpgradeGuid();
        }
        public void SetMinimumNetVersion(string WixNetID)
        {
            Options.SetMinimumNetVersion(WixNetID);
        }
        public void NetVersionToInstall(string WixCommandID)
        {
            Options.NetVersionToInstall(WixCommandID);
        }
        public void SetPublisherLink(string PublisherURL)
        {
            application.SetPublisherLink(PublisherURL);
        }
        public void SetLicenseFile(string license)
        {
            Sourcefiles.AddLicense(license);
        }
        public void AddElement(string EleName, string Id, string val, string Root = "Product")
        {
            Advancedoptions.AddElement(EleName, Id, val, Root);
        }
        public void AddRegistryValue(RegistryValue regvalue)
        {
            Advancedoptions.AddRegistryValue(regvalue);
        }
        public void AddRegistryValue(RegistryHive root, string key, string nm, object value)
        {
            Advancedoptions.AddRegistryValue(new RegistryValue(root, key, nm, value));
        }
        public void AddRegistryValue(string featurename, RegistryHive root, string key, string nm, object value)
        {
            Advancedoptions.AddRegistryValue(featurename, root, key, nm, value);
        }
        public void AddFileAssociation(FileAssociation association)
        {
            Advancedoptions.AddFileAssociation(association);
        }
        public void AddElement(Element element)
        {
            Advancedoptions.AddElement(element);
        }
        public void AddSourceFile(FirewallException exception, string path, string directory = "APPROOT", bool mainexecutable = false, bool menushortcut = false, bool desktopshortcut = false)
        {

            SourceFile sourcefile = (new SourceFile(path, directory, mainexecutable, menushortcut, desktopshortcut));
            sourcefile.AddFireWallException(exception);
            AddSourceFile(sourcefile);
        }
        public void AddSourceFile(FirewallException exception, string path, bool mainexecutable, bool menushortcut = false, bool desktopshortcut = false)
        {
            SourceFile sourcefile = new SourceFile(path, "APPROOT", mainexecutable, menushortcut, desktopshortcut);
            sourcefile.AddFireWallException(exception);
            AddSourceFile(sourcefile);
        }
        public void AddSourceFile(Feature feature, string path, string directory = "APPROOT", bool mainexecutable = false, bool menushortcut = false, bool desktopshortcut = false)
        {
            
            SourceFile sourcefile = (new SourceFile(path, directory, mainexecutable, menushortcut, desktopshortcut));            
            AddSourceFile(feature, sourcefile);
        }
        public void AddSourceFile(Feature feature, string path, bool mainexecutable, bool menushortcut = false, bool desktopshortcut = false)
        {
            SourceFile sourcefile = new SourceFile(path, "APPROOT", mainexecutable, menushortcut, desktopshortcut);
            AddSourceFile(feature, sourcefile);
        }
        public void AddSourceFile(string path, string directory = "APPROOT", bool mainexecutable = false, bool menushortcut = false, bool desktopshortcut = false)
        {            
            Sourcefiles.Add(new SourceFile(path, directory, mainexecutable, menushortcut, desktopshortcut));
        }
        public void AddSourceFile(string path, bool mainexecutable, bool menushortcut = false, bool desktopshortcut = false)
        {            
            Sourcefiles.Add(new SourceFile(path, "APPROOT", mainexecutable, menushortcut, desktopshortcut));
        }
        public void AddSourceFile(Feature feature, SourceFile file)
        {
            file.SetFeatureName(feature.GetVariableName());
            Advancedoptions.AddFeature(feature);
            Sourcefiles.Add(file);
        }
        public void AddSourceFile(SourceFile file)
        {
            Sourcefiles.Add(file);
        }
        
        public void AddSourceFiles(params SourceFile[] files)
        {
            foreach (var file in files)
                Sourcefiles.Add(file);
        }
        public void AddSourceFiles(SourceFiles files)
        {
            foreach (var file in files.GetSourceFiles())
                Sourcefiles.Add(file);
        }
        public void SetApplicationIcon(string icon)
        {
            application.SetApplicationIcon(icon);
        }
        public void AddFirewallException(string name, string remoteaddress)
        {
            Advancedoptions.AddFirewallException(name, remoteaddress);
        }
        public void AddFirewallException(string name, string remoteaddress, string port)
        {
            Advancedoptions.AddFirewallException(name, remoteaddress, port);
        }
        public void AddFirewallException(FirewallException exception)
        {
            Advancedoptions.AddFirewallException(exception);
        }
        public void AddEnvironmentVariable(string varnm, string dir = "[INSTALLDIR]", string placement = "", string condition = "", bool system = false, bool permanent = false, string action = "")
        {
            Advancedoptions.AddEnvironmentVariable(varnm, dir, placement, condition, system, permanent, action);
        }
        public void AddEnvironmentVariable(EnvironmentVar var)
        {
            Advancedoptions.AddEnvironmentVariable(var);
        }
        public string GetDirectory()
        {
            return Sourcefiles.GetAppMainDirectory();
        }
        public void AddCertificate(Certificate cert)
        {
            Advancedoptions.AddCertificate(cert);
        }
        public void AddCertificate(string name, string certificatepath, string storelocation = "localMachine", string storename = "personal", bool authorityrequest = false)
        {
            Advancedoptions.AddCertificate(name, certificatepath, storelocation, storename, authorityrequest);
        }
        public void RemoveCertificate(Certificate cert)
        {
            Advancedoptions.RemoveCertificate(cert);
        }
        public void RemoveCertificate(int index)
        {
            Advancedoptions.RemoveCertificate(index);
        }
        public Certificate GetCertificate(int index)
        {
            return Advancedoptions.GetCertificate(index);
        }
        public void UpdateCertificate(int index, Certificate cert)
        {
            Advancedoptions.UpdateCertificate(index, cert);
        }
        public void SetOptionalDesktopShortcut(bool includeoptionaldesktopshortcut)
        {
            Options.SetOptionalDesktopShortcut(includeoptionaldesktopshortcut);
            checkcustomactions();
        }
        public void checkcustomactions()
        {
            Options.SetCustomActions(Options.GetOptionalDesktopShortcut() || Options.GetPromptReboot()); 
        }
        public void AddUser(string name, string password, string domain = "Environment.MachineName", bool pwneverexpire = true)
        {
            Advancedoptions.AddUser(name, password, domain, pwneverexpire);
        }
        public void AddUser(User user)
        {
            Advancedoptions.AddUser(user);
        }
        public void RemoveUser(int index)
        {
            Advancedoptions.RemoveUser(index);
        }
        public User GetUser(int index)
        {
            return Advancedoptions.GetUser(index);
        }
        public void UpdateUser(int index, User user)
        {
            Advancedoptions.UpdateUser(index, user);
        }
        public void SetPromptReboot(bool value)
        {
            Options.SetPromptReboot(value);
            checkcustomactions();
               
        }
        public bool GetPromptReboot()
        {
            return Options.GetPromptReboot();
        }
        public void SetBuild64(bool value)
        {
            Options.SetBuild64(value);
        }
        public bool GetBuild64()
        {
            return Options.GetBuild64();
        }
    }
}
