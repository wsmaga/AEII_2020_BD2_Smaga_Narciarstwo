using E_SkiLift.Models;
using E_SkiLift.Models.Interfaces;
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
using Xceed.Wpf.Toolkit;

namespace E_SkiLift.Windows.User_Controls
{
    /// <summary>
    /// Logika interakcji dla klasy ModifyLiftScheduleUserControl.xaml
    /// </summary>
    public partial class ModifyLiftScheduleUserControl : UserControl
    {
        private int SelectedLiftID;
        ScheduleContainer OldSchedule;
        private readonly IModifiesLiftData LoggedEditor;
        TimePicker[] BeginPickers, EndPickers;
        public ModifyLiftScheduleUserControl(IModifiesLiftData _loggedEditor)
        {
            InitializeComponent();
            LoggedEditor = _loggedEditor;
            this.startDate.SelectedDate = DateTime.Today;
            BeginPickers = new TimePicker[]
            {
                NewBeginHourMon,
                NewBeginHourTue,
                NewBeginHourWed,
                NewBeginHourThu,
                NewBeginHourFri,
                NewBeginHourSat,
                NewBeginHourSun
            };
            EndPickers = new TimePicker[]
            {
                NewEndHourMon,
                NewEndHourTue,
                NewEndHourWed,
                NewEndHourThu,
                NewEndHourFri,
                NewEndHourSat,
                NewEndHourSun
            };
        }

        private void modifyScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            if (TimePickersNotEmpty())
            {
                bool updated = false;
                bool result = true;
                for (byte i = 0; i < 7; i++)
                {
                    if (BeginPickers[i].Text != OldSchedule.BeginHours[i] || EndPickers[i].Text != OldSchedule.EndHours[i])
                    {
                        result = result && LoggedEditor.UpdateSkiLiftSchedule(SelectedLiftID, i, BeginPickers[i].Text, EndPickers[i].Text, DateTime.Today);
                        updated = true;
                    }
                }
                if (updated)
                {
                    if(result)
                        System.Windows.MessageBox.Show("Succesfully updated lift schedule.");
                    else
                        System.Windows.MessageBox.Show("Could not update lift schedule.");
                    InvalidateSelection();
                }
                else
                    System.Windows.MessageBox.Show("New lift schedule cannot be the same as the old one (nothing to update).");
            }
            else
                System.Windows.MessageBox.Show("Cannot update schedule with empty value.");
        }
        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            String chmFilePath = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Resources\\skiLift.chm";
            System.Windows.Forms.Help.ShowHelp(null, chmFilePath, System.Windows.Forms.HelpNavigator.Topic, "modifyLiftSchedule.html");
        }
        private void selectLiftSchedule_Click(object sender, RoutedEventArgs e)
        {
            Nullable<int> liftId = LiftIdPicker.Value;
            if (liftId.HasValue)
            {
                if (LoggedEditor.SkiLiftExists(liftId.Value))
                {
                    SelectedLiftID = liftId.Value;
                    OldSchedule = LoggedEditor.GetCurrentSkiLiftSchedule(liftId.Value);
                    if(OldSchedule!=null)
                    {
                        SelectedLiftLabel.Content = "Currently selected Lift ID: "+liftId;
                        for (int i = 0; i < 7; i++)
                        {
                            BeginPickers[i].Text = OldSchedule.BeginHours[i];
                            BeginPickers[i].IsEnabled = true;
                            EndPickers[i].Text = OldSchedule.EndHours[i];
                            EndPickers[i].IsEnabled = true;
                        }
                        modifyScheduleButton.IsEnabled = true;

                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Could not fetch selected lift schedule");
                        InvalidateSelection();
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Could not find Lift with ID " + liftId.Value + ".");
                    InvalidateSelection();
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Please select lift id.");
                InvalidateSelection();
            }
        }

        private void InvalidateSelection()
        {
            SelectedLiftLabel.Content = "Currently selected Lift ID: null";
            modifyScheduleButton.IsEnabled = false;
            for (int i = 0; i < 7; i++)
            {
                BeginPickers[i].Text = "";
                BeginPickers[i].IsEnabled = false;
                EndPickers[i].Text = "";
                EndPickers[i].IsEnabled = false;
            }
        }
        private bool TimePickersNotEmpty()
        {
            for(int i=0;i<7;i++)
            {
                if (BeginPickers[i].Text == "")
                    return false;
                if (EndPickers[i].Text == "")
                    return false;
            }
            return true;
        }
        private void SetTimePickers(ScheduleContainer schedule)
        {
            for(int i=0;i<7;i++)
            {
                BeginPickers[i].Text = schedule.BeginHours[i];
                BeginPickers[i].IsEnabled = true;
                EndPickers[i].Text = schedule.EndHours[i];
                EndPickers[i].IsEnabled = true;
            }
            /*NewBeginHourMon.Text = schedule.BeginHours[0];
            NewBeginHourTue.Text = schedule.BeginHours[1];
            NewBeginHourWed.Text = schedule.BeginHours[2];
            NewBeginHourThu.Text = schedule.BeginHours[3];
            NewBeginHourFri.Text = schedule.BeginHours[4];
            NewBeginHourSat.Text = schedule.BeginHours[5];
            NewBeginHourSun.Text = schedule.BeginHours[6];

            NewEndHourMon.Text = schedule.EndHours[0];
            NewEndHourTue.Text = schedule.EndHours[1];
            NewEndHourWed.Text = schedule.EndHours[2];
            NewEndHourThu.Text = schedule.EndHours[3];
            NewEndHourFri.Text = schedule.EndHours[4];
            NewEndHourSat.Text = schedule.EndHours[5];
            NewEndHourSun.Text = schedule.EndHours[6];*/
        }
    }
}
