using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class SourceFiles : ISerializable
    {
        List<SourceFile> Files = new List<SourceFile>();

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("files", Files, typeof(List<SourceFile>));
        }
        public SourceFiles(SerializationInfo info, StreamingContext context)
        {
            Files = (List<SourceFile>)info.GetValue("files", typeof(List<SourceFile>));
        }
        public SourceFiles()
        {
            Files = new List<SourceFile>();
        }
        public SourceFiles(List<SourceFile> files)
        {
            Files = files;
        }
        public SourceFiles(SourceFile file)
        {
            Files.Add(file);
        }
        public int Count
        {
            get
            {
                return Files.Count;
            }
        }
        public SourceFile this[int index]
        {
            get
            {
                return Files[index];
            }
            set
            {
                Files[index] = value;
            }
        }
        public bool FindFile(string Path, out int index)
        {
            bool found = false;
            int i = 0; index = -1;
            foreach (var file in Files)
            {
                if (file.GetPath().Equals(Path))
                {
                    found = true;
                    index = i;
                }
                i++;
            }
            return found;
        }
        public void Add(string Path, string directory = "APPROOT", bool mainexecutable = false, bool menushortcut = false, bool desktopshortcut = false)
        {
            if (FindFile(Path, out int index))
            {
                Files[index].SetDirectory(directory);
                Files[index].SetIsMainExecutable(mainexecutable);
                Files[index].SetMenuShortcut(menushortcut);
                Files[index].SetDeskTopShortcut(desktopshortcut);
            }
            else
                Files.Add(new SourceFile(Path, directory, mainexecutable, menushortcut, desktopshortcut));
        }
        public void Add(SourceFile file)
        {
            if (FindFile(file.GetPath(), out int index))
                Files[index] = file;
            else
                Files.Add(file);
        }
        public void Remove(string Path)
        {
            foreach (var file in Files)
                if (file.GetPath().Equals(Path))
                    Files.Remove(file);
        }
        public void Remove(SourceFile file)
        {
            Files.Remove(file);
        }
        public void AddLicense(string path)
        {
            Files.Add(new SourceFile(path, true));
        }
        public void AddReadMe(string path)
        {
            Files.Add(new SourceFile(path, false));
        }
        public string GetLicensePath()
        {
            string license = "";
            foreach (var file in Files)
            {
                if (file.GetIsLicenseFile())
                    license = file.GetPath();
            }
            return license;
        }
        public SourceFile GetLicense()
        {
            foreach (var file in Files)
            {
                if (file.GetIsLicenseFile())
                    return file;
            }
            return new SourceFile();
        }
        public string GetReadMePath()
        {
            string readme = "";
            foreach (var file in Files)
            {
                if (file.GetIsReadMeFile())
                    readme = file.GetPath();
            }
            return readme;
        }
        public SourceFile GetReadMe()
        {
            foreach (var file in Files)
            {
                if (file.GetIsReadMeFile())
                    return file;
            }
            return new SourceFile();
        }
        public string GetAppMainDirectory()
        {
            foreach (var file in Files)
                if (file.GetIsMainExecutable())
                    return file.GetDirectory();
            return "";
        }
        public List<string> GetDirectories(bool excludemain = false)
        {
            string maindirectory = "";
            if (excludemain)
                maindirectory = GetAppMainDirectory();
            List<string> Directories = new List<string>();
            foreach (var file in Files)
            {
                if (!(file.GetDirectory().Contains(maindirectory)))
                    if (!(Directories.Contains(file.GetDirectory())))
                        Directories.Add(file.GetDirectory());
            }
            Directories.Sort();
            return Directories;
        }
        public string GetSubdirectoryfiles()
        {
            string subdirectories = "";
            foreach (var newdirectory in GetMainSubdirectories())
            {
                subdirectories += $", new Dir(@\"{newdirectory.Replace(GetAppMainDirectory() + @"\", "")}\"";
                foreach (var file in GetSourceFiles(newdirectory))
                    subdirectories += $",{Environment.NewLine} {file.GetFileLine()}";
                subdirectories += ")";
            }
            return subdirectories;
        }
        public List<string> GetMainSubdirectories()
        {
            string maindirectory = GetAppMainDirectory();
            List<string> Directories = new List<string>();
            foreach (var file in Files)
            {
                if (file.GetDirectory().StartsWith(maindirectory + @"\"))
                    if (!(Directories.Contains(file.GetDirectory())))
                        Directories.Add(file.GetDirectory());
            }
            Directories.Sort();
            return Directories;
        }
        public List<SourceFile> GetSourceFiles()
        {
            return Files;
        }
        public List<SourceFile> GetSourceFiles(string Directory)
        {
            List<SourceFile> list = new List<SourceFile>();
            foreach (var file in Files)
                if (file.GetDirectory().Equals(Directory))
                    if ((!(file.GetIsMainExecutable())) && (!(file.GetIsLicenseFile())) && (!(file.GetIsReadMeFile())))
                        list.Add(file);
            return list;
        }
        public string GetMainExecutableLicenseReadMeLine(string productname, string progmenu)
        {
            string mainexec = "";
            string license = "";
            string readme = "";

            foreach (var file in Files)
            {
                if (file.GetIsMainExecutable())
                {
                    mainexec = file.GetFileLine(productname, progmenu);
                }
                if (file.GetIsLicenseFile())
                {
                    license = $",{Environment.NewLine}{file.GetFileLine("License")}";
                }
                if (file.GetIsReadMeFile())
                {
                    readme = $",{Environment.NewLine}{file.GetFileLine("Readme")}";
                }
            }

            return mainexec + license + readme;
        }
        public ObservableCollection<SourceFile> GetSourceFileslist()
        {
            var result = new ObservableCollection<SourceFile>();
            foreach (var item in Files)
                result.Add(item);
            return result;
        }
        public void Remove(int index)
        {
            Files.RemoveAt(index);
        }
        public SourceFile Get(int index)
        {
            return Files[index];
        }
        public void Update(int index, SourceFile elem)
        {
            Files[index] = elem;
        }
    }
}
