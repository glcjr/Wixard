using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
namespace Wixard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {       
        GUIInterface win = new GUIInterface();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = win;            
            win.Addnetids();
            win.CheckEnvironment();
            AppInfoControl.win = win;
            UserControlCheck(AppInfoControl);
            win.changed = false;
            string filename = checkcommandline();
            
            if (filename != string.Empty)            
                Load(filename);
            
        }                
        private void Close(UserControl control)
        {
            try
            {
                control.Visibility = Visibility.Hidden;
            }
            catch
            { }
        }
        private void CloseAll()
        {
            Close(AppInfoControl);
            Close(SetUpOptionsControl);
            Close(SigningPanelControl);
            Close(CertificatesControl);
            Close(UsersPanelControl);
            Close(EnvironVarsControl);
            Close(ElementsControl);
            Close(FeaturesControl);
            Close(FWExceptControl);
            Close(RegistryControl);
            Close(FileAssocControl);
            Close(SFControl);
            Close(CompilerOptionControl);
            Close(AboutControl);
            Close(EditorControl);
            btncompile.Visibility = Visibility.Hidden;
        }
        private bool UserControlCheck(UserControl control)
        {
            try
            {
                if (control.Visibility == Visibility.Hidden)
                {
                    CloseAll();
                    control.Visibility = Visibility.Visible;
                    return true;
                }
                else
                {
                    control.Visibility = Visibility.Hidden;
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }                
        private void btnAppInfoPanel_Click(object sender, RoutedEventArgs e)
        {
            if (UserControlCheck(AppInfoControl))
                AppInfoControl.win = win;
        }
        private void btnSetupOptionsPanel_Click(object sender, RoutedEventArgs e)
        {
            if (UserControlCheck(SetUpOptionsControl))
                SetUpOptionsControl.win = win;
        }        
        private void btnSigningInfo_Click(object sender, RoutedEventArgs e)
        {
            if (UserControlCheck(SigningPanelControl))
                SigningPanelControl.win = win;
        }
        private void btnCertificates_Click(object sender, RoutedEventArgs e)
        {
            if (UserControlCheck(CertificatesControl))
                CertificatesControl.win = win;
        }
        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            if (UserControlCheck(UsersPanelControl))
                UsersPanelControl.win = win;
        }
        private void btnEvars_Click(object sender, RoutedEventArgs e)
        {
            if (UserControlCheck(EnvironVarsControl))
                EnvironVarsControl.win = win;
        }
        private void btnEles_Click(object sender, RoutedEventArgs e)
        {
            if (UserControlCheck(ElementsControl))
                ElementsControl.win = win;
        }
        private void btnFeat_Click(object sender, RoutedEventArgs e)
        {
            if (UserControlCheck(FeaturesControl))
                FeaturesControl.win = win;
        }
        private void btnFW_Click(object sender, RoutedEventArgs e)
        {
            if (UserControlCheck(FWExceptControl))
                FWExceptControl.win = win;
        }
        private void btnRV_Click(object sender, RoutedEventArgs e)
        {
            if (UserControlCheck(RegistryControl))
                RegistryControl.win = win;
        }
        private void btnFA_Click(object sender, RoutedEventArgs e)
        {
            if (UserControlCheck(FileAssocControl))
                FileAssocControl.win = win;
        }
        private void btnSF_Click(object sender, RoutedEventArgs e)
        {
            if (UserControlCheck(SFControl))
                SFControl.win = win;
        }
        private void btnOptions_Click(object sender, RoutedEventArgs e)
        {
            if (UserControlCheck(CompilerOptionControl))
                CompilerOptionControl.win = win;
        }
        private void btnabout_Click(object sender, RoutedEventArgs e)
        {
            if (UserControlCheck(AboutControl))
                AboutControl.win = win;
        }       
        private void btnEditor_Click(object sender, RoutedEventArgs e)
        {
            win.Compileresult = "";
            win.DownloadWixSharp();
            if ((win.CreateMSI)||(win.CreateMSM))
                win.DownloadWix();
            if(UserControlCheck(EditorControl))
            {
                EditorControl.win = win;
                EditorControl.prepareeditor();
            }
            btncompile.Visibility = Visibility.Visible;
        }              
        private void btncompile_Click(object sender, RoutedEventArgs e)
        {
            
            win.CompileScript(EditorControl.EditorSource);        
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);
        }
        private Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            List<string> wixsharp = win.wixsharplist;
            bool found = false;
            string location = "";
            string targetfilename;
            if (args.Name.Contains(','))
                targetfilename = args.Name.Substring(0, args.Name.IndexOf(","));
            else
                targetfilename = args.Name;
            if (File.Exists($@"{win.Workingdir}/{targetfilename}.exe"))
            {
                found = true;
                location = $@"{win.Workingdir}/{targetfilename}.exe";
            }
            else if (File.Exists($@"{win.Workingdir}/{targetfilename}.dll"))
            {
                found = true;
                location = $@"{win.Workingdir}/{targetfilename}.dll";
            }
            if (!found)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                path += $@"\Microsoft.NET\assembly\GAC_MSIL\{targetfilename}";
                found = FindDll(path, targetfilename, out location);         
            }
            if (!found)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                path += $@"\Microsoft.NET\assembly\GAC_32\{targetfilename}";
                found = FindDll(path, targetfilename, out location);
            }
            if (!found)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                path += @"\Reference Assemblies\Microsoft\Framework\.NETFramework\";
                string[] directories = Directory.GetDirectories(path);
                foreach (var d in directories)
                {
                    if (d.CompareTo(path + "v4.6.1") >= 0)
                    {
                        string test = d + $@"\{targetfilename}.dll";
                        if (File.Exists(test))
                        {
                            found = true;
                            location = test;
                        }
                    }
                }
            }
            if (!found)
            {
                foreach (var f in wixsharp)
                    if (f.EndsWith($"{targetfilename}.dll"))
                    {
                        location = f;//.Replace("WixSharp.dll", "") + location + ".dll";
                        found = true;
                        break;
                    }
            }
            if (found)
            {
                Assembly MyAssembly = Assembly.LoadFrom(location);                
                return MyAssembly;
            }
            else
                throw new Exception($"Assembly {location} not found");
        }
        private bool FindDll(string path, string targetfilename, out string location)
        {
            bool found = false;
            location = "";
            string[] directories = Directory.GetDirectories(path);
            foreach (var d in directories)
            {               
                    string test = d + $@"\{targetfilename}.dll";
                    if (File.Exists(test))
                    {
                        found = true;
                        location = test;
                    }               
            }
            return found;
        }
        private void btnFileOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Wixard Files(*.wxg)| *.wxg|All Files(*.*)|*.*";
            of.InitialDirectory = SetInitDirectory();
            if (of.ShowDialog() == true)
            {
                Load(of.FileName);
            }
        }
        private void Load(string filename)
        {
            try
            {
                win.Load(filename);
                if (win.MinimumNet != string.Empty)
                    win.NeedNet = true;
                win.changed = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private string SetInitDirectory()
        {
            string initdir = $@"{System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\Wixard";
            if (!(Directory.Exists(initdir)))
                Directory.CreateDirectory(initdir);
            return initdir;
        }
        private void btnFileSaveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveAs();          
         
        }
        private void SaveAs()
        {
            SetInitDirectory();
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Wixard Files(*.wxg)| *.wxg|All Files(*.*)|*.*";
            sf.InitialDirectory = SetInitDirectory();
            if (sf.ShowDialog() == true)
            {
                win.Save(sf.FileName);
                win.changed = false;
            }
        }
        private void btnFileSave_Click(object sender, RoutedEventArgs e)
        {
            save();
        }
        private void save()
        {
            if (win.Filename == string.Empty)
                SaveAs();
            else
            {
                win.Save(win.Filename);
                win.changed = false;
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (win.changed)
                {
                    e.Cancel = true;
                    win.changed = false;
                    if (MessageBox.Show("Save Your Changes?", "Changes to file", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        save();
                    }
                    else
                        System.Windows.Application.Current.Shutdown();
                }
            }
            catch
            { }
        }
        private string checkcommandline()
        {
            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                string fileName = "";
                int index = 1;
                while ((index < args.Length) && (!(fileName.Contains(".wxg"))))
                {
                    fileName += $"{args[index]} ";
                    index++;
                }
                fileName = fileName.Trim();
                if (File.Exists(fileName))
                {
                    var extension = System.IO.Path.GetExtension(fileName);
                    if (extension == ".wxg")
                    {
                        return fileName;
                    }
                }
            }
            return string.Empty;
        }
    }
}
