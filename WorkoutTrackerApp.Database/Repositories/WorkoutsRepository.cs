using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkoutTrackerApp.Database.Entities;

namespace WorkoutTrackerApp.Database.Repositories
{
    public class WorkoutsRepository : BaseRepository<Workout>
    {
        public WorkoutsRepository(WorkoutTrackerDbContext dbContext) : base(dbContext) { }

        protected override DbSet<Workout> DbSet => mDbContext.Workouts;

        public List<Workout> GetAllWorkouts()
        {
            var list = new List<Workout>();
            var workouts = DbSet;

            foreach (var workout in workouts)
            {
                list.Add(workout);
            }
            return list;
        }

        public void UpdateWorkout(Workout workout)
        {
            //var foundItem = DbSet.Where(x => x. == exercise.ExerciseName).FirstOrDefault();
            
            DbSet.Add(workout);
            SaveChanges();
        }

        public void RemoveWorkout(Workout workout)
        {
            var founditem = DbSet.Where(x => x.WorkoutId == workout.WorkoutId).FirstOrDefault();
            DbSet.Remove(founditem);
            SaveChanges();
        }
    }
}
