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
        private MainWindow mainWindow;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory",
    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            mainWindow = new MainWindow();
            mainWindow.Show();
        }

      
    }
}
