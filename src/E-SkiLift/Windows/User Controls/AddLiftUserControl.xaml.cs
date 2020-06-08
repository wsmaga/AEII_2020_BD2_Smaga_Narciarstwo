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
        private readonly Admin LoggedAdmin;
        public AddLiftUserControl(Admin _loggedAdmin)
        {
            InitializeComponent();
            this.TariffBeginDate.SelectedDate = DateTime.Today;
            //this.TariffEndDate.SelectedDate = DateTime.Today.AddDays(28);
            this.TariffPointCost.Value = 100;
            LoggedAdmin = _loggedAdmin;

            BeginHourMon.Text = "10:00";
            BeginHourTue.Text = "10:00";
            BeginHourWed.Text = "10:00";
            BeginHourThu.Text = "10:00";
            BeginHourFri.Text = "10:00";
            BeginHourSat.Text = "10:00";
            BeginHourSun.Text = "10:00";

            EndHourMon.Text = "19:00";
            EndHourTue.Text = "19:00";
            EndHourWed.Text = "19:00";
            EndHourThu.Text = "19:00";
            EndHourFri.Text = "19:00";
            EndHourSat.Text = "19:00";
            EndHourSun.Text = "19:00";

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
            System.DateTime TarBeginDate =  DateTime.Today;
            //System.DateTime TarEndDate = TariffEndDate.SelectedDate ?? DateTime.Today;
            int TarPointCost = TariffPointCost.Value ?? 1;
            bool res = LoggedAdmin.AddSkiLift(TarBeginDate, TarPointCost, SchBeginHours, SchEndHours, LiftStartsOpen.IsChecked ?? true);
            if (res)
                MessageBox.Show("Added new lift.");
            else
                MessageBox.Show("Could not add new lift.");


        }
        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            String chmFilePath = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Resources\\skiLift.chm";
            System.Windows.Forms.Help.ShowHelp(null, chmFilePath, System.Windows.Forms.HelpNavigator.Topic, "addNewLift.html");
        }
    }
}
