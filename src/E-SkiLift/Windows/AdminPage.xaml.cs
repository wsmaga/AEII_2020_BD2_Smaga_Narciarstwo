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
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        private readonly MainWindow parentWindow;

        public AdminPage(MainWindow parentWindow)
        {
            InitializeComponent();
            this.parentWindow = parentWindow;
            this.contentControl.Content = new AddUserUserControl();
        }

        private void addUserButton_Click(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new AddUserUserControl();
        }

        private void addLiftButton_Click(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new AddLiftUserControl();
        }

        private void liftScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new ModifyLiftScheduleUserControl();
        }

        private void tariffButton_Click(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new ModifyTariffUserControl();
        }

        private void deleteLiftButton_Click(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new DeleteLiftUserControl();
        }

        private void openCloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new OpenCloseLiftUserControl();
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            parentWindow.ShowLoginPage();
        }
    }
}
