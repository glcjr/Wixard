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
    public class AdvancedOptions
    {
        private Certificates Certs = new Certificates();
        private Users users = new Users();
        private EnvironmentVars EnvironmentVariables = new EnvironmentVars();
        private Elements WElements = new Elements();
        private Features feature = new Features();
        private FirewallExceptions FirewallExcept = new FirewallExceptions();
        private FileAssociations GlobalFileAssociations = new FileAssociations();
        private RegistryValues Registryvalues = new RegistryValues();

        public AdvancedOptions()
        {
            Certs = new Certificates();
            users = new Users();
            EnvironmentVariables = new EnvironmentVars();
            WElements = new Elements();
            feature = new Features();
            FirewallExcept = new FirewallExceptions();
            GlobalFileAssociations = new FileAssociations();
            Registryvalues = new RegistryValues();
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("certificates", Certs, typeof(Certificates));
            info.AddValue("users", users, typeof(Users));
            info.AddValue("environmentvars", EnvironmentVariables, typeof(EnvironmentVars));
            info.AddValue("welements", WElements, typeof(Elements));
            info.AddValue("features", feature, typeof(Features));
            info.AddValue("firewallexceptions", FirewallExcept, typeof(FirewallExceptions));
            info.AddValue("fileassociations", GlobalFileAssociations, typeof(FileAssociations));
            info.AddValue("registryvalues", Registryvalues, typeof(RegistryValues));
        }
        public AdvancedOptions(SerializationInfo info, StreamingContext context)
        {
            Certs = (Certificates)info.GetValue("certificates", typeof(Certificates));
            users = (Users)info.GetValue("users", typeof(Users));
            EnvironmentVariables = (EnvironmentVars)info.GetValue("environmentvars", typeof(EnvironmentVars));
            WElements = (Elements)info.GetValue("welements", typeof(Elements));
            feature = (Features)info.GetValue("features", typeof(Features));
            FirewallExcept = (FirewallExceptions)info.GetValue("firewallexceptions", typeof(FirewallExceptions));
            GlobalFileAssociations = (FileAssociations)info.GetValue("fileassociations", typeof(FileAssociations));
            Registryvalues = (RegistryValues)info.GetValue("registryvalues", typeof(RegistryValues));
        }
        public Certificates GetCerts()
        {
            return Certs;
        }
        public Users GetUsers()
        {
            return users;
        }
        public Elements GetElements()
        {
            return WElements;
        }
        public Features GetFeatures()
        {
            return feature;
        }
        public FirewallExceptions GetFirewallExceptions()
        {
            return FirewallExcept;
        }
        public RegistryValues GetRegistryValues()
        {
            return Registryvalues;
        }
        public EnvironmentVars GetEnvironmentVars()
        {
            return EnvironmentVariables;
        }
        public FileAssociations GetGlobalFileAssociations()
        {
            return GlobalFileAssociations;
        }
        public void AddElement(string EleName, string Id, string val, string Root = "Product")
        {
            WElements.Add(EleName, Id, val, Root);
        }
        public void AddRegistryValue(RegistryValue regvalue)
        {
            Registryvalues.Add(regvalue);
        }
        public void AddRegistryValue(RegistryHive root, string key, string nm, object value)
        {
            Registryvalues.Add(new RegistryValue(root, key, nm, value));
        }
        public void AddRegistryValue(string featurename, RegistryHive root, string key, string nm, object value)
        {
            RegistryValue regval = new RegistryValue(root, key, nm, value);
            regval.SetFeature(featurename);
            Registryvalues.Add(regval);
        }
        public void AddFileAssociation(FileAssociation association)
        {
            GlobalFileAssociations.Add(association);
        }
        public void AddElement(Element element)
        {
            WElements.Add(element);
        }
        public void AddFeature(Feature featur)
        {
            feature.Add(featur);
        }
        public void AddFirewallException(string name, string remoteaddress)
        {
            FirewallExcept.Add(new FirewallException(name, remoteaddress));
        }
        public void AddFirewallException(string name, string remoteaddress, string port)
        {
            FirewallExcept.Add(new FirewallException(name, remoteaddress, port));
        }
        public void AddFirewallException(FirewallException exception)
        {
            FirewallExcept.Add(exception);
        }
        public void AddEnvironmentVariable(string varnm, string dir = "[INSTALLDIR]", string placement = "", string condition = "")
        {
            EnvironmentVariables.Add(new EnvironmentVar(varnm, dir, placement, condition));
        }
        public void AddEnvironmentVariable(EnvironmentVar var)
        {
            EnvironmentVariables.Add(var);
        }
        public void RemoveEnvironmentVariable(int index)
        {
            EnvironmentVariables.Remove(index);
        }
        public EnvironmentVar GetEnvironmentVariable(int index)
        {
            return EnvironmentVariables.Get(index);
        }
        public void UpdateEnvironmentVariable(int index, EnvironmentVar evar)
        {
            EnvironmentVariables.Update(index, evar);
        }
        public void AddCertificate(Certificate cert)
        {
            Certs.Add(cert);
        }
        public void AddCertificate(string name, string certificatepath, string storelocation = "localMachine", string storename = "personal", bool authorityrequest = false)
        {
            Certs.Add(name, certificatepath, storelocation, storename, authorityrequest);
        }
        public void RemoveCertificate(Certificate cert)
        {
            Certs.Remove(cert);
        }
        public void RemoveCertificate(int index)
        {
            Certs.Remove(index);
        }
        public Certificate GetCertificate(int index)
        {
            return Certs.Get(index);
        }
        public void UpdateCertificate(int index, Certificate cert)
        {
            Certs.Update(index, cert);
        }
        public void AddUser(string name, string password, string domain = "Environment.MachineName", bool pwneverexpire = true)
        {
            users.Add(name, password, domain, pwneverexpire);
        }
        public void AddUser(User user)
        {
            users.Add(user);
        }
        public void RemoveUser(int index)
        {
            users.Remove(index);
        }
        public User GetUser(int index)
        {
            return users.Get(index);
        }
        public void UpdateUser(int index, User user)
        {
            users.Update(index, user);
        }
    }
}
