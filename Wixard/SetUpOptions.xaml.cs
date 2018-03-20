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
    /// Interaction logic for SetUpOptions.xaml
    /// </summary>
    public partial class SetUpOptions : UserControl, WixardControl
    {
        public GUIInterface win { get; set; }
        public SetUpOptions()
        {
            InitializeComponent();
            win = (GUIInterface)DataContext;
        }
        private void cbnetframework_Checked(object sender, RoutedEventArgs e)
        {
            if (cbnetframework.IsChecked.Value)
                NetFrameworkPanel.Visibility = Visibility.Visible;
            else
                NetFrameworkPanel.Visibility = Visibility.Hidden;
        }
    }
}
