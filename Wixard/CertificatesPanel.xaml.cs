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
    /// Interaction logic for CertificatesPanel.xaml
    /// </summary>
    public partial class CertificatesPanel : UserControl,WixardControl
    {
        public GUIInterface win { get; set; }
        public CertificatesPanel()
        {
            InitializeComponent();
            win = (GUIInterface)DataContext;
        }
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
        
    }
}
