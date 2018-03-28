using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for AppInfo.xaml
    /// </summary>
    public partial class AppInfo : UserControl, WixardControl
    {
        public GUIInterface win { get; set; }
        public AppInfo()
        {
            InitializeComponent();
            win = (GUIInterface) DataContext;
        }
        
        private void Btnchangeicon_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Image files (*.jpg, *.jpeg, *.gif, *.bmp, *.png) | *.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (of.ShowDialog() == true)
                win.Icon = of.FileName;
        }
        private void btnRemoveicon_Click(object sender, RoutedEventArgs e)
        {
            win.Icon = "";
        }

        private void btnGetVersion_Click(object sender, RoutedEventArgs e)
        {
            if (!(win.GetFileVersion()))
            {
                OpenFileDialog of = new OpenFileDialog();
                of.Filter = "Exe Files (*.exe, *.dll) |*.exe;*.dll|All Files (*.*)|*.*";
                if (of.ShowDialog() == true)
                {
                    var versionInfo = FileVersionInfo.GetVersionInfo(of.FileName);
                    win.AppVersion = versionInfo.ProductVersion;
                }
            }
        }
    }
}
