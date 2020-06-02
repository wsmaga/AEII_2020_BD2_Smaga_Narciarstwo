using E_SkiLift.Models;
using OxyPlot;
using OxyPlot.Series;
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

        public string Title { get; private set; }
        public IList<DataPoint> Points { get; private set; }
        public CompanySummaryUserControl(Owner _loggedOwner)
        {
            InitializeComponent();
            LoggedOwner = _loggedOwner;

            this.MyModel = new PlotModel { Title = "Example 1" };
            this.MyModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));

        }
        public PlotModel MyModel { get; private set; }

        private void showSummary_Click(object sender, RoutedEventArgs e)
        {
            DateTime? from = From.SelectedDate;
            DateTime? to = To.SelectedDate;


        }

        private void showLiftUsage_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
