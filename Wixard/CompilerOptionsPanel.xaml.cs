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
    /// Interaction logic for CompilerOptionsPanel.xaml
    /// </summary>
    public partial class CompilerOptionsPanel : UserControl, WixardControl
    {
        public GUIInterface win { get; set; }
        public CompilerOptionsPanel()
        {
            InitializeComponent();
            win = (GUIInterface)DataContext;
        }
        private void btnsetlocalwixsharp_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog browserdialog = new System.Windows.Forms.FolderBrowserDialog();
            browserdialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
            if (browserdialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lblwixsharplocation.Content = browserdialog.SelectedPath;
                win.ClearWixSharp();
            }
        }

        private void btnsetlocalwix_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog browserdialog = new System.Windows.Forms.FolderBrowserDialog();
            browserdialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
            if (browserdialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lblwixlocation.Content = browserdialog.SelectedPath;
                win.ClearWix();
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

    }
}
