using E_SkiLift.Models;
//using OxyPlot;
//using OxyPlot.Series;
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
    /// Interaction logic for CompanySummaryUserControl.xaml
    /// </summary>
    public partial class CompanySummaryUserControl : UserControl
    {

        private Owner LoggedOwner;

        
        public CompanySummaryUserControl(Owner _loggedOwner)
        {
            InitializeComponent();
            LoggedOwner = _loggedOwner;
        }

        private void showSummary_Click(object sender, RoutedEventArgs e)
        {
            DateTime? from = From.SelectedDate;
            DateTime? to = To.SelectedDate;
            LoggedOwner.ShowTotalSales((DateTime)from, (DateTime)to);
            LoggedOwner.ShowTotalTicketsSold((DateTime)from, (DateTime)to);
            LoggedOwner.ShowLiftUsage((DateTime)from, (DateTime)to);
            DataContext = null;
            DataContext = LoggedOwner;
        }

       

    }
}
