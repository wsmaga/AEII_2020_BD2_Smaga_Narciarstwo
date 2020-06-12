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

namespace E_SkiLift.Windows.User_Controls
{
    /// <summary>
    /// Logika interakcji dla klasy DeleteLiftUserControl.xaml
    /// </summary>
    public partial class DeleteLiftUserControl : UserControl
    {
        private readonly Admin LoggedAdmin;
        public DeleteLiftUserControl(Admin _loggedAdmin)
        {
            InitializeComponent();
            LoggedAdmin = _loggedAdmin;
            DeleteLiftModel dlm = new DeleteLiftModel();
            DataContext = dlm;
        }

        private void deleteLiftButton_Click(object sender, RoutedEventArgs e)
        {
            Nullable<int> liftId = LiftIdComp.Value;
            bool result = false;
            if (liftId.HasValue)
                result = LoggedAdmin.RemoveSkiLift(liftId.Value);
            if (result)
            {
                MessageBox.Show("Successfuly deleted lift.");
                DeleteLiftModel dlm = new DeleteLiftModel();
                DataContext = dlm;
            }
            else
            {
                string val = liftId?.ToString() ?? "null";
                MessageBox.Show("Could not delete lift with " + liftId ?? "null" + " id");
            }
                
        }
        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            String chmFilePath = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Resources\\skiLift.chm";
            System.Windows.Forms.Help.ShowHelp(null, chmFilePath, System.Windows.Forms.HelpNavigator.Topic, "deleteLift.html");
        }
    }
}
