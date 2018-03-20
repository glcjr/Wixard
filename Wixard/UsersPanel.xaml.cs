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
    /// Interaction logic for UsersPanel.xaml
    /// </summary>
    public partial class UsersPanel : UserControl, WixardControl
    {
        public GUIInterface win { get; set; }
        public UsersPanel()
        {
            InitializeComponent();
            win = (GUIInterface)DataContext;
        }
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            win.NewUser();
            btnupdateadduser.Content = "Add";
        }

        private void btnRmvUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                win.RemoveUser(UsersList.SelectedIndex);

            }
            catch
            {

            }
            win.NewUser();
            btnupdateadduser.Content = "Add";
        }

        private void UsersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            win.GetUser(UsersList.SelectedIndex);
            btnupdateadduser.Content = "Update";
        }

        private void btnupdateadduser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (btnupdateadduser.Content.Equals("Update"))
                {
                    win.UpdateUser(UsersList.SelectedIndex);
                }
                else
                    win.AddUser();
                win.NewUser();
                btnupdateadduser.Content = "Add";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
