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
    /// Interaction logic for DeleteUserUserControl.xaml
    /// </summary>
    public partial class DeleteUserUserControl : UserControl
    {
        public DeleteUserUserControl()
        {
            InitializeComponent();
        }
        private void deleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            Nullable<int> userId=UserIdComp.Value;
            bool result=false;
            if (userId.HasValue)
                result = Admin.RemoveUser(userId.Value);
            if(result)
                MessageBox.Show("Successfuly deleted user.");
            else
            {
                string val = userId?.ToString() ?? "null";
                MessageBox.Show("Could not delete user with " + val + " id");
            }
                

        }
    }
}
