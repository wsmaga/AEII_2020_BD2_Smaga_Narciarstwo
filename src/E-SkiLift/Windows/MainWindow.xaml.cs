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
using System.Windows.Shapes;

namespace E_SkiLift.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public LoginPage loginPage;
        public AdminPage adminPage;
        public CashierPage cashierPage;
        public OwnerPage ownerPage;
        public GatePage gatePage;
        
        public MainWindow()
        {
            InitializeComponent();

            loginPage = new LoginPage(this);
            adminPage = new AdminPage(this);
            cashierPage = new CashierPage(this);
            ownerPage = new OwnerPage(this);
            gatePage = new GatePage(this);

            ShowLoginPage();
        }

        public void ShowLoginPage()
        {
            currentPage.Content = loginPage;
        }

        public void ShowAdminPage()
        {
            currentPage.Content = adminPage;
        }

        public void ShowCashierPage()
        {
            currentPage.Content = cashierPage;
        }

        public void ShowOwnerPage()
        {
            currentPage.Content = ownerPage;
        }

        public void ShowGatePage()
        {
            currentPage.Content = gatePage;
        }
    }
}
