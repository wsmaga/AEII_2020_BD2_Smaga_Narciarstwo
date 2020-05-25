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

namespace E_SkiLift.Windows
{
    /// <summary>
    /// Interaction logic for CashierPage.xaml
    /// </summary>
    

    public partial class CashierPage : Page
    {
        private readonly MainWindow parentWindow;

        private Cashier LoggedCashier { get; set; }

        public CashierPage(MainWindow parentWindow)
        {
            InitializeComponent();
            this.parentWindow = parentWindow;
            LoggedCashier = null;
        }

        public void SetUser(User loggedUser)
        {
            LoggedCashier = new Cashier
            {
                ID = loggedUser.ID,
                Login = loggedUser.Login,
                Name = loggedUser.Name,
                Password = loggedUser.Password,
                UserType = loggedUser.UserType
            };
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoggedCashier = null;
            parentWindow.ShowLoginPage();
        }

        private void sellButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Don't allow negative points in new point tickets

            switch (this.TypePicker.Text)
            {
                case "Point ticket":
                    if (PointsPicker.Value.HasValue)
                        if (LoggedCashier.SellPointTicket(PointsPicker.Value.Value))
                            MessageBox.Show("Point ticket sold.");
                        else
                            MessageBox.Show("Database error!", "DATABASE ERROR!",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                    break;

                case "Ski Pass":
                    if (TimePicker.Value.HasValue)
                        if(LoggedCashier.SellSkiPass(TimePicker.Value.Value))
                            MessageBox.Show("Ski Pass sold.");
                        else
                            MessageBox.Show("Database error!", "DATABASE ERROR!",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                    break;

                default:
                    break;
            }
        }

        private void summaryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                parentWindow.ShowSkierSummaryPage(int.Parse(ticketID.Text));
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid ticket ID!");
            }
        }

        private void lockButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("NOT YET IMPLEMENTED\nTicket locked.");
        }

        private void refundButton_Click(object sender, RoutedEventArgs e)
        {
            if(ticketID.Value.HasValue)
            {
                if (LoggedCashier.RefundTicket(ticketID.Value.Value))
                    MessageBox.Show("Ticket refunded.");
                else // TODO: Make something more user-friendly
                    MessageBox.Show("Database error!", "DATABASE ERROR!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (this.TypePicker.Text)
            {
                case "Point ticket":
                    this.TimeLabel.IsEnabled = true;
                    this.TimePicker.IsEnabled = true;
                    this.PointsLabel.IsEnabled = false;
                    this.PointsPicker.IsEnabled = false;
                    break;

                case "Ski Pass":
                    this.TimeLabel.IsEnabled = false;
                    this.TimePicker.IsEnabled = false;
                    this.PointsLabel.IsEnabled = true;
                    this.PointsPicker.IsEnabled = true;
                    break;

                default:
                    break;
            }
        }
    }
}
