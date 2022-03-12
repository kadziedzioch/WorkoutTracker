using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WorkoutTrackerApp.Core;
using WorkoutTrackerApp.Database;

namespace WorkoutTrackerApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var database = new WorkoutTrackerDbContext();

            database.Database.EnsureCreated();

            DatabaseLocator.Database = database;
        }

    }
}
