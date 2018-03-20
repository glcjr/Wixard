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
    /// Interaction logic for FileAssociationsPanel.xaml
    /// </summary>
    public partial class FileAssociationsPanel : UserControl, WixardControl
    {
        public GUIInterface win { get; set; }
        public FileAssociationsPanel()
        {
            InitializeComponent();
            win = (GUIInterface)DataContext;
        }
        private void FileAssocsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            win.GetFileAssociation(FileAssocsList.SelectedIndex);
            btnupdateaddFileAssoc.Content = "Update";
        }

        private void btnAddFileAssoc_Click(object sender, RoutedEventArgs e)
        {
            win.NewFileAssociation();
            btnupdateaddFileAssoc.Content = "Add";
        }

        private void btnRmvFileAssoc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                win.RemoveFileAssociation(FileAssocsList.SelectedIndex);
            }
            catch
            {

            }
            win.NewFileAssociation();

            btnupdateaddFileAssoc.Content = "Add";
        }

        private void btnupdateaddFileAssoc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnupdateaddFileAssoc.Content.Equals("Update"))
                    win.UpdateFileAssociation(FileAssocsList.SelectedIndex);
                else
                    win.AddFileAssociation();
                win.NewFileAssociation();
                btnupdateaddFileAssoc.Content = "Add";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
