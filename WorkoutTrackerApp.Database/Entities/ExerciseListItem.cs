using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutTrackerApp.Database.Entities
{
    public class ExerciseListItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}
