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
    public class SourceFile : ISerializable
    {
        private string Path = "";
        private bool IsMainExecutable = false;
        private string Directory = "APPROOT";
        private bool CreateMenuShortCut = false;
        private bool CreateDeskTopShortCut = false;
        private bool IsLicenseFile = false;
        private bool IsReadMe = false;
        private string FeatureName = "None";
        private FirewallExceptions FirewallExcept = new FirewallExceptions();
        private FileAssociations fileassociations = new FileAssociations();
        public SourceFile()
        {
            Path = "";
        }
        public SourceFile(string path, string directory = "APPROOT", bool ismainexecutable = false, bool createmenushortcut = false, bool createdesktopshortcut = false)
        {
            Path = path;
            Directory = directory;
            IsMainExecutable = ismainexecutable;
            CreateMenuShortCut = createmenushortcut;
            CreateDeskTopShortCut = createdesktopshortcut;
        }
        public SourceFile(string path, bool islicense)
        {
            Path = path;
            if (islicense)
                IsLicenseFile = islicense;
            else
                IsReadMe = true;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("path", Path, typeof(string));
            info.AddValue("mainexecutable", IsMainExecutable, typeof(bool));
            info.AddValue("directory", Directory, typeof(string));
            info.AddValue("menushortcut", CreateMenuShortCut, typeof(bool));
            info.AddValue("desktopshortcut", CreateDeskTopShortCut, typeof(bool));
            info.AddValue("licensefile", IsLicenseFile, typeof(bool));
            info.AddValue("featurename", FeatureName, typeof(string));
            info.AddValue("firewallexceptions", FirewallExcept, typeof(FirewallExceptions));
            info.AddValue("fileassociations", fileassociations, typeof(FileAssociations));
        }
        public SourceFile(SerializationInfo info, StreamingContext context)
        {
            Path = (string)info.GetValue("path", typeof(string));
            IsMainExecutable = (bool)info.GetValue("mainexecutable", typeof(bool));
            Directory = (string)info.GetValue("directory", typeof(string));
            CreateMenuShortCut = (bool)info.GetValue("menushortcut", typeof(bool));
            CreateDeskTopShortCut = (bool)info.GetValue("desktopshortcut", typeof(bool));
            IsLicenseFile = (bool)info.GetValue("licensefile", typeof(bool));
            FeatureName = (string)info.GetValue("featurename", typeof(string));
            FirewallExcept = (FirewallExceptions)info.GetValue("firewallexceptions", typeof(FirewallExceptions));
            fileassociations = (FileAssociations)info.GetValue("fileassociations", typeof(FileAssociations));
        }
        public void SetIsMainExecutable(bool ismain)
        {
            IsMainExecutable = ismain;
        }
        public bool GetIsMainExecutable()
        {
            return IsMainExecutable;
        }
        public void ClearFileAssociation()
        {
            fileassociations.Clear();
        }
        public bool GetIsLicenseFile()
        {
            return IsLicenseFile;
        }
        public bool GetIsReadMeFile()
        {
            return IsReadMe;
        }
        public void SetPath(string path)
        {
            Path = path;
        }
        public string GetPath()
        {
            return Path;
        }
        public void SetDirectory(string directory)
        {
            Directory = directory;
        }
        public string GetDirectory()
        {
            return Directory;
        }
        public bool GetMenuShortcut()
        {
            return CreateMenuShortCut;
        }
        public void SetFeatureName(string feature)
        {
            FeatureName = feature;
        }
        public string GetFeatureName()
        {
            return FeatureName;
        }
        public void RemoveFeature()
        {
            FeatureName = "";
        }
        public void SetMenuShortcut(bool makeshortcut)
        {
            CreateMenuShortCut = makeshortcut;
        }
        public bool GetDeskTopShortCut()
        {
            return CreateDeskTopShortCut;
        }
        public void SetDeskTopShortcut(bool makeshortcut)
        {
            CreateDeskTopShortCut = makeshortcut;
        }
        public void AddFileAssociation(FileAssociation association)
        {
           
            fileassociations.Add(association);
        }
        public string GetFileLine(string shortcuttitle="", string progmenu="")
        {
            string line = $"new File(";
            if ((FeatureName != string.Empty)&&(FeatureName != "None"))
                line += $"{FeatureName}, ";
            line += $"@\"{Path}\"";
            line += FirewallExcept.GetLine();
            line += fileassociations.GetLine();
            if (CreateMenuShortCut)
                line += $",{Environment.NewLine} new FileShortcut(\"{shortcuttitle}\", @\"{progmenu}\")      {{    WorkingDirectory = \"[INSTALLDIR]\"   }}";
            if (CreateDeskTopShortCut)
                line += $", {Environment.NewLine}new FileShortcut(\"{shortcuttitle}\", @\"%Desktop%\")      {{    WorkingDirectory = \"[INSTALLDIR]\" }}";
            line += $")";
            return line;
        }
        public void AddFirewallException(string name, string remoteaddress)
        {
            FirewallExcept.Add(new FirewallException(name, remoteaddress));
        }
        public void AddFirewallException(string name, string remoteaddress, string port)
        {
            FirewallExcept.Add(new FirewallException(name, remoteaddress, port));
        }
        public void AddFireWallException(FirewallException exception)
        {
            FirewallExcept.Add(exception);
        }
        public override string ToString()
        {
            return $"{Path.Remove(0, Path.LastIndexOf(@"\"))}";
        }
        public void SetIsLicense(bool isit)
        {
            IsLicenseFile = isit;
        }
        public void SetIsReadme(bool isit)
        {
            IsReadMe = isit;
        }

    }
}
