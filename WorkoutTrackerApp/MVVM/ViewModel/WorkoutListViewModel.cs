using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTrackerApp.Core;
using WorkoutTrackerApp.Database.Entities;
using WorkoutTrackerApp.Database.Repositories;
using WorkoutTrackerApp.MVVM.Model;

namespace WorkoutTrackerApp.MVVM.ViewModel
{
    class WorkoutListViewModel : ObservableObject
    {
        public WorkoutsRepository workoutsrepository = new WorkoutsRepository(DatabaseLocator.Database);
        public ExercisesRepository exercisessrepository = new ExercisesRepository(DatabaseLocator.Database);

        public ObservableCollection<Workout> WorkoutsList { get; set; } = new ObservableCollection<Workout>();

        public ObservableCollection<Exercise> ExercisesList { get; set; }

        public List<Item> Items { get; set; }
        public List<SecondItem> SecondItems { get; set; }
        public string NewDate {get; set;}

        public DateTime TodayDate { get; set; } = DateTime.Now;

        public int totalWorkoutCount { get; set; }
        public decimal workoutDuration { get; set; }
        public decimal totalDurationWorkouts { get; set; }
        public WorkoutListViewModel()
        {   
            UpdateLatestWorkout();
            UpdateStatistics();

            //var workouts = workoutsrepository.GetAllWorkouts().Where(x => x.WorkoutDate.ToString("dd/MM/yy") == TodayDate.ToString("dd/MM/yy")).Count();
            
        }

        public void UpdateLatestWorkout()
        {
            var workouts = workoutsrepository.GetAllWorkouts();
            var workout = workouts.OrderByDescending(x => x.WorkoutDate).FirstOrDefault();
            ExercisesList  = new ObservableCollection<Exercise>();
            if (workout != null)
            {
                NewDate = workout.WorkoutDate.ToString("dd/MM/yyyy");
                
                foreach (Exercise exercise in exercisessrepository.GetAllExercises().Where(x=>x.WorkoutId == workout.WorkoutId))
                {
                    ExercisesList.Add(exercise);
                }
            }
            
        }

        public void UpdateStatistics()
        {
            var workouts = workoutsrepository.GetAllWorkouts();
            totalWorkoutCount = workouts.Count();
            workoutDuration = workouts.Where(x => x.WorkoutDate >= TodayDate.AddDays(-7) && x.WorkoutDate <= TodayDate.AddMinutes(1)).Select(x => x.Duration).Sum();
            totalDurationWorkouts = workouts.Select(x => x.Duration).Sum();

            Items = new List<Item>()
            {
                new Item
                {
                    Date = TodayDate.AddDays(-6).ToString("dd/MM"),
                    Value = workoutsrepository.GetAllWorkouts().Where(x => x.WorkoutDate.ToString("dd/MM/yy") == TodayDate.AddDays(-6).ToString("dd/MM/yy")).Count()
                },
                new Item
                {
                    Date = TodayDate.AddDays(-5).ToString("dd/MM"),
                    Value = workoutsrepository.GetAllWorkouts().Where(x => x.WorkoutDate.ToString("dd/MM/yy") == TodayDate.AddDays(-5).ToString("dd/MM/yy")).Count()
                },
                new Item
                {
                    Date = TodayDate.AddDays(-4).ToString("dd/MM"),
                    Value = workoutsrepository.GetAllWorkouts().Where(x => x.WorkoutDate.ToString("dd/MM/yy") == TodayDate.AddDays(-4).ToString("dd/MM/yy")).Count()
                },
                new Item
                {
                    Date = TodayDate.AddDays(-3).ToString("dd/MM"),
                    Value = workoutsrepository.GetAllWorkouts().Where(x => x.WorkoutDate.ToString("dd/MM/yy") == TodayDate.AddDays(-3).ToString("dd/MM/yy")).Count()
                },
                new Item
                {
                    Date = TodayDate.AddDays(-2).ToString("dd/MM"),
                    Value = workoutsrepository.GetAllWorkouts().Where(x => x.WorkoutDate.ToString("dd/MM/yy") == TodayDate.AddDays(-2).ToString("dd/MM/yy")).Count()
                },
                new Item
                {
                    Date = TodayDate.AddDays(-1).ToString("dd/MM"),
                    Value =  workoutsrepository.GetAllWorkouts().Where(x => x.WorkoutDate.ToString("dd/MM/yy") == TodayDate.AddDays(-1).ToString("dd/MM/yy")).Count()
                },
                new Item
                {
                    Date = TodayDate.ToString("dd/MM"),
                    Value = workoutsrepository.GetAllWorkouts().Where(x => x.WorkoutDate.ToString("dd/MM/yy") == TodayDate.ToString("dd/MM/yy")).Count()
                }
            };

            SecondItems = new List<SecondItem>()
            {
                new SecondItem
                {
                     Date = TodayDate.AddDays(-6).ToString("dd/MM"),
                     Value = workoutsrepository.GetAllWorkouts().Where(x => x.WorkoutDate.ToString("dd/MM/yy") == TodayDate.AddDays(-6).ToString("dd/MM/yy")).Select(x=>x.Duration).Sum()
                },
                new SecondItem
                {
                    Date = TodayDate.AddDays(-5).ToString("dd/MM"),
                    Value = workoutsrepository.GetAllWorkouts().Where(x => x.WorkoutDate.ToString("dd/MM/yy") == TodayDate.AddDays(-5).ToString("dd/MM/yy")).Select(x=>x.Duration).Sum()
                },
                new SecondItem
                {
                    Date = TodayDate.AddDays(-4).ToString("dd/MM"),
                    Value = workoutsrepository.GetAllWorkouts().Where(x => x.WorkoutDate.ToString("dd/MM/yy") == TodayDate.AddDays(-4).ToString("dd/MM/yy")).Select(x=>x.Duration).Sum()
                },
                new SecondItem
                {
                    Date = TodayDate.AddDays(-3).ToString("dd/MM"),
                    Value = workoutsrepository.GetAllWorkouts().Where(x => x.WorkoutDate.ToString("dd/MM/yy") == TodayDate.AddDays(-3).ToString("dd/MM/yy")).Select(x=>x.Duration).Sum()
                },
                new SecondItem
                {
                    Date = TodayDate.AddDays(-2).ToString("dd/MM"),
                    Value = workoutsrepository.GetAllWorkouts().Where(x => x.WorkoutDate.ToString("dd/MM/yy") == TodayDate.AddDays(-2).ToString("dd/MM/yy")).Select(x=>x.Duration).Sum()
                },
                new SecondItem
                {
                    Date = TodayDate.AddDays(-1).ToString("dd/MM"),
                    Value =  workoutsrepository.GetAllWorkouts().Where(x => x.WorkoutDate.ToString("dd/MM/yy") == TodayDate.AddDays(-1).ToString("dd/MM/yy")).Select(x=>x.Duration).Sum()
                },
                new SecondItem
                {
                    Date = TodayDate.ToString("dd/MM"),
                    Value = workoutsrepository.GetAllWorkouts().Where(x => x.WorkoutDate.ToString("dd/MM/yy") == TodayDate.ToString("dd/MM/yy")).Select(x=>x.Duration).Sum()
                }

            };
        }

        

    }
}
