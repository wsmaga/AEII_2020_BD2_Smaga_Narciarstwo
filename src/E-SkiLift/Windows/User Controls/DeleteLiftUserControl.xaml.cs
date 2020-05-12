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

namespace E_SkiLift.Windows.User_Controls
{
    /// <summary>
    /// Logika interakcji dla klasy DeleteLiftUserControl.xaml
    /// </summary>
    public partial class DeleteLiftUserControl : UserControl
    {
        public DeleteLiftUserControl()
        {
            InitializeComponent();
        }

        private void deleteLiftButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("NOT YET IMPLEMENTED\nLift deleted.");
        }
    }
}
