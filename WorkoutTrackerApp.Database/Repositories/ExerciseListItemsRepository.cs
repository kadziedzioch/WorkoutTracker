using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkoutTrackerApp.Database.Entities;

namespace WorkoutTrackerApp.Database.Repositories
{
    public class ExerciseListItemsRepository : BaseRepository<ExerciseListItem>
    {
        protected override DbSet<ExerciseListItem> DbSet => mDbContext.ExerciseListItems;

        public ExerciseListItemsRepository(WorkoutTrackerDbContext dbContext) : base(dbContext) { }
 
        public List<ExerciseListItem> GetAllExerciseListItems()
        {
            var list = new List<ExerciseListItem>();
            var exerciseListItems = DbSet;

            foreach(var exerciseListItem in exerciseListItems)
            {
                list.Add(exerciseListItem);
            }
            if(list.Count == 0)
            {
                DbSet.Add(new ExerciseListItem { Id = 1, Name = "Squats" });
                DbSet.Add(new ExerciseListItem { Id = 2, Name = "Leg Press" });
                DbSet.Add(new ExerciseListItem { Id = 3, Name = "Romanian Deadlift" });
                DbSet.Add(new ExerciseListItem { Id = 4, Name = "Hack Squat" });
                DbSet.Add(new ExerciseListItem { Id = 5, Name = "Lunges" });
                DbSet.Add(new ExerciseListItem { Id = 6, Name = "Leg Curl" });
                DbSet.Add(new ExerciseListItem { Id = 7, Name = "Leg Extension" });
                DbSet.Add(new ExerciseListItem { Id = 8, Name = "Seated Calf" });
                DbSet.Add(new ExerciseListItem { Id = 9, Name = "Standing Calf" });
                DbSet.Add(new ExerciseListItem { Id = 10, Name = "Leg Press Calf" });

                DbSet.Add(new ExerciseListItem { Id = 11, Name = "Barbell Bench Press" });
                DbSet.Add(new ExerciseListItem { Id = 12, Name = "Dumbell Bench Press" });
                DbSet.Add(new ExerciseListItem { Id = 13, Name = "Dumbell Fly" });
                DbSet.Add(new ExerciseListItem { Id = 14, Name = "Cable Fly" });
                DbSet.Add(new ExerciseListItem { Id = 15, Name = "Dips" });


                DbSet.Add(new ExerciseListItem { Id = 16, Name = "Barbell Curl" });
                DbSet.Add(new ExerciseListItem { Id = 17, Name = "Dumbell Curl" });
                DbSet.Add(new ExerciseListItem { Id = 18, Name = "Hammer Curl" });
                DbSet.Add(new ExerciseListItem { Id = 19, Name = "Preacher Curl" });

                DbSet.Add(new ExerciseListItem { Id = 20, Name = "Tricep Pushdown" });
                DbSet.Add(new ExerciseListItem { Id = 21, Name = "Tricep Pulldown" });
                DbSet.Add(new ExerciseListItem { Id = 22, Name = "Overhead Tricep" });
                DbSet.Add(new ExerciseListItem { Id = 23, Name = "Close Grip Bench" });
                DbSet.Add(new ExerciseListItem { Id = 24, Name = "Tricep Extension" });


                DbSet.Add(new ExerciseListItem { Id = 25, Name = "Deadlifts" });
                DbSet.Add(new ExerciseListItem { Id = 26, Name = "PullUps/Chinups" });
                DbSet.Add(new ExerciseListItem { Id = 27, Name = "Pulldowns" });
                DbSet.Add(new ExerciseListItem { Id = 28, Name = "Seated Row" });
                DbSet.Add(new ExerciseListItem { Id = 29, Name = "Bent Barbell Row" });

                DbSet.Add(new ExerciseListItem { Id = 30, Name = "Barbell Military Press" });
                DbSet.Add(new ExerciseListItem { Id = 31, Name = "Dumbell Military Press" });
                DbSet.Add(new ExerciseListItem { Id = 32, Name = "Bent Over Lateral Raise" });
                DbSet.Add(new ExerciseListItem { Id = 33, Name = "Side Lateral Raise" });
                DbSet.Add(new ExerciseListItem { Id = 34, Name = "Front Raise" });

                SaveChanges();

                foreach (var exerciseListItem in exerciseListItems)
                {
                    list.Add(exerciseListItem);
                }

            }
            return list;
        }

        public void UpdateExerciseListItem(ExerciseListItem exerciseListItem)
        {
            var foundItem = DbSet.Where(x => x.Name == exerciseListItem.Name).FirstOrDefault();
            
            if (foundItem == null)
            {
                DbSet.Add(exerciseListItem);
                SaveChanges();
                return;

            }
            foundItem.Name = exerciseListItem.Name;
            foundItem.Id = exerciseListItem.Id;

            SaveChanges();

        }
        public void RemoveExerciseListItem(ExerciseListItem exerciseListItem)
        {
            var founditem = DbSet.Where(x => x.Id == exerciseListItem.Id).FirstOrDefault();
            DbSet.Remove(founditem);
            SaveChanges();
        }


    }
}
