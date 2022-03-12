using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WorkoutTrackerApp.Core;
using WorkoutTrackerApp.Database.Entities;
using WorkoutTrackerApp.Database.Repositories;

namespace WorkoutTrackerApp.MVVM.ViewModel
{
    class AddNewWorkoutViewModel : ObservableObject
    {
        public ObservableCollection<Exercise> exerciseList { get; set; } = new ObservableCollection<Exercise>();
        public ObservableCollection<string> existingExerciseList { get; set; } = new ObservableCollection<string>();

        public WorkoutsRepository workoutRepository = new WorkoutsRepository(DatabaseLocator.Database);

        public ExercisesRepository exerciseRepository = new ExercisesRepository(DatabaseLocator.Database);

        public ExerciseListItemsRepository exerciseListItemsRepository = new ExerciseListItemsRepository(DatabaseLocator.Database);

        public string NewExerciseName { get; set; }

        public decimal NewWeight { get; set; }

        public int NewReps { get; set; }

        public int NewSets { get; set; }

        public decimal NewDuration { get; set; }

        public DateTime NewDate { get; set; } = DateTime.Now;

        private WorkoutListViewModel workoutListVM;
        public WorkoutListViewModel WorkoutListVM
        {
            get
            {
                return workoutListVM;
            }
            set
            {
                workoutListVM = value;
            }
        }

        

        public ICommand AddNewExerciseCommand { get; set; }
        public ICommand DeleteSelectedExercisesCommand { get; set; }
        public ICommand SaveWorkoutCommand { get; set; }

        public AddNewWorkoutViewModel()
        {
            Update();
            AddNewExerciseCommand = new RelayCommand(o => {AddNewExercise(); });
            DeleteSelectedExercisesCommand = new RelayCommand(o => {DeleteSelectedExercises(); });
            SaveWorkoutCommand = new RelayCommand(o => { SaveWorkout(); });

        }


        private void AddNewExercise()
        {

            var newExercise = new Exercise
            {

                ExerciseName = NewExerciseName,
                Weight = NewWeight,
                Reps = NewReps,
                Sets = NewSets


            };

            exerciseList.Add(newExercise);

            NewExerciseName = newExercise.ExerciseName;
            NewWeight = 0;
            NewReps = 0;
            NewSets = 0;

            OnPropertyChanged(nameof(NewExerciseName));
            OnPropertyChanged(nameof(NewWeight));
            OnPropertyChanged(nameof(NewReps));
            OnPropertyChanged(nameof(NewSets));

        }
        private void DeleteSelectedExercises()
        {
            var selectedExercises = exerciseList.Where(x => x.IsSelected).ToList();

           foreach (var exercise in selectedExercises)
           {
                exerciseList.Remove(exercise);
           }

        }

        private void SaveWorkout()
        {
            List<Exercise> exercises = new List<Exercise>();

            foreach (Exercise exercise in exerciseList)
            {
                exercises.Add(exercise);
            }

            Workout w = new Workout();
            w.WorkoutDate = NewDate;
            w.Duration = NewDuration;
            workoutRepository.UpdateWorkout(w);
            foreach (Exercise exercise in exercises)
            {
                exercise.WorkoutId = w.WorkoutId;
                exerciseRepository.UpdateExercise(exercise);
            }
            
            exerciseList.Clear();
            NewDuration = 0;
            OnPropertyChanged(nameof(NewDuration));
            OnPropertyChanged(nameof(exerciseList));
            OnPropertyChanged(nameof(workoutRepository));
            OnPropertyChanged(nameof(exerciseRepository));

            MainWindow mw = Application.Current.Windows[0] as MainWindow;

            OnPropertyChanged(nameof(NewDuration));

        }
        public void Update()
        {
            var exercises = exerciseListItemsRepository.GetAllExerciseListItems();
            foreach (ExerciseListItem e in exercises)
            {
                existingExerciseList.Add(e.Name);
            }
        }

       

    }
}
