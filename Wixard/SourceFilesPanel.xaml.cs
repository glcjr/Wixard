using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Wixard
{
    /// <summary>
    /// Interaction logic for SourceFilesPanel.xaml
    /// </summary>
    public partial class SourceFilesPanel : UserControl, WixardControl
    {
        public GUIInterface win { get; set; } //= new GUIInterface();
        public SourceFilesPanel()
        {
            InitializeComponent();
            win = (GUIInterface)this.DataContext;
        }
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
            //try
            //{
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
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

    }
}
