using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WIXSharpHelper;
using WixSharpScriptBuilder;
using System.IO;
using DownloadNuget;
using EasyCompile;
using System.Reflection;
using System.Threading;
using System.CodeDom.Compiler;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.Compression;
using System.Windows.Forms;

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
namespace Wixard
{
    public class GUIInterface : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            changed = true;
            Saved = false;
        }
        private WIXSharpProject project = new WIXSharpProject();
        public WIXSharpProject Getproject()

        {
            return project;
        }
        public ObservableCollection<string> NetIDDetect { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> NetIDInstall { get; set; } = new ObservableCollection<string>();
        public void Addnetids()
        {
            NetIDDetect = ReadFile(@"wixids\wixdetectnet.txt");
            NetIDInstall = ReadFile(@"wixids\wixnetids.txt");
            NotifyPropertyChanged("NetIDDetect");
            NotifyPropertyChanged("NetIDInstall");

        }
        public void CheckEnvironment()
        {
            string wixev = Environment.GetEnvironmentVariable("Wix");
            string wixsharpev = Environment.GetEnvironmentVariable("WixSharp");
            if (wixev != null)
            {
                UseLocalWix = true;
                WixLocation = wixev;
            }
            if (wixsharpev != null)
            {
                UseLocalWixSharp = true;
                WixSharpLocation = wixsharpev;
            }
        }
        private ObservableCollection<string> ReadFile(string File)
        {
            ObservableCollection<string> temp = new ObservableCollection<string>();
            StreamReader file = new StreamReader(File);
            string line;
            while ((line = file.ReadLine()) != null)
            {
                temp.Add(line);
            }

            file.Close();
            return temp;
        }
        public void NotifyALL()
        {
            NotifyAPPInfo();
            NotifySetupOptions();
            NotifySigning();
            NotifyCert();
            NotifyUser();
            NotifyEvar();
            NotifyElem();
            NotifyFeature();
            NotifyRegistryValue();
            NotifyFileAssociation();
            NotifySF();
        }

        #region ApplicationInfo
        public string ApplicationName
        {
            get
            {
                return project.GetApplication().GetProductName();
            }
            set
            {
                project.GetApplication().SetProductName(value);
                project.setdirectories();
                NotifyPropertyChanged();
            }
        }
        public string PublisherName
        {
            get
            {
                return project.GetApplication().GetPublisher();
            }
            set
            {
                project.GetApplication().SetPublisher(value);
                project.setdirectories();
                NotifyPropertyChanged();
            }
        }
        public string AppVersion
        {
            get
            {
                return project.GetApplication().GetVersion();
            }
            set
            {
                project.GetApplication().SetVersion(value);
                NotifyPropertyChanged();
            }
        }
        public string HelpLink
        {
            get
            {
                return project.GetApplication().GetLink();
            }
            set
            {
                project.GetApplication().SetHelpLink(value);
                NotifyPropertyChanged();
            }
        }
        public string Icon
        {
            get
            {
                return project.GetApplication().GetIcon();
            }
            set
            {
                project.GetApplication().SetIcon(value);
                NotifyPropertyChanged();
                NotifyPropertyChanged("IconLocation");
            }
        }
        public ImageSource IconLocation
        {
            get
            {
                if (Icon != string.Empty)
                {
                    var image = new BitmapImage(new Uri(Icon, UriKind.Absolute));
                    image.Freeze();
                    return image;
                }
                else
                    return null;
            }
        }
        public void NotifyAPPInfo()
        {
            NotifyPropertyChanged("ApplicationName");
            NotifyPropertyChanged("PublisherName");
            NotifyPropertyChanged("AppVersion");
            NotifyPropertyChanged("HelpLink");
            NotifyPropertyChanged("Icon");
        }
        #endregion
        #region SetupOptions
        public bool IncludeUninstall
        {
            get
            {
                return project.GetOptions().GetIncludeUninstall();
            }
            set
            {
                project.GetOptions().SetIncludeUninstall(value);
                NotifyPropertyChanged();
            }
        }
        public bool OptionDesktopShortcut
        {
            get
            {
                return project.GetOptions().GetOptionalDesktopShortcut();
            }
            set
            {
                project.GetOptions().SetOptionalDesktopShortcut(value);
                NotifyPropertyChanged();
            }
        }
        public bool SixtyfourBitSetup
        {
            get
            {
                return project.GetOptions().GetBuild64();
            }
            set
            {
                project.GetOptions().SetBuild64(value);
                NotifyPropertyChanged();
            }
        }
        public bool PromptReboot
        {
            get
            {
                return project.GetOptions().GetPromptReboot();
            }
            set
            {
                project.GetOptions().SetPromptReboot(value);
                NotifyPropertyChanged();
            }
        }
        //public bool NeedNet
        //{
        //    get
        //    {
        //        if (project.GetOptions().GetMinimumNetVersion().Equals(string.Empty))
        //            return false;
        //        else
        //            return true;
        //    }
        //    set
        //    {
        //        NeedNet = value;
        //    }
        //}
        public string MinimumNet
        {
            get
            {
                return project.GetOptions().GetMinimumNetVersion();
            }
            set
            {
                project.GetOptions().SetMinimumNetVersion(value);
                NotifyPropertyChanged();
            }
        }
        public string InstallNet
        {
            get
            {
                return project.GetOptions().GetNettoInstall();
            }
            set
            {
                project.GetOptions().NetVersionToInstall(value);
                NotifyPropertyChanged();
            }
        }
        public void NotifySetupOptions()
        {
            NotifyPropertyChanged("IncludeUninstall");
            NotifyPropertyChanged("OptionDesktopShortcut");
            NotifyPropertyChanged("SixtyfourBitSetup");
            NotifyPropertyChanged("PromptReboot");
            NotifyPropertyChanged("MinimumNet");
            NotifyPropertyChanged("InstallNet");
        }
        #endregion
        #region SigningInfo
        public string CertificatePath
        {
            get
            {
                return project.GetSignInstaller().GetCertificatePath();
            }
            set
            {
                project.GetSignInstaller().SetCertificatePath(value);
                NotifyPropertyChanged();
            }
        }
        public string CertificatePassword
        {
            get
            {
                return project.GetSignInstaller().GetCertPassword();
            }
            set
            {
                project.GetSignInstaller().SetCertificatePassword(value);
                NotifyPropertyChanged();
            }
        }
        public string TimestampUrl
        {
            get
            {
                return project.GetSignInstaller().GetTimestamp();
            }
            set
            {
                project.GetSignInstaller().SetTimestampUrl(value);
                NotifyPropertyChanged();
            }
        }
        public string CertificateOptions
        {
            get
            {
                return project.GetSignInstaller().GetOptions();
            }
            set
            {
                project.GetSignInstaller().SetOptions(value);
                NotifyPropertyChanged();
            }
        }
        public bool SignInstaller
        {
            get
            {
                return project.GetSignInstaller().GetSignInstaller();
            }
            set
            {
                project.GetSignInstaller().SetSignInstaller(value);
                NotifyPropertyChanged();
            }
        }
        public void NotifySigning()
        {
            NotifyPropertyChanged("CertificatePath");
            NotifyPropertyChanged("CertificatePassword");
            NotifyPropertyChanged("TimestampUrl");
            NotifyPropertyChanged("CertificateOptions");
            NotifyPropertyChanged("SignInstaller");
        }
        #endregion
        #region Certificates
        public Certificates Certs
        {
            get
            {
                return project.GetCerts();
            }
        }
        public ObservableCollection<Certificate> Certslist
        {
            get
            {
                return project.GetCerts().GetCertslist();
            }
        }
        private Certificate cert = new Certificate();
        public string CertificateName
        {
            get
            {
                return cert.GetName();
            }
            set
            {
                cert.SetName(value);
                NotifyPropertyChanged();
            }
        }
        public string CertPath
        {
            get
            {
                return cert.GetCertificatePath();
            }
            set
            {
                cert.SetCertificatePath(value);
                NotifyPropertyChanged();
            }
        }
        public bool CertAuthorityRequest
        {
            get
            {
                return cert.GetAuthorityRequest();
            }
            set
            {
                cert.SetAuthorityRequest(value);
                NotifyPropertyChanged();
            }
        }
        public string CertLocation
        {
            get
            {
                return cert.GetStoreLocation().Replace("StoreLocation.", "");
            }
            set
            {
                cert.SetStoreLocation(value);
                NotifyPropertyChanged();
            }
        }
        public string CertStore
        {
            get
            {
                return cert.GetStoreName().Replace("StoreName.", "");
            }
            set
            {
                cert.SetStoreName(value);
                NotifyPropertyChanged();
            }
        }
        public void AddCertificate()
        {
            project.AddCertificate(cert);
            cert = new Certificate();
            NotifyCert();
        }
        public void CancelCertificate()
        {
            NewCert();
        }
        public void RemoveCertificate(int index)
        {
            project.RemoveCertificate(index);
            cert = new Certificate();
            NotifyCert();
        }
        public void GetCertificate(int index)
        {
            cert = project.GetCertificate(index);
            NotifyCert();
        }
        public void UpdateCertificate(int index)
        {
            project.UpdateCertificate(index, cert);
            NotifyCert();
        }
        public void NewCert()
        {
            cert = new Certificate();
            NotifyCert();
        }
        public void NotifyCert()
        {
            NotifyPropertyChanged("Certslist");
            NotifyPropertyChanged("CertStore");
            NotifyPropertyChanged("CertLocation");
            NotifyPropertyChanged("CertAuthorityRequest");
            NotifyPropertyChanged("CertPath");
            NotifyPropertyChanged("CertificateName");
        }
        #endregion
        #region User
        /*
         * private string Name = "";
        private string Password = "";
        private string Domain = "";
        private bool Passwordneverexpire = true;
         * */
        public ObservableCollection<User> Userslist
        {
            get
            {
                return project.GetUsers().GetCertslist();
            }
        }
        private User user = new User();

        public string UserName
        {
            get
            {
                return user.GetName();
            }
            set
            {
                user.SetName(value);
                NotifyPropertyChanged();
            }
        }
        public string UserPassword
        {
            get
            {
                return user.GetPassword();
            }
            set
            {
                user.SetPassword(value);
                NotifyPropertyChanged();
            }
        }
        public string UserDomain
        {
            get
            {
                return user.GetDomain();
            }
            set
            {
                user.SetDomain(value);
                NotifyPropertyChanged();
            }
        }
        public bool UserPasswordNeverExpires
        {
            get
            {
                return user.GetPasswordNeverExpires();
            }
            set
            {
                user.SetPasswordNeverExpires(value);
                NotifyPropertyChanged();
            }
        }
        public void NotifyUser()
        {
            NotifyPropertyChanged("Userslist");
            NotifyPropertyChanged("UserName");
            NotifyPropertyChanged("UserPassword");
            NotifyPropertyChanged("UserDomain");
            NotifyPropertyChanged("UserPasswordNeverExpires");
        }
        public void NewUser()
        {
            user = new User();
            NotifyUser();
        }
        public void AddUser()
        {
            project.AddUser(user);
            NewUser();
        }
        public void CancelUser()
        {
            NewUser();
        }
        public void RemoveUser(int index)
        {
            project.RemoveUser(index);
            NewUser();
        }
        public void GetUser(int index)
        {
            user = project.GetUser(index);
            NotifyUser();
        }
        public void UpdateUser(int index)
        {
            project.UpdateUser(index, user);
            NotifyUser();
        }
        #endregion
        #region environmentvars
        /* private string Name;
        private string Directory;
        private string Placement;
        private string Condition;*/
        private EnvironmentVar Evar = new EnvironmentVar();
        public string EVarName
        {
            get
            {
                return Evar.GetName();
            }
            set
            {
                Evar.SetName(value);
                NotifyPropertyChanged();
            }
        }
        public string EVarDirectory
        {
            get
            {
                return Evar.GetDirectory();
            }
            set
            {
                Evar.SetDirectory(value);
                NotifyPropertyChanged();
            }
        }
        public string EVarPlacement
        {
            get
            {
                return Evar.GetPlacement().Replace("EnvVarPart.", "");
            }
            set
            {
                Evar.SetPlacement($"EnvVarPart.{value}");
                NotifyPropertyChanged();
            }
        }
        public string EVarCondition
        {
            get
            {
                return Evar.GetCondition();
            }
            set
            {
                Evar.SetCondition(value);
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<EnvironmentVar> Evarslist
        {
            get
            {
                return project.GetEnvironmentVars().GetEvarslist();
            }
        }
        public void NotifyEvar()
        {
            NotifyPropertyChanged("EVarName");
            NotifyPropertyChanged("EVarDirectory");
            NotifyPropertyChanged("EVarPlacement");
            NotifyPropertyChanged("EVarCondition");
            NotifyPropertyChanged("Evarslist");
        }
        public void NewEvar()
        {
            Evar = new EnvironmentVar();
            NotifyEvar();
        }
        public void AddEvar()
        {
            project.AddEnvironmentVariable(Evar);
            NewEvar();
        }
        public void RemoveEvar(int index)
        {
            project.GetEnvironmentVars().Remove(index);
            NewEvar();
        }
        public void GetEvar(int index)
        {
            Evar = project.GetEnvironmentVars().Get(index);
            NotifyEvar();
        }
        public void UpdateEvar(int index)
        {
            project.GetEnvironmentVars().Update(index, Evar);
            NotifyEvar();
        }
        public void CancelEvar()
        {
            NewEvar();
        }
        #endregion
        #region elements
        /* private string XMLRoot = "";
        private string ElementName = "";
        private WAttributes Attributes = new WAttributes();
        private string[] builtin = { "ID", "Title", "Value", "Absent", "Level", "Guid" };*/
        public ObservableCollection<Element> Elemlist
        {
            get
            {
                return project.GetElements().GetElementslist();
            }
        }
        private Element elem = new Element();
        public string ElementXMLRoot
        {
            get
            {
                return elem.GetXMLRoot();
            }
            set
            {
                elem.SetXMLRoot(value);
                NotifyPropertyChanged();
            }
        }
        public string ElementName
        {
            get
            {
                return elem.GetElementName();
            }
            set
            {
                elem.SetElementName(value);
                NotifyPropertyChanged();
            }
        }
        public string ElementID
        {
            get
            {
                return elem.GetID();
            }
            set
            {
                elem.SetID(value);
                NotifyPropertyChanged();
            }
        }
        public string ElementTitle
        {
            get
            {
                return elem.GetTitle();
            }
            set
            {
                elem.SetTitle(value);
                NotifyPropertyChanged();
            }
        }
        public string ElementValue
        {
            get
            {
                return elem.GetValue();
            }
            set
            {
                elem.SetValue(value);
                NotifyPropertyChanged();
            }
        }
        public string ElementAbsent
        {
            get
            {
                return elem.GetAbsent();
            }
            set
            {
                elem.SetAbsent(value);
                NotifyPropertyChanged();
            }
        }
        public string ElementLevel
        {
            get
            {
                return elem.GetLevel();
            }
            set
            {
                elem.SetLevel(value);
                NotifyPropertyChanged();
            }
        }
        public string ElementGuid
        {
            get
            {
                return elem.GetGuid();
            }
            set
            {
                elem.SetAssignGuid(value);
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<WAttribute> CustomElems
        {
            get
            {
                return elem.GetCustomElementlist();
            }
        }
        private WAttribute CustomElement = new WAttribute();
        private int currentcustomindex = -1;
        public string NewElementLabel
        {
            get
            {
                return CustomElement.GetLabel();
            }
            set
            {
                CustomElement.SetLabel(value);
            }
        }
        public string NewElementValue
        {
            get
            {
                return CustomElement.GetValue();
            }
            set
            {
                CustomElement.SetValue(value);
            }
        }
        public void AddCustomElement()
        {
            elem.AddCustomElement(CustomElement);
            NewCustomElement();
        }
        public void NewCustomElement()
        {
            CustomElement = new WAttribute();
            NotifyCustomElement();
            currentcustomindex = -1;
        }

        

        private void NotifyCustomElement()
        {
            NotifyPropertyChanged("NewElementValue");
            NotifyPropertyChanged("NewElementLabel");
            NotifyPropertyChanged("CustomElems");
        }
        public void GetCustomElement(int index)
        {
            CustomElement = CustomElems[index];
            NotifyCustomElement();
            currentcustomindex = index;
        }

        
        public void UpdateCustomElement()
        {
            if (currentcustomindex != -1)
            {
                elem.UpdateCustomElement(CustomElems[currentcustomindex].GetLabel(), CustomElems[currentcustomindex].GetValue(), NewElementLabel, NewElementValue);
                NewCustomElement();
                NotifyCustomElement();
            }
        }
        public void RemoveCustomElement(int index)
        {
            elem.RemoveCustomElement(CustomElems[index].GetLabel(), CustomElems[index].GetValue());
            NotifyCustomElement();
        }
        public void AddElem()
        {
            project.GetElements().Add(elem);
            NewElem();
        }
        public void RemoveElem(int index)
        {
            project.GetElements().Remove(index);
            NewElem();
        }
        public void GetElem(int index)
        {
            elem = project.GetElements().Get(index);
            NotifyElem();
        }
        public void UpdateElem(int index)
        {
            project.GetElements().Update(index, elem);
            NotifyElem();
        }
        public void NewElem()
        {
            elem = new Element();
            NotifyElem();

        }
        private void NotifyElem()
        {
            NotifyPropertyChanged("ElementXMLRoot");
            NotifyPropertyChanged("ElementName");
            NotifyPropertyChanged("ElementID");
            NotifyPropertyChanged("ElementTitle");
            NotifyPropertyChanged("ElementValue");
            NotifyPropertyChanged("ElementAbsent");
            NotifyPropertyChanged("ElementLevel");
            NotifyPropertyChanged("ElementGuid");
            NotifyPropertyChanged("Elemlist");
            NotifyCustomElement();
        }
        #endregion
        #region features
        /* string VariableName = "";
        string Name = "";
        string Description = "";
        bool IsEnabled = true;
        bool AllowChanges = true;
        string ConfigurableDir = ""; */
        public ObservableCollection<Feature> Featurelist
        {
            get
            {
                return project.GetFeatures().GetFeatureslist();
            }
        }
        public ObservableCollection<string> FeaturesVars
        {
            get
            {
                return project.GetFeatures().GetFeaturesVariableNames();
            }
        }
        private Feature feature = new Feature();
        public string FeatureVariableName
        {
            get
            {
                return feature.GetVariableName();
            }
            set
            {
                feature.SetVariableName(value);
                NotifyPropertyChanged();
            }
        }
        public string FeatureName
        {
            get
            {
                return feature.GetName();
            }
            set
            {
                feature.SetName(value);
                NotifyPropertyChanged();
            }
        }
        public string FeatureDescription
        {
            get
            {
                return feature.GetDescription();
            }
            set
            {
                feature.SetDescription(value);
                NotifyPropertyChanged();
            }
        }
        public string FeatureConfigurableDir
        {
            get
            {
                return feature.GetConfigurableDir();
            }
            set
            {
                feature.SetConfigurableDir(value);
                NotifyPropertyChanged();
            }
        }
        public bool FeatureIsEnabled
        {
            get
            {
                return feature.ReturnIsEnabled();
            }
            set
            {
                feature.SetIsEnabled(value);
                NotifyPropertyChanged();
            }
        }
        public bool FeatureAllowChanges
        {
            get
            {
                return feature.ReturnAllowChanges();
            }
            set
            {
                feature.SetAllowChanges(value);
                NotifyPropertyChanged();
            }
        }
        private void NotifyFeature()
        {
            NotifyPropertyChanged("Featurelist");
            NotifyPropertyChanged("FeatureVariableName");
            NotifyPropertyChanged("FeatureName");
            NotifyPropertyChanged("FeatureDescription");
            NotifyPropertyChanged("FeatureConfigurableDir");
            NotifyPropertyChanged("FeatureIsEnabled");
            NotifyPropertyChanged("FeatureAllowChanges");
            NotifyPropertyChanged("FeaturesVars");
           
        }
        public void AddFeature()
        {
            project.GetFeatures().Add(feature);
            NewFeature();
        }
        public void RemoveFeature(int index)
        {
            project.GetFeatures().Remove(index);
            NewFeature();
        }
        public void GetFeature(int index)
        {
            feature = project.GetFeatures().Get(index);
            NotifyFeature();
        }
        public void UpdateFeature(int index)
        {
            project.GetFeatures().Update(index, feature);
            NotifyFeature();
        }
        public void NewFeature()
        {
            feature = new Feature();
            NotifyFeature();

        }
        #endregion
        #region firewall
        private FirewallException firewallexcept = new FirewallException();
        public ObservableCollection<FirewallException> FirewallExceptionlist
        {
            get
            {
                return project.GetFirewallExceptions().GetFirewallExceptionslist();
            }
        }
        public string FirewallName
        {
            get
            {
                return firewallexcept.GetName();
            }
            set
            {
                firewallexcept.SetName(value);
                NotifyPropertyChanged();
            }
        }
        public string FirewallRemoteAddress
        {
            get
            {
                return firewallexcept.GetRemoteAddress();
            }
            set
            {
                firewallexcept.SetRemoteAddress(value);
                NotifyPropertyChanged();
            }
        }
        public string FirewallPort
        {
            get
            {
                return firewallexcept.GetPort();
            }
            set
            {
                firewallexcept.SetPort(value);
                NotifyPropertyChanged();
            }
        }
        private void NotifyFirewall()
        {
            NotifyPropertyChanged("FirewallName");
            NotifyPropertyChanged("FirewallRemoteAddress");
            NotifyPropertyChanged("FirewallPort");
            NotifyPropertyChanged("FirewallExceptionlist");
            
        }
        public ObservableCollection<WAttribute> CustomFirewallExcept
        {
            get
            {
                return firewallexcept.GetCustomFirewallExceptionlist();
            }
        }
        private WAttribute NewFirewallElement = new WAttribute();
        private int currentcustomfw = -1;
        public string NewFWElementLabel
        {
            get
            {
                return NewFirewallElement.GetLabel();
            }
            set
            {
                NewFirewallElement.SetLabel(value);
                NotifyPropertyChanged();
            }
        }
        public string NewFWElementValue
        {
            get
            {
                return NewFirewallElement.GetValue();
            }
            set
            {
                NewFirewallElement.SetValue(value);
                NotifyPropertyChanged();
            }
        }
        private void NotifyCustomFirewall()
        {
            NotifyPropertyChanged("NewFWElementLabel");
            NotifyPropertyChanged("NewFWElementValue");
            NotifyPropertyChanged("CustomFirewallExcept");
        }
        public void GetCustomFWElement(int index)
        {
            NewFirewallElement = CustomFirewallExcept[index];
            NotifyCustomFirewall();
            currentcustomfw = index;
        }
        public void UpdateCustomFWElement()
        {
            if (currentcustomfw != -1)
            {
                firewallexcept.UpdateCustomElement(CustomFirewallExcept[currentcustomfw].GetLabel(), CustomFirewallExcept[currentcustomfw].GetValue(), NewFWElementLabel, NewFWElementValue);
                NewCustomFWElement();
                NotifyCustomFirewall();
            }
        }
        public void RemoveCustomFWElement(int index)
        {
            firewallexcept.RemoveCustomElement(CustomFirewallExcept[index].GetLabel(), CustomFirewallExcept[index].GetValue());
            NotifyCustomFirewall();
        }
        public void NewCustomFWElement()
        {
            NewFirewallElement = new WAttribute();
            currentcustomfw = -1;
            NotifyCustomFirewall();
        }
        public void AddCustomFWElement()
        {
            firewallexcept.AddCustomElement(NewFirewallElement);
            NewCustomFWElement();
        }
        public void AddFirewallExcept()
        {
            project.GetFirewallExceptions().Add(firewallexcept);
            NewFirewallException();
        }
        public void RemoveFirewallExcept(int index)
        {
            project.GetFirewallExceptions().Remove(index);
            NewFirewallException();
        }
        public void GetFirewallException(int index)
        {
            firewallexcept = project.GetFirewallExceptions().Get(index);
            NotifyFirewall();
        }
        public void UpdateFirewallException(int index)
        {
            project.GetFirewallExceptions().Update(index, firewallexcept);
            NotifyFirewall();
        }
        public void NewFirewallException()
        {
            firewallexcept = new FirewallException();
            NewCustomFWElement();            
            NotifyFirewall();            
        }
        #endregion
        #region registry
        /* private RegistryHive Root = RegistryHive.CurrentUser;
        private string Key = "";
        private string Name = "";
        private object Value = null;
        private string FeatureName = "";
*/
        public ObservableCollection<RegistryValue> RegistryValuelist
        {
            get
            {
                return project.GetRegistryValues().GetRegistryValueslist();
            }
        }
        RegistryValue regval = new RegistryValue();        
   
        public RegistryHive RegistryRoot
        {
            get
            {
                return regval.GetRoot();
            }
            set
            {
                regval.SetRoot(value);
                NotifyPropertyChanged();
            }
        }
        public string RegistryKey
        {
            get
            {
                return regval.GetKey();
            }
            set
            {
                regval.SetKey(value);
                NotifyPropertyChanged();
            }
        }
        public string RegistryName
        {
            get
            {
                return regval.GetName();
            }
            set
            {
                regval.SetName(value);
                NotifyPropertyChanged();
            }
        }
        public object RegValue
        {
            get
            {                
                    return regval.GetValue();
            }
            set
            {
                regval.SetValue(value);
                NotifyPropertyChanged();
            }
        }
 
        public void NotifyRegistryValue()
        {
            NotifyPropertyChanged("RegistryRoot");
            NotifyPropertyChanged("RegistryName");
            NotifyPropertyChanged("RegistryKey");
            NotifyPropertyChanged("RegValue");
            NotifyPropertyChanged("RegistryValuelist");
           
        }
        public void AddRegistryValue()
        {
            project.GetRegistryValues().Add(regval);
            NewRegistryValue();
        }
        public void RemoveRegistryValue(int index)
        {
            project.GetRegistryValues().Remove(index);
            NewRegistryValue();
        }
        public void GetRegistryValue(int index)
        {
            regval = project.GetRegistryValues().Get(index);
            NotifyRegistryValue();
        }
        public void UpdateRegistryValue(int index)
        {
            project.GetRegistryValues().Update(index, regval);
            NotifyRegistryValue();
        }
        public void NewRegistryValue()
        {
            regval = new RegistryValue();
            NotifyRegistryValue();

        }
        #endregion
        #region fileassociation
        /*  private string Extension = "";
        private string ContentType = "";
        private string Command = "Open";
        private string CommandArguments = @"\""%1\""";
         */
         public ObservableCollection<FileAssociation> FileAssoclist
        {
            get
            {
                return project.GetGlobalFileAssociations().GetFileAssociationslist();
            }
        }
        private FileAssociation FA = new FileAssociation();
        public string FAExtension
        {
            get
            {
                return FA.GetExtension();
            }
            set
            {
                FA.setExtension(value);
                FA.setContentType($@"application/{value}");
                NotifyPropertyChanged();
                NotifyPropertyChanged("FAContentType");
            }
        }
        public string FAContentType
        {
            get
            {
                return FA.GetContentType();
            }
            set
            {
                FA.setContentType(value);
                NotifyPropertyChanged();
            }
        }
        public string FACommand
        {
            get
            {
                return FA.GetCommand();
           
            }
            set
            {
                FA.setCommand(value);
                NotifyPropertyChanged();
            }
        }
        public string FAArguments
        {
            get
            {
                return FA.GetCommandArguments();
            }
            set
            {
                FA.setCommandArguments(value);
                NotifyPropertyChanged();
            }
        }
        public void NotifyFileAssociation()
        {
            NotifyPropertyChanged("FileAssoclist");
            NotifyPropertyChanged("FAExtension");
            NotifyPropertyChanged("FAContentType");
            NotifyPropertyChanged("FACommand");
            NotifyPropertyChanged("FAArguments");
           
        }
        public void AddFileAssociation()
        {
            project.GetGlobalFileAssociations().Add(FA);
            NewFileAssociation();
        }
        public void RemoveFileAssociation(int index)
        {
            project.GetGlobalFileAssociations().Remove(index);
            NewFileAssociation();
        }
        public void GetFileAssociation(int index)
        {
            FA = project.GetGlobalFileAssociations().Get(index);
            NotifyFileAssociation();
        }
        public void UpdateFileAssociation(int index)
        {
            project.GetGlobalFileAssociations().Update(index, FA);
            NotifyFileAssociation();
        }
        public void NewFileAssociation()
        {
            FA = new FileAssociation();
            NotifyFileAssociation();

        }
        #endregion
        #region sourcefiles
        /* private string Path = "";
        private bool IsMainExecutable = false;
        private string Directory = "APPROOT";
        private bool CreateMenuShortCut = false;
        private bool CreateDeskTopShortCut = false;
        private bool IsLicenseFile = false;
        private bool IsReadMe = false;
        private string FeatureName = "";*/
        private SourceFile SF = new SourceFile();
        public ObservableCollection<SourceFile> Sourcefilelist
        {
            get
            {
                return project.GetSourceFiles().GetSourceFileslist();
            }
        }
        public string SFPath
        {
            get
            {
                return SF.GetPath();
            }
            set
            {
                SF.SetPath(value);
                NotifyPropertyChanged();
            }
        }
        public string SFInstallDir
        {
            get
            {
                return SF.GetDirectory();
            }
            set
            {
                SF.SetDirectory(value);
                NotifyPropertyChanged();
            }
        }
        public bool SFCreateMenuShortcut
        {
            get
            {
                return SF.GetMenuShortcut();
            }
            set
            {
                SF.SetMenuShortcut(value);
                NotifyPropertyChanged();
            }
        }
        public bool SFDesktopShortcut
        {
            get
            {
                return SF.GetDeskTopShortCut();
            }
            set
            {
                SF.SetDeskTopShortcut(value);
                NotifyPropertyChanged();
            }
        }
        public bool SFMainExecutable
        {
            get
            {
                return SF.GetIsMainExecutable();
            }
            set
            {
                SF.SetIsMainExecutable(value);
                NotifyPropertyChanged();
            }
        }
        public bool SFLicenseFile
        {
            get
            {
                return SF.GetIsLicenseFile();
            }
            set
            {
                SF.SetIsLicense(value);
                NotifyPropertyChanged();
            }
        }
        public bool SFReadMeFile
        {
            get
            {
                return SF.GetIsReadMeFile();
            }
            set
            {
                SF.SetIsReadme(value);
                NotifyPropertyChanged();
            }
        }
        public string SFFeature
        {
            get
            {
                return SF.GetFeatureName();
            }
            set
            {
                SF.SetFeatureName(value);
                NotifyPropertyChanged();
            }
        }
        public void NotifySF()
        {
            NotifyPropertyChanged("Sourcefilelist");
            NotifyPropertyChanged("SFPath");
            NotifyPropertyChanged("SFInstallDir");
            NotifyPropertyChanged("SFCreateMenuShortcut");
            NotifyPropertyChanged("SFDesktopShortcut");
            NotifyPropertyChanged("SFMainExecutable");
            NotifyPropertyChanged("SFLicenseFile");
            NotifyPropertyChanged("SFReadMeFile");
            NotifyPropertyChanged("SFFeature");
          
        }
        public void AddSourceFile()
        {
            project.GetSourceFiles().Add(SF);
            NewSourceFile();
        }
        public void RemoveSourceFile(int index)
        {
            project.GetSourceFiles().Remove(index);
            NewSourceFile();
        }
        public void GetSourceFile(int index)
        {
            SF = project.GetSourceFiles().Get(index);
            NotifySF();
        }
        public void UpdateSourceFile(int index)
        {
            project.GetSourceFiles().Update(index, SF);
            NotifySF();
        }
        public void NewSourceFile()
        {
            SF= new SourceFile();
            NotifySF();

        }
        private string csgenscript = "";
        public bool changed = false;
        #endregion
        #region scripts
        public bool DownloadTempWixSharp { get; set; } = true;
        public bool DownloadTempWix { get; set; } = true;
        public bool DownloadPermWixSharp { get; set; } = false;
        public bool DownloadPermWix { get; set; } = false;
        public bool UseLocalWixSharp { get; set; } = false;
        public bool UseLocalWix { get; set; } = false;
        public string WixLocation { get; set; } = "Use Local Location";
        public string WixSharpLocation { get; set; } = "Use Local Location";
        private bool createmsi = true;
        private bool createwxs = false;
        public bool CreateMSI { get
            {
                return createmsi;
            }
            set
            {
                createmsi = value;
                NotifyPropertyChanged();
            }
            }
        public bool CreateWXS {
            get
            {
                return createwxs;
            }
            set
            {
                createwxs = value;
                NotifyPropertyChanged();
            }
        }
        public string CsGenScript
        {
            get
            {
                if ((csgenscript == "")||(changed))
                    GetFreshScript();                
                return csgenscript;
            }
            set
            {
                csgenscript = value;
                changed = false;
            }
        }
       
        private void GetFreshScript()
        {
            WixSharpScript script = new WixSharpScript(project);
            if (createmsi)
                csgenscript = script.GetMSIScript();
            else
                csgenscript = script.GetWxsScript();
            changed = false;
        }
        public Stream GetCsScriptStream()
        {            
            MemoryStream stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(CsGenScript);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
        internal void ClearWix()
        {
            filledwix = false;
            wixlist = new List<string>();
        }
        internal void ClearWixSharp()
        {
            filledwixsharp = false;
            wixsharplist = new List<string>();
        }
        private bool filledwix = false;
        public List<string> wixlist = new List<string>();
        public async void DownloadWix()
        {
            if (!filledwix)
            {
                DLNuget wix = new DLNuget();
                if (UseLocalWix)
                {
                    int num = await wix.RetriveLocalPackageAsync(WixLocation);
                }
                else
                {
                    wix = new DLNuget("Wix");
                    if (DownloadTempWix)
                        wix.UseTempDirectory();
                    int num = await wix.RetrievePackageAsync();
                    WixLocation = wix.GetDirectory();
                    NotifyPropertyChanged("WixLocation");                    
                }
                wixlist = wix.AllFiles;
                bool found = false;
                foreach (var f in wixlist)
                    if ((f.EndsWith("candle.exe"))&&(!found))
                    {
                        found = true;
                        project.GetSignInstaller().SetWixWellKnownLocation(f.Replace("candle.exe", ""));
                        Compileresult += $"Wix located at {project.GetSignInstaller().GetWixWellKnownLocation()}";
                        NotifyPropertyChanged("Compileresult");                        
                        if (DownloadPermWix)
                        {
                            try
                            {
                                Environment.SetEnvironmentVariable("Wix", project.GetSignInstaller().GetWixWellKnownLocation(), EnvironmentVariableTarget.Machine);
                            }
                            catch
                            {
                                Compileresult += $"Your user account does not have permission to create Registry entry to point to Wix location:\n {WixLocation}\n";
                                NotifyPropertyChanged("Compileresult");
                            }
                        }
                    }
                filledwix = true;
            }
        }
        private bool filledwixsharp = false;
        public List<string> wixsharplist = new List<string>();
        public async void DownloadWixSharp()
        {
            if (!filledwixsharp)
            {
                DLNuget wixsharp = new DLNuget();
                if (UseLocalWixSharp)
                {
                    int num = await wixsharp.RetriveLocalPackageAsync(WixSharpLocation);
                }
                else
                {
                    wixsharp = new DLNuget("Wixsharp");
                    if (DownloadTempWixSharp)
                        wixsharp.UseTempDirectory();
                    int num = await wixsharp.RetrievePackageAsync();
                    WixSharpLocation = wixsharp.GetDirectory();
                    NotifyPropertyChanged("WixSharpLocation");
                    if (DownloadPermWixSharp)
                    {
                        try
                        {
                            Environment.SetEnvironmentVariable("WixSharp", WixSharpLocation, EnvironmentVariableTarget.Machine);
                        }
                        catch
                        {
                            Compileresult += $"Your user account does not have permission to create Registry entry to point to Wixsharp location:\n {WixSharpLocation}\n";
                            NotifyPropertyChanged("Compilersult");
                        }
                    }
                }
                wixsharplist = wixsharp.DLLs;
                filledwixsharp = true;
            }
        }
        public string Compileresult { get; set; } = "";
        public string Workingdir = "";
        private string compiledfilename = "";
        private void Setupworkingdirectory()
        {
            Workingdir = $"{System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Wixard\\{ApplicationName}{AppVersion}";
            try
            {
                if (!Directory.Exists(Workingdir))
                    Directory.CreateDirectory(Workingdir);
                
            }
            catch
            { }
            try
            {
                foreach (var f in wixsharplist)
                    File.Copy(f, $@"{Workingdir}\{f.Remove(0, f.LastIndexOf("\\") + 1)}");
            }
            catch
            { }
        }
        public interface WixScript
        {
            object Process(params object[] args);
        }
        public async void CompileScript()
        {
            string cur = Directory.GetCurrentDirectory();
            Random rand = new Random();
            if ((filledwix)||(createwxs))
            {

                Setupworkingdirectory();
              
                Directory.SetCurrentDirectory(Workingdir);
                Compileresult += "\nBeginning Compile...\n";
                NotifyPropertyChanged("Compileresult");

                Compiler compile = new Compiler(CompilerLanguages.csharp, CsGenScript);
                compile.AddUsefulWindowsDesktopAssemblies();
                compile.AddAssemblyLocations(wixsharplist.ToArray());
                if (CsGenScript.Contains("using System.Windows.Forms"))
                {
                    string windowsform = GetSystemWindowsForms();
                    compile.AddAssemblyLocation(windowsform);
                    compile.AddEmbedLocation(windowsform);
                }
                compiledfilename = $"{Workingdir}\\w{rand.Next(0, 5000)}{ApplicationName.Replace(" ", "_")}.exe";
                compile.SetResultFileName(compiledfilename);
                compile.SetToOutputEXE();


                compile.SetToLaunchAfterCompile("Process", new object[] { "nothing", "More Nothing" });
                Thread.Sleep(1000);
                object Value = await compile.CompileRunAsync();
                Type t = Value.GetType();
                if (t.Equals(typeof(CompilerErrorCollection)))
                    foreach (CompilerError e in (CompilerErrorCollection)Value)
                        Compileresult += e.ErrorText;
                else
                {
                    Compileresult += Value.ToString();
                    if (Value.ToString().Contains("Successfully"))
                    {
                        Compileresult += $"\nIt is located at: {Workingdir}";
                        compile = null;

                        Cleanup(compiledfilename);
                    }
                }

            }
            else
                Compileresult += "Still Downloading Wix. Try again in a second\n";
            NotifyPropertyChanged("Compileresult");
            Directory.SetCurrentDirectory(cur);
        }
        private string GetSystemWindowsForms()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            path += @"\Reference Assemblies\Microsoft\Framework\.NETFramework\";
            
                string[] directories = Directory.GetDirectories(path);
                foreach (var d in directories)
                {
                    if (d.CompareTo(path + "v3.5") >= 0)
                    {
                        string test = d + @"\System.Windows.Forms.dll";
                        if (File.Exists(test))
                        {
                            try
                            {
                                File.Copy(test, $@"{Workingdir}\System.Windows.Forms.dll");
                            }
                            catch
                            { }
                            return test;
                        }
                    }
                }            
            return "";
        }
        
        private void Cleanup(string file)
        {
            try
            {
                GC.Collect();
                File.Delete(file);                
            }
            catch
            { }
            try
            {
                try
                {
                    foreach (var f in wixsharplist)
                        File.Delete($@"{Workingdir}\{f.Remove(0, f.LastIndexOf("\\") + 1)}");
                }
                catch
                { }
            }
            catch
            { }
        }

        #endregion
        #region load/save
        public bool Saved { get; set; } = true;
        public string Filename { get; set; } = "";
        public void Load(string file)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = File.Open(file, FileMode.Open))
            using (DeflateStream deflateStream = new DeflateStream(stream,
                                                      CompressionMode.Decompress))
            {
                project = (WIXSharpProject) formatter.Deserialize(deflateStream);
            }
            Filename = file;
            Saved = true;           
            NotifyALL();
        }
        public void Save(string file)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = File.Open(file, FileMode.Create))
            using (DeflateStream deflateStream = new DeflateStream(stream,
                                                      CompressionMode.Compress))
            {
                formatter.Serialize(deflateStream, project);
            }
            Filename = file;
            Saved = true;
        }
        private void sayhello()
        {
            MessageBox.Show("Say Hello");
        }
        #endregion
    }
}
// old code kept in case need for something...
//compile.Compile();
//if (compile.Success)
//{

//    compileresult += $"Compiled Successful. \n Now attempting to create the setup\n";
//    NotifyPropertyChanged("compileresult");
//    Assembly Compiled = compile.GetCompiledAssembly();
//    try
//    {
//        Thread.Sleep(1000);
//        runscript(Compiled);
//    }
//    catch
//    {
//        Thread.Sleep(1000);
//        try
//        {
//            runscript(Compiled);
//        }
//        catch (Exception ex)
//        {
//            compileresult += $"\nFailed to create setup. \n{ex.Message}";
//        }
//    }
//}
//else
//{
//    compileresult = $"Compile Failed. {compile.GetErrorsAsString()}";
//} 
//private bool triedassemblydirectly = false;
//private void runscript(Assembly Compiled)
//{
//    Type type = Compiled.GetTypes()[0];
//    object obj = Activator.CreateInstance(type);


//    object value = type.InvokeMember("Process", BindingFlags.Default | BindingFlags.InvokeMethod, null, obj, null);
//    Type t = value.GetType();
//    if (t.Equals(typeof(CompilerErrorCollection)))
//        foreach (CompilerError e in (CompilerErrorCollection)value)
//            compileresult += e.ErrorText;
//    else
//    {
//        compileresult += value.ToString();
//        if (value.ToString().Equals("Successfully Created Script"))
//        {                   
//            compileresult += $"It is located at: {workingdir}";                    
//        }
//        else if (value.ToString().ToUpper().Contains("LOAD"))
//        {
//            if ((File.Exists(compiledfilename))&&(!triedassemblydirectly))
//                {
//                compileresult += "Attempting to launch script again.\n";
//                triedassemblydirectly = true;
//                Assembly compiled = Assembly.LoadFile(compiledfilename);
//                runscript(compiled);                        
//            }
//        }
//      //  compileresult += $"Unless changed in the editor, it is located in the {System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\Wixard\\{ApplicationName}{AppVersion} folder";
//    }         
//}