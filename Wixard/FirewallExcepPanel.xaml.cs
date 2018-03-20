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
    /// Interaction logic for FirewallExcepPanel.xaml
    /// </summary>
    public partial class FirewallExcepPanel : UserControl, WixardControl
    {
        public GUIInterface win { get; set; }
        public FirewallExcepPanel()
        {
            InitializeComponent();
            win = (GUIInterface)DataContext;
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
    }
}
