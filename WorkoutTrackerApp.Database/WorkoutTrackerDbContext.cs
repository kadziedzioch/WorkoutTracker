using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WorkoutTrackerApp.Database.Entities;

namespace WorkoutTrackerApp.Database
{
   public class WorkoutTrackerDbContext : DbContext
    {
        public DbSet<ExerciseListItem> ExerciseListItems { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Workout> Workouts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlite($"Filename={Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "workoutTracker.sqlite")}");
        }
    }
}
