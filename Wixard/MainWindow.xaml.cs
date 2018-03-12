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
            cbRegHive.ItemsSource = Enum.GetValues(typeof(WIXSharpHelper.RegistryHive));
            win.Addnetids();
            win.CheckEnvironment();
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            lblVersion.Content = AssemblyName.GetAssemblyName(assembly.Location).Version.ToString();
            GridCheck(AppInfo);
        }
        
        private void Btnchangeicon_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Image files (*.jpg, *.jpeg, *.gif, *.bmp, *.png) | *.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (of.ShowDialog()== true)       
                win.Icon = of.FileName;                            
        }
        private void Close(Grid panel)
        {
            try
            {
                panel.Visibility = Visibility.Hidden;
            }
            catch
            { }
        }
        private void CloseAll()
        {
            Close(AppInfo);
            Close(SetupOptionsPanel);
            Close(SigningPanel);
            Close(CertificatesGrid);
            Close(UsersGrid);
            Close(EvarsGrid);
            Close(ElemsGrid);
            Close(FeatGrid);
            Close(FWEGrid);
            Close(RegistryValsGrid);
            Close(FileAssocGrid);
            Close(SFilesGrid);
            Close(EditorGrid);
            Close(CompileOptionsGrid);
            Close(AboutGrid);
            btncompile.Visibility = Visibility.Hidden;
        }
        private void GridCheck(Grid panel)
        {
            try
            {
                if (panel.Visibility == Visibility.Hidden)
                {
                    CloseAll();
                    panel.Visibility = Visibility.Visible;
                }
                else
                    panel.Visibility = Visibility.Hidden;
            }
            catch
            { }
        }
        private void btnAppInfoPanel_Click(object sender, RoutedEventArgs e)
        {
            GridCheck(AppInfo);
        }

        private void btnSetupOptionsPanel_Click(object sender, RoutedEventArgs e)
        {
            GridCheck(SetupOptionsPanel);
        }
        private void cbnetframework_Checked(object sender, RoutedEventArgs e)
        {
            if (cbnetframework.IsChecked.Value)
                NetFrameworkPanel.Visibility = Visibility.Visible;
            else
                NetFrameworkPanel.Visibility = Visibility.Hidden;
        }
        private void btnSigningInfo_Click(object sender, RoutedEventArgs e)
        {
            GridCheck(SigningPanel);
        }
        #region certs
        private void btnRmvCert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                win.RemoveCertificate(CertsList.SelectedIndex);
                
            }
            catch
            {

            }
            win.NewCert();
            btnupdateadd.Content = "Add";
        }

        private void CertsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            win.GetCertificate(CertsList.SelectedIndex);
            btnupdateadd.Content = "Update";
        }

        private void btnupdateadd_Click(object sender, RoutedEventArgs e)
        {
            if (btnupdateadd.Content.Equals("Update"))
            {
                win.UpdateCertificate(CertsList.SelectedIndex);
            }
            else
                win.AddCertificate();
            win.NewCert();
            btnupdateadd.Content = "Add";
        }

        private void btnAddCert_Click(object sender, RoutedEventArgs e)
        {
            win.NewCert();
            btnupdateadd.Content = "Add";
        }

        private void btnGetCerPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Certificate files (*.pfx, *.cer, *.crt, *.p12, *.pem) | *.pfx; *.cer; *.crt; *.p12; *.pem|All Files (*.*)|*.*";
            if (of.ShowDialog() == true)
                win.CertPath = of.FileName;
        }
        private void btnCertificates_Click(object sender, RoutedEventArgs e)
        {
            GridCheck(CertificatesGrid);
        }
        #endregion
        #region users
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            win.NewUser();
            btnupdateadduser.Content = "Add";
        }

        private void btnRmvUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                win.RemoveUser(UsersList.SelectedIndex);

            }
            catch
            {

            }
            win.NewUser();
            btnupdateadduser.Content = "Add";
        }

        private void UsersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            win.GetUser(UsersList.SelectedIndex);
            btnupdateadduser.Content = "Update";
        }

        private void btnupdateadduser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnupdateadduser.Content.Equals("Update"))
                {
                    win.UpdateUser(UsersList.SelectedIndex);
                }
                else
                    win.AddUser();
                win.NewUser();
                btnupdateadduser.Content = "Add";
            }
            catch ( Exception ex)
                {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            GridCheck(UsersGrid);
        }
        #endregion
        #region environment
        private void btnAddEvar_Click(object sender, RoutedEventArgs e)
        {
            win.NewEvar();
            btnupdateaddevar.Content = "Add";
        }

        private void btnRmvEvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                win.RemoveEvar(EvarsList.SelectedIndex);
            }
            catch
            {

            }
            win.NewEvar();
            btnupdateaddevar.Content = "Add";
        }

        private void btnupdateaddevar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnupdateaddevar.Content.Equals("Update"))               
                    win.UpdateEvar(EvarsList.SelectedIndex);                
                else
                    win.AddEvar();
                win.NewEvar();
                btnupdateaddevar.Content = "Add";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EvarsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            win.GetEvar(EvarsList.SelectedIndex);
            btnupdateaddevar.Content = "Update";
        }

        private void btnEvars_Click(object sender, RoutedEventArgs e)
        {
            GridCheck(EvarsGrid);
        }
        #endregion
        #region elements
        private void ElemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            win.GetElem(ElemsList.SelectedIndex);
            btnupdateaddelem.Content = "Update";
        }

        private void btnupdateaddelem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnupdateaddelem.Content.Equals("Update"))
                    win.UpdateElem(ElemsList.SelectedIndex);
                else
                    win.AddElem();
                win.NewElem();
                btnupdateaddelem.Content = "Add";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CustomElemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            win.GetCustomElement(CustomElemsList.SelectedIndex);
            btnAddCustomElem.Content = "Update";
        }

        private void btnAddElem_Click(object sender, RoutedEventArgs e)
        {
            win.NewElem();
            btnAddElem.Content = "Add";
            btnAddCustomElem.Content = "Add";
        }

        private void btnRmvElem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                win.RemoveElem(ElemsList.SelectedIndex);
            }
            catch
            {

            }
            win.NewElem();
            btnupdateaddelem.Content = "Add";
            btnAddCustomElem.Content = "Add";
        }

        private void btnRmvCustomElem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                win.RemoveCustomElement(CustomElemsList.SelectedIndex);
            }
            catch
            {

            }
            win.NewCustomElement();
         
            btnAddCustomElem.Content = "Add";
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            win.NewCustomElement();
            btnAddCustomElem.Content = "Add";
        }

        private void btnAddCustomElem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnAddCustomElem.Content.Equals("Update"))
                    win.UpdateCustomElement();
                else
                    win.AddCustomElement();
                win.NewCustomElement();
                btnAddCustomElem.Content = "Add";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void btnEles_Click(object sender, RoutedEventArgs e)
        {
            GridCheck(ElemsGrid);
        }
        #endregion
        #region features
        private void btnAddFeature_Click(object sender, RoutedEventArgs e)
        {
            win.NewFeature();
            btnupdateaddfeat.Content = "Add";
        }

        private void btnRmvFeature_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                win.RemoveFeature(FeatsList.SelectedIndex);
            }
            catch
            {

            }
            win.NewFeature();
            btnupdateaddfeat.Content = "Add";
        }

        private void FeatsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            win.GetFeature(FeatsList.SelectedIndex);
            btnupdateaddfeat.Content = "Update";
        }

        private void btnupdateaddfeat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnupdateaddfeat.Content.Equals("Update"))
                    win.UpdateFeature(FeatsList.SelectedIndex);
                else
                    win.AddFeature();
                win.NewFeature();
                btnupdateaddfeat.Content = "Add";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFeat_Click(object sender, RoutedEventArgs e)
        {
            GridCheck(FeatGrid);
        }
        #endregion
        #region firewallexc
        private void btnFW_Click(object sender, RoutedEventArgs e)
        {
            GridCheck(FWEGrid);
        }

        private void btnAddFWE_Click(object sender, RoutedEventArgs e)
        {
            win.NewFirewallException();
            btnupdateaddFWE.Content = "Add";
        }

        private void btnRmvFWE_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                win.RemoveFirewallExcept(FWEsList.SelectedIndex);
            }
            catch
            {

            }
            win.NewFirewallException();
            btnupdateaddFWE.Content = "Add";
        }

        private void btnupdateaddFWE_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnupdateaddFWE.Content.Equals("Update"))
                    win.UpdateFirewallException(FWEsList.SelectedIndex);
                else
                    win.AddFirewallExcept();
                win.NewFirewallException();
                btnupdateaddFWE.Content = "Add";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRmvCustomFWE_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                win.RemoveCustomFWElement(CustomFWEList.SelectedIndex);
            }
            catch
            {

            }
            win.NewCustomFWElement();

            btnAddCustomFWE.Content = "Add";
        }

        private void btnCancelFWE_Click(object sender, RoutedEventArgs e)
        {
            win.NewCustomFWElement();
            btnAddCustomFWE.Content = "Add";
        }

        private void btnAddCustomFWE_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnAddCustomFWE.Content.Equals("Update"))
                    win.UpdateCustomFWElement();
                else
                    win.AddCustomFWElement();
                win.NewCustomFWElement();
                btnAddCustomFWE.Content = "Add";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CustomFWEList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            win.GetCustomFWElement(CustomFWEList.SelectedIndex);
            btnAddCustomFWE.Content = "Update";
        }

        private void FWEsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            win.GetFirewallException(FWEsList.SelectedIndex);
            btnupdateaddFWE.Content = "Update";


        }
        #endregion
        #region registry
        private void btnRV_Click(object sender, RoutedEventArgs e)
        {
            GridCheck(RegistryValsGrid);
        }

        private void btnAddRegVar_Click(object sender, RoutedEventArgs e)
        {
            win.NewRegistryValue();
            btnupdateaddRegVar.Content = "Add";
        }

        private void btnRmvRegVar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                win.RemoveRegistryValue(RegVarsList.SelectedIndex);
            }
            catch
            {

            }
            win.NewRegistryValue();

            btnupdateaddRegVar.Content = "Add";
        }

        private void RegVarsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            win.GetRegistryValue(RegVarsList.SelectedIndex);
            btnupdateaddRegVar.Content = "Update";
        }

        private void btnupdateaddRegVar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnupdateaddRegVar.Content.Equals("Update"))
                    win.UpdateRegistryValue(RegVarsList.SelectedIndex);
                else
                    win.AddRegistryValue();
                win.NewRegistryValue();
                btnupdateaddRegVar.Content = "Add";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region fileassoc
        private void btnFA_Click(object sender, RoutedEventArgs e)
        {
            GridCheck(FileAssocGrid);
        }

        private void FileAssocsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            win.GetFileAssociation(FileAssocsList.SelectedIndex);
            btnupdateaddFileAssoc.Content = "Update";
        }

        private void btnAddFileAssoc_Click(object sender, RoutedEventArgs e)
        {
            win.NewFileAssociation();
            btnupdateaddFileAssoc.Content = "Add";
        }

        private void btnRmvFileAssoc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                win.RemoveFileAssociation(FileAssocsList.SelectedIndex);
            }
            catch
            {

            }
            win.NewFileAssociation();

            btnupdateaddFileAssoc.Content = "Add";
        }

        private void btnupdateaddFileAssoc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnupdateaddFileAssoc.Content.Equals("Update"))
                    win.UpdateFileAssociation(FileAssocsList.SelectedIndex);
                else
                    win.AddFileAssociation();
                win.NewFileAssociation();
                btnupdateaddFileAssoc.Content = "Add";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region sourcefiles
        private List<string> additionalfiles = new List<string>();
        private void btnAddSF_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "All Files(*.*)|*.*";
            of.Multiselect = true;
            if (of.ShowDialog() == true)
            {
                win.NewSourceFile();
                btnupdateaddSF.Content = "Add";
                additionalfiles = new List<string>();
                win.SFPath = of.FileNames[0];
                for (int index = 1; index < of.FileNames.Length; index++)
                {
                    additionalfiles.Add(of.FileNames[index]);
                }
            }
        }

        private void btnRmvSF_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                win.RemoveSourceFile(SFilesList.SelectedIndex);
            }
            catch
            {

            }
            win.NewSourceFile();

            btnupdateaddSF.Content = "Add";
        }

        private void SFilesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            win.GetSourceFile(SFilesList.SelectedIndex);
            btnupdateaddSF.Content = "Update";
        }

        private void btnupdateaddSF_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnupdateaddSF.Content.Equals("Update"))
                    win.UpdateSourceFile(SFilesList.SelectedIndex);
                else
                {
                    string feat = win.SFFeature;
                    string dir = win.SFInstallDir;
                    bool mshort = win.SFCreateMenuShortcut;
                    bool dshort = win.SFDesktopShortcut;
                    win.AddSourceFile();                   
                    foreach (var f in additionalfiles)
                    {
                        win.NewSourceFile();
                        win.SFPath = f;
                        win.SFFeature = feat;
                        win.SFInstallDir = dir;
                        win.SFCreateMenuShortcut = mshort;
                        win.SFDesktopShortcut = dshort;
                        win.AddSourceFile();
                    }
                }
                win.NewSourceFile();
                btnupdateaddSF.Content = "Add";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSF_Click(object sender, RoutedEventArgs e)
        {
            GridCheck(SFilesGrid);
        }
        #endregion
       // FoldingManager foldingManager;
       //object foldingStrategy;
        private void btnEditor_Click(object sender, RoutedEventArgs e)
        {
            win.Compileresult = "";
            win.DownloadWixSharp();
            if (win.CreateMSI)
                win.DownloadWix();
            textEditor.ShowLineNumbers = true;
            TextOptions.SetTextFormattingMode(textEditor, TextFormattingMode.Display);
            textEditor.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.CSharp.CSharpIndentationStrategy(textEditor.Options); // wish this would update a loaded script to make it look nicer like Visual Studio does...
            textEditor.Load(win.GetCsScriptStream()); // Yes I know about setting it to a string rather than using Load but that results in an error if someone leaves the editor to change something in the GUI and comes back to the script when it updates.
            GridCheck(EditorGrid);
            btncompile.Visibility = Visibility.Visible;
        }

        private void btnsetlocalwixsharp_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog browserdialog = new System.Windows.Forms.FolderBrowserDialog();
            browserdialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
            if (browserdialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lblwixsharplocation.Content = browserdialog.SelectedPath;
            }
        }

        private void btnsetlocalwix_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog browserdialog = new System.Windows.Forms.FolderBrowserDialog();
            browserdialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
            if (browserdialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lblwixlocation.Content = browserdialog.SelectedPath;
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            btnsetlocalwixsharp.IsEnabled = true;
        }

        private void RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            btnsetlocalwixsharp.IsEnabled = false;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            btnsetlocalwix.IsEnabled = true;
        }

        private void RadioButton_Unchecked_1(object sender, RoutedEventArgs e)
        {
            btnsetlocalwix.IsEnabled = false;
        }

        private void btnOptions_Click(object sender, RoutedEventArgs e)
        {
            GridCheck(CompileOptionsGrid);
        }

        private void btncompile_Click(object sender, RoutedEventArgs e)
        {
            win.CsScript = textEditor.Document.Text;
            win.changed = false;
            win.CompileScript();
        
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
            string location = args.Name.Substring(0, args.Name.IndexOf(","));
            if (File.Exists($@"{win.Workingdir}/{location}.exe"))
            {
                found = true;
                location = $@"{win.Workingdir}/{location}.exe";
            }
            else if (File.Exists($@"{win.Workingdir}/{location}.dll"))
            {
                found = true;
                location = $@"{win.Workingdir}/{location}.dll";
            }
            if (!found)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
                path += @"\Reference Assemblies\Microsoft\Framework\.NETFramework\";
                string[] directories = Directory.GetDirectories(path);
                foreach (var d in directories)
                {
                    string test = d + $@"\{location}.dll";
                    if (File.Exists(test))
                    {
                        found = true;
                        location = test;
                    }
                }
            }
            if (!found)
            {
                foreach (var f in wixsharp)
                    if (f.EndsWith("WixSharp.dll"))
                    {
                        location = f.Replace("WixSharp.dll", "") + location + ".dll";
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

        private void btnFileOpen_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Wixard Files(*.wxg)| *.wxg|All Files(*.*)|*.*";
            of.InitialDirectory = SetInitDirectory();
            if (of.ShowDialog() == true)
                win.Load(of.FileName);
            if (win.MinimumNet != string.Empty)
                cbnetframework.IsChecked = true;
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
            SetInitDirectory();
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Wixard Files(*.wxg)| *.wxg|All Files(*.*)|*.*";
            sf.InitialDirectory = SetInitDirectory();
            if (sf.ShowDialog() == true)
                win.Save(sf.FileName);                
         
        }
        private void btnFileSave_Click(object sender, RoutedEventArgs e)
        {
            if (win.Filename == string.Empty)
                btnFileSaveAs_Click(sender, e);
            else
                win.Save(win.Filename);
        }

        private void btnabout_Click(object sender, RoutedEventArgs e)
        {
            GridCheck(AboutGrid);
        }

        private void btnGithub_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/glcjr/Wixard");
        }

        private void btnDonate_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://paypal.me/GColeJr");
        }
    }
}
