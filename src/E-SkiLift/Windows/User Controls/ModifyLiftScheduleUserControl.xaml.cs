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
    /// Logika interakcji dla klasy ModifyLiftScheduleUserControl.xaml
    /// </summary>
    public partial class ModifyLiftScheduleUserControl : UserControl
    {
        public ModifyLiftScheduleUserControl()
        {
            InitializeComponent();
            this.startDate.SelectedDate = DateTime.Today;
        }

        private void modifyScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("NOT YET IMPLEMENTED\nSchedule modified.");
        }

        private void selectLiftSchedule_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
