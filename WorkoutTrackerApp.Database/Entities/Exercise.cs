using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutTrackerApp.Database.Entities
{
    public class Exercise
    {
        public int Id { get; set; }

        public string ExerciseName { get; set; }

        public decimal Weight { get; set; }

        public int Reps { get; set; }

        public int Sets { get; set; }

        public bool IsSelected { get; set; } 

        public int WorkoutId { get; set; }
    }
}
