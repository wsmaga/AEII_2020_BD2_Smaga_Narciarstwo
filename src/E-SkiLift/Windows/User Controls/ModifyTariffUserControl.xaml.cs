using E_SkiLift.Models;
using E_SkiLift.Models.Interfaces;
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
    /// Logika interakcji dla klasy ModifyTariffUserControl.xaml
    /// </summary>
    public partial class ModifyTariffUserControl : UserControl
    {
        private readonly IModifiesTariff LoggedAdmin;
        private int SelectedLiftID=-1;
        private int OldPointCost=0;
        public ModifyTariffUserControl(IModifiesTariff _loggedAdmin)
        {
            InitializeComponent();
            LoggedAdmin = _loggedAdmin;
            this.TariffBeginDate.SelectedDate = DateTime.Today;
        }

        private void modifyTariffButton_Click(object sender, RoutedEventArgs e)
        {
            Nullable<int> newPointCost = PointCostPicker.Value;
            if (newPointCost.HasValue)
            {
                if (newPointCost.Value != OldPointCost)
                {
                    bool result=LoggedAdmin.UpdateLiftTariff(SelectedLiftID, newPointCost.Value, DateTime.Today);
                    if (result)
                        MessageBox.Show("Successfuly updated lift tariff.");
                    else
                        MessageBox.Show("Could not update lift tariff.");
                    InvalidateSelection();

                }
                else
                    MessageBox.Show("New point cost cannot be the same as the old point cost (nothing to update).");
            }
            else
                MessageBox.Show("Please select a value.");
        }

        private void selectLiftButton_Click(object sender, RoutedEventArgs e)
        {
            Nullable<int> liftId = LiftIdPicker.Value;
            if (liftId.HasValue)
            {
                if (LoggedAdmin.SkiLiftExists(liftId.Value))
                {
                    SelectedLiftID = liftId.Value;
                    int cost=LoggedAdmin.GetCurrentLiftPointCost(liftId.Value);
                    if(cost>0)
                    {
                        SelectedLiftLabel.Content = "Currently selected Lift ID: " + SelectedLiftID;
                        modifyTariffButton.IsEnabled = true;
                        PointCostPicker.IsEnabled = true;
                        OldPointCost = cost;
                        PointCostPicker.Value = cost;
                    }
                    else
                    {
                        MessageBox.Show("Could not fetch selected lift tariff data ("+liftId.Value+").");
                    }
                }
                else
                {
                    MessageBox.Show("Could not find Lift with ID " + liftId.Value+".");
                    InvalidateSelection();
                }
            }
            else
            {
                MessageBox.Show("Please select lift id.");
                InvalidateSelection();
            }
        }
        private void InvalidateSelection()
        {
            SelectedLiftID = -1;
            OldPointCost = 0;
            SelectedLiftLabel.Content = "Currently selected Lift ID: null";
            modifyTariffButton.IsEnabled = false;
            PointCostPicker.IsEnabled = false;
            PointCostPicker.Value = null;
        }
    }
}
