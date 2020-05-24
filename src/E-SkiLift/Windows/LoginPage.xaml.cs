using E_SkiLift.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private readonly MainWindow parentWindow;
        
        public LoginPage(MainWindow parentWindow)
        {
            InitializeComponent();
            this.parentWindow = parentWindow;
        }

        //Login button click handler.
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            //Real authorization with real users from database.
            User loggedUser = User.SignIn(login.Text, password.Password);
            if (loggedUser != null)
            {
                switch((UserType)loggedUser.UserType)
                {
                    case UserType.Admin:
                        parentWindow.ShowAdminPage();
                        break;
                    case UserType.Owner:
                        parentWindow.ShowOwnerPage();
                        break;
                    case UserType.Cashier:
                        parentWindow.ShowCashierPage();
                        break;
                }
            }
            else
                errorTextField.Content = "Wrong password my nigga"; 
           /* if (this.password.Password.Equals("root")) //in the future we can use SecureString while handling passwords
                switch (this.login.Text)
                {
                    case "cashier":
                        parentWindow.ShowCashierPage();
                        break;

                    case "owner":
                        parentWindow.ShowOwnerPage();
                        break;

                    case "admin":
                        parentWindow.ShowAdminPage();
                        break;

                    default:
                        errorTextField.Content = "(MOCKUP MODE)Invalid username!";
                        break;
                }
            else
                errorTextField.Content = "(MOCKUP MODE)Debug password is \"root\"!";*/
        }

        private void gateButton_Click(object sender, RoutedEventArgs e)
        {
            parentWindow.ShowGatePage();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                loginButton_Click(sender, e);
            }
        }

        /// <summary>
        /// Resets labels and text boxes so that they don't show strings from previous usage.
        /// </summary>
        public void ClearBeforeShow()
        {
            errorTextField.Content = "";
            login.Clear();
            password.Clear();
        }
    }
}
