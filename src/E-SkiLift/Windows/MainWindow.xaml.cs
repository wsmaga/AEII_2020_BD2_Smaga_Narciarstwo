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
        public SkierSummaryPage skierSummaryPage;

        public SkierSummaryModel skierSummaryModel;

        
        
        public MainWindow()
        {
            InitializeComponent();

            loginPage = new LoginPage(this);
            adminPage = new AdminPage(this);
            cashierPage = new CashierPage(this);
            ownerPage = new OwnerPage(this);
            gatePage = new GatePage(this);
            skierSummaryPage = new SkierSummaryPage(this);

            ShowLoginPage();
        }

        public void ShowLoginPage()
        {
            loginPage.ClearBeforeShow();
            currentPage.Content = loginPage;
        }

        public void ShowAdminPage(User loggedUser)
        {
            adminPage.SetUser(loggedUser);
            currentPage.Content = adminPage;
        }

        public void ShowCashierPage(User loggedUser)
        {
            cashierPage.SetUser(loggedUser);
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

        public void ShowSkierSummaryPage(int ticketID)
        {
            skierSummaryModel = new SkierSummaryModel(ticketID);
            skierSummaryPage.DataContext = skierSummaryModel; //Model becomes a data context for a page - it's data can now be binded to the view controls.
            currentPage.Content = skierSummaryPage;
        }
        

    }
}
