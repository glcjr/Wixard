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
    /// Interaction logic for FeaturesPanel.xaml
    /// </summary>
    public partial class FeaturesPanel : UserControl, WixardControl
    {
        public GUIInterface win { get; set; }
        public FeaturesPanel()
        {
            InitializeComponent();
            win = (GUIInterface)DataContext;
        }
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
    }
}
