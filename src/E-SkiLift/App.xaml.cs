using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using E_SkiLift.Windows;

namespace E_SkiLift
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Class1 model = new Class1();
        private Red_Window redWnd;
        private Green_Window greenWnd;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            redWnd = new Red_Window();
            redWnd.Show();
        }

        public void Go_green()
        {
            greenWnd = new Green_Window();
            greenWnd.Show();
            redWnd.Close();
        }
    }
}
