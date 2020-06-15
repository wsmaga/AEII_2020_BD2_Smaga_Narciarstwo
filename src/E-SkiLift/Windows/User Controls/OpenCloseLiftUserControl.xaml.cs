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
    /// Logika interakcji dla klasy OpenCloseLiftUserControl.xaml
    /// </summary>
    public partial class OpenCloseLiftUserControl : UserControl
    {
        private readonly Admin LoggedAdmin;
        private int SelectedLiftID = -1;
        public OpenCloseLiftUserControl(Admin _loggedAdmin)
        {
            LoggedAdmin = _loggedAdmin;
            InitializeComponent();
        }

        private void openLiftButton_Click(object sender, RoutedEventArgs e)
        {
            bool res = LoggedAdmin.OpenOrCloseSkiLift(SelectedLiftID, true);
            if (res)
                MessageBox.Show("Succesfuly opened lift.");
            else
                MessageBox.Show("Could not open lift.");
            InvalidateSelection();
        }

        private void closeLiftButton_Click(object sender, RoutedEventArgs e)
        {
            bool res = LoggedAdmin.OpenOrCloseSkiLift(SelectedLiftID, false);
            if (res)
                MessageBox.Show("Succesfuly closed lift.");
            else
                MessageBox.Show("Could not close lift.");
            InvalidateSelection();
        }

        private void selectLiftButton_Click(object sender, RoutedEventArgs e)
        {
            Nullable<int> liftId = LiftIdPicker.Value;
            if (liftId.HasValue)
            {
                if (LoggedAdmin.SkiLiftExists(liftId.Value))
                {
                    bool? isOpen = LoggedAdmin.LiftIsOpen(liftId.Value);
                    if (isOpen != null)
                    {
                        SelectedLiftID = liftId.Value;
                        openLiftButton.IsEnabled = !isOpen.Value;
                        closeLifteButton.IsEnabled = isOpen.Value;
                        SelectedLiftLabel.Content = "Currently selected Lift ID: "+liftId.Value+"("+(isOpen.Value?"Open)":"Close)");
                    }
                    else
                    {
                        MessageBox.Show("Could not fetch lift IsOpen property.");
                        InvalidateSelection();
                    }
                }
                else
                {
                    MessageBox.Show("Could not find Lift with ID " + liftId.Value + ".");
                    InvalidateSelection();
                }
            }
            else
            {
                MessageBox.Show("Please select lift id.");
                InvalidateSelection();
            }
        }
        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            String chmFilePath = AppDomain.CurrentDomain.BaseDirectory + "skiLift.chm";
            System.Windows.Forms.Help.ShowHelp(null, chmFilePath, System.Windows.Forms.HelpNavigator.Topic, "openCloseLift.html");
        }
        private void InvalidateSelection()
        {
            SelectedLiftID = -1;
            openLiftButton.IsEnabled = false;
            closeLifteButton.IsEnabled = false;
            SelectedLiftLabel.Content = "Currently selected Lift ID: null";
        }
    }
}
