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
    /// Interaction logic for CompanySummaryPage.xaml
    /// </summary>
    public partial class CompanySummaryPage : Page
    {
        private readonly MainWindow parentWindow;

        public CompanySummaryPage(MainWindow parentWindow)
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

    }
}
