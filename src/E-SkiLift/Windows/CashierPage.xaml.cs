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

        public CashierPage(MainWindow parentWindow)
        {
            InitializeComponent();
            this.parentWindow = parentWindow;
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            parentWindow.ShowLoginPage();
        }

        private void sellButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("NOT YET IMPLEMENTED\nNew ticket sold.");
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
            MessageBox.Show("NOT YET IMPLEMENTED\nTicket refunded.");
        }
    }
}
