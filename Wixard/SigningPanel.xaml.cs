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
    /// Interaction logic for SigningPanel.xaml
    /// </summary>
    public partial class SigningPanel : UserControl, WixardControl
    {
        public GUIInterface win { get; set; }
        public SigningPanel()
        {
            InitializeComponent();
            win = (GUIInterface)DataContext;
        }

        private void btnCertPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Certificate Files(*.pfx)|*.pfx|Certificate Files(*.crt)|*.crt|Certificate Files(*.cer)|*.cer|Certificate Files(*.p12)|*.p12";
            if (of.ShowDialog() == true)
            {
                win.CertificatePath = of.FileName;
            }
        }
    }
}
