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
    /// Logika interakcji dla klasy AddUserUserControl.xaml
    /// </summary>
    public partial class AddUserUserControl : UserControl
    {
        private readonly Admin LoggedAdmin;
        public AddUserUserControl(Admin _loggedAdmin)
        {
            InitializeComponent();
            LoggedAdmin = _loggedAdmin;
        }

        private void addUserButton_Click(object sender, RoutedEventArgs e)
        {
            bool res=LoggedAdmin.AddUser((UserType) int.Parse(AddUserType.Text), AddUserName.Text, AddUserLogin.Text, AddUserPassword.Text);
            if (res)
                MessageBox.Show("Succesfuly added new user.");
            else
                MessageBox.Show("Could not add new user.");
            RemoveTextBoxContent();
        }
        private void RemoveTextBoxContent()
        {
            AddUserName.Text = "";
            AddUserLogin.Text = "";
            AddUserPassword.Text = "";
            AddUserType.Text = "";
        }
        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            String chmFilePath = AppDomain.CurrentDomain.BaseDirectory + "skiLift.chm";
            System.Windows.Forms.Help.ShowHelp(null, chmFilePath, System.Windows.Forms.HelpNavigator.Topic, "addUser.html");
        }
    }
}
