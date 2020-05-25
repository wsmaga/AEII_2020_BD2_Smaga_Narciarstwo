using E_SkiLift.Models;
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
    /// Logika interakcji dla klasy AddLiftUserControl.xaml
    /// </summary>
    public partial class AddLiftUserControl : UserControl
    {
        public AddLiftUserControl()
        {
            InitializeComponent();
            this.TariffBeginDate.SelectedDate = DateTime.Today;
            this.TariffEndDate.SelectedDate = DateTime.Today.AddDays(28);
            this.TariffPointCost.Value = 100;
        }

        private void addLiftButton_Click(object sender, RoutedEventArgs e)
        {
            string[] SchBeginHours = new string[]{
                BeginHourMon.Text,
                BeginHourTue.Text,
                BeginHourWed.Text,
                BeginHourThu.Text,
                BeginHourFri.Text,
                BeginHourSat.Text,
                BeginHourSun.Text };
            string[] SchEndHours = new string[]{
                EndHourMon.Text,
                EndHourTue.Text,
                EndHourWed.Text,
                EndHourThu.Text,
                EndHourFri.Text,
                EndHourSat.Text,
                EndHourSun.Text };
            System.DateTime TarBeginDate = TariffBeginDate.SelectedDate ?? DateTime.Today;
            System.DateTime TarEndDate = TariffEndDate.SelectedDate ?? DateTime.Today;
            int TarPointCost = TariffPointCost.Value ?? 1;
            if(Admin.AddSkiLift(TarBeginDate,TarEndDate,TarPointCost,SchBeginHours,SchEndHours,LiftStartsOpen.IsChecked??true))
                MessageBox.Show("Added new lift.");
            else
                MessageBox.Show("Could not add new lift.");


        }
    }
}
