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
    /// Interaction logic for EnvironmentVarsPanel.xaml
    /// </summary>
    public partial class EnvironmentVarsPanel : UserControl, WixardControl
    {
        public GUIInterface win { get; set; }
        public EnvironmentVarsPanel()
        {
            InitializeComponent();
            win = (GUIInterface)DataContext;
        }
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
    }
}
