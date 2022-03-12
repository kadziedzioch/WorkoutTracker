using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTrackerApp.Database;

namespace WorkoutTrackerApp.Core
{
    public class DatabaseLocator
    {
        public static WorkoutTrackerDbContext Database { get; set; }
    }
}
