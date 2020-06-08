using E_SkiLift.Models;
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
        private Admin LoggedAdmin { get; set; }

        public AdminPage(MainWindow parentWindow)
        {
            InitializeComponent();
            this.parentWindow = parentWindow;
        }

        public void SetUser(User loggedUser)
        {
            LoggedAdmin = new Admin()
            {
                ID = loggedUser.ID,
                Name = loggedUser.Name,
                UserType = loggedUser.UserType
            };
            LoggedAdminLabel.Content = LoggedAdmin.Name;
        }

        private void addUserButton_Click(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new AddUserUserControl(LoggedAdmin);
        }
        private void deleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new DeleteUserUserControl(LoggedAdmin);
        }

        private void addLiftButton_Click(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new AddLiftUserControl(LoggedAdmin);
        }

        private void liftScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new ModifyLiftScheduleUserControl(LoggedAdmin);
        }

        private void tariffButton_Click(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new ModifyTariffUserControl(LoggedAdmin);
        }

        private void deleteLiftButton_Click(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new DeleteLiftUserControl(LoggedAdmin);
        }

        private void openCloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new OpenCloseLiftUserControl(LoggedAdmin);
        }

        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {
            parentWindow.ShowLoginPage();
            LoggedAdmin = null;
        }
        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            String chmFilePath = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Resources\\skiLift.chm";
            System.Windows.Forms.Help.ShowHelp(null, chmFilePath, System.Windows.Forms.HelpNavigator.Topic, "adminPanel.html");
        }
    }
}
