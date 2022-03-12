using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WorkoutTrackerApp.Database.Entities;

namespace WorkoutTrackerApp.Database.Repositories
{
    public class ExercisesRepository : BaseRepository<Exercise>
    {
        public ExercisesRepository(WorkoutTrackerDbContext dbContext) : base(dbContext) { }

        protected override DbSet<Exercise> DbSet => mDbContext.Exercises;

        public List<Exercise> GetAllExercises()
        {
            var list = new List<Exercise>();
            var exercises = DbSet;

            foreach (var exercise in exercises)
            {
                list.Add(exercise);
            }
            return list;
        }

        public void UpdateExercise(Exercise exercise)
        {
            //var foundItem = DbSet.Where(x => x.Name == exercise.ExerciseName).FirstOrDefault();
            //????
            
            DbSet.Add(exercise);
            SaveChanges();
            
        }

        public void RemoveExercise(Exercise exercise)
        {
            DbSet.Remove(exercise);
            SaveChanges();

        }
    }
}
