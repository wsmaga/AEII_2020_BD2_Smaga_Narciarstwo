using E_SkiLift.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace E_SkiLift.Windows
{
    /// <summary>
    /// Interaction logic for SkierSummaryPage.xaml
    /// </summary>
    public partial class SkierSummaryPage : Page
    {
        private readonly MainWindow parentWindow;

        public SkierSummaryPage(MainWindow parentWindow)
        {
            InitializeComponent();

            this.parentWindow = parentWindow;
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            if (!this.NavigationService.CanGoBack) //this should be possible
            {
                MessageBox.Show("NavigationService could not go back in pages history!", "FATAL ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(1);
            }

            this.NavigationService.GoBack();
        }

        private void Lifts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SkierSummaryModel ssm;
            int ticketID = int.Parse(TicketID.Content.ToString());
            SkierSummaryModel.LiftID liftID = (SkierSummaryModel.LiftID)Lifts.SelectedItem;
            if (liftID.ID == "All")
                ssm = new SkierSummaryModel(ticketID);
            else
                ssm = new SkierSummaryModel(ticketID, int.Parse(liftID.ID));
            DataContext = ssm;
        }
    }
}
