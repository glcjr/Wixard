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
    /// Interaction logic for ElementsPanel.xaml
    /// </summary>
    public partial class ElementsPanel : UserControl, WixardControl
    {
        public GUIInterface win { get; set; }
        public ElementsPanel()
        {
            InitializeComponent();
            win = (GUIInterface)DataContext;
        }
        private void ElemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            win.GetElem(ElemsList.SelectedIndex);
            btnupdateaddelem.Content = "Update";
        }

        private void btnupdateaddelem_Click(object sender, RoutedEventArgs e)
        {
            if ((win.ElementName == string.Empty) || (win.ElementXMLRoot == string.Empty))
                MessageBox.Show("Name and XMLRoot are required fields");
            else
            {
                try
                {
                    if (btnupdateaddelem.Content.Equals("Update"))
                        win.UpdateElem(ElemsList.SelectedIndex);
                    else
                        win.AddElem();
                    win.NewElem();
                    btnupdateaddelem.Content = "Add";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CustomElemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            win.GetCustomElement(CustomElemsList.SelectedIndex);
            btnAddCustomElem.Content = "Update";
        }

        private void btnAddElem_Click(object sender, RoutedEventArgs e)
        {
            win.NewElem();
            btnAddElem.Content = "Add";
            btnAddCustomElem.Content = "Add";
        }

        private void btnRmvElem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                win.RemoveElem(ElemsList.SelectedIndex);
            }
            catch
            {

            }
            win.NewElem();
            btnupdateaddelem.Content = "Add";
            btnAddCustomElem.Content = "Add";
        }

        private void btnRmvCustomElem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                win.RemoveCustomElement(CustomElemsList.SelectedIndex);
            }
            catch
            {

            }
            win.NewCustomElement();

            btnAddCustomElem.Content = "Add";
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            win.NewCustomElement();
            btnAddCustomElem.Content = "Add";
        }

        private void btnAddCustomElem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnAddCustomElem.Content.Equals("Update"))
                    win.UpdateCustomElement();
                else
                    win.AddCustomElement();
                win.NewCustomElement();
                btnAddCustomElem.Content = "Add";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
