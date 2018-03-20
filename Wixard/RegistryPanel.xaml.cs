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
    /// Interaction logic for RegistryPanel.xaml
    /// </summary>
    public partial class RegistryPanel : UserControl, WixardControl
    {
        public GUIInterface win { get; set; }
        public RegistryPanel()
        {
            InitializeComponent();
            win = (GUIInterface)DataContext;
            cbRegHive.ItemsSource = Enum.GetValues(typeof(WIXSharpHelper.RegistryHive));
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
    }
}
