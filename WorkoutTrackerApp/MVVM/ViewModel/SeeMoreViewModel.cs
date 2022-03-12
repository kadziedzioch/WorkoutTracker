using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WorkoutTrackerApp.Core;
using WorkoutTrackerApp.Database.Entities;
using WorkoutTrackerApp.Database.Repositories;

namespace WorkoutTrackerApp.MVVM.ViewModel
{
    class SeeMoreViewModel : ObservableObject
    {
        public WorkoutsRepository workoutsrepository = new WorkoutsRepository(DatabaseLocator.Database);
        public ExercisesRepository exercisessrepository = new ExercisesRepository(DatabaseLocator.Database);

        public ObservableCollection<Workout> WorkoutsList { get; set; }= new ObservableCollection<Workout>();

        public ObservableCollection<Exercise> ExercisesList { get; set; } = new ObservableCollection<Exercise>();

        public string NewDate { get; set; }

        public ICommand DeleteSelectedWorkoutsCommand { get; set; }

        public SeeMoreViewModel()
        {
            UpdateWorkouts();
            DeleteSelectedWorkoutsCommand = new RelayCommand(o => { DeleteSelectedWorkouts(); });
        }

        public void UpdateWorkouts()
        {
            WorkoutsList.Clear();
            var workouts = workoutsrepository.GetAllWorkouts();
            foreach (Workout w in workouts)
            {
                WorkoutsList.Add(w);
            }
            WorkoutsList = new ObservableCollection<Workout>(WorkoutsList.OrderByDescending(x => x.WorkoutDate));
            
        }

        public void DeleteSelectedWorkouts()
        {
            var selectedWorkouts = WorkoutsList.Where(x => x.IsSelected).ToList();
            
            if (MessageBox.Show("Are you sure you want to delete these workouts?","Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (selectedWorkouts != null)
                {
                    foreach (var workout in selectedWorkouts)
                    {
                        WorkoutsList.Remove(workout);
                        workoutsrepository.RemoveWorkout(workout);
                    }

                    UpdateWorkouts();

                }
            }
            
            
        }

    }
}
