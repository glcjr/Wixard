using System;
using System.Collections.Generic;
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

namespace Wixard
{
    /// <summary>
    /// Interaction logic for AboutPanel.xaml
    /// </summary>
    public partial class AboutPanel : UserControl
    {
        public GUIInterface win { get; set; }
        public AboutPanel()
        {
            InitializeComponent();
            win = (GUIInterface)this.DataContext;
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            lblVersion.Content = AssemblyName.GetAssemblyName(assembly.Location).Version.ToString();
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
