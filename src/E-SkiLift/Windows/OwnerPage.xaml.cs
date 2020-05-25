using E_SkiLift.Windows.User_Controls;
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
    /// Interaction logic for OwnerPage.xaml
    /// </summary>
    public partial class OwnerPage : Page
    {
        private readonly MainWindow parentWindow;

        public OwnerPage(MainWindow parentWindow)
        {
            InitializeComponent();
            this.parentWindow = parentWindow;
        }
        private void liftScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            //Temporarly changed to null change to owner when you implement owner page
            this.contentControl.Content = new ModifyLiftScheduleUserControl(null);
        }

        private void tariffButton_Click(object sender, RoutedEventArgs e)
        {
            //Temporarly changed to null change to owner when you implement owner page
            this.contentControl.Content = new ModifyTariffUserControl(null);
        }

        private void printCompanySummaryButton_Click(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new CompanySummaryUserControl();
        }


        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            parentWindow.ShowLoginPage();
        }

    }
}