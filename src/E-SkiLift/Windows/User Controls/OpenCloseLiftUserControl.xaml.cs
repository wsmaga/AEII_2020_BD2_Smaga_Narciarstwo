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
    /// Logika interakcji dla klasy OpenCloseLiftUserControl.xaml
    /// </summary>
    public partial class OpenCloseLiftUserControl : UserControl
    {
        public OpenCloseLiftUserControl()
        {
            InitializeComponent();
        }

        private void openLiftButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("NOT YET IMPLEMENTED\nLift has been opened.");
        }

        private void closeLiftButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("NOT YET IMPLEMENTED\nLift has been closed.");
        }
    }
}
