using System;
using System.Collections.Generic;
using System.Text;

namespace WorkoutTrackerApp.Database.Entities
{
    public class Workout
    {
        public int WorkoutId { get; set; }

        public List<Exercise> ExerciseList { get; set; }

        public DateTime WorkoutDate { get; set; }

        public decimal Duration { get; set; }

        public bool IsSelected { get; set; }
    }
}
