using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTrackerApp.Core;

namespace WorkoutTrackerApp.MVVM.ViewModel
{
    class MainViewModel :ObservableObject 
    {
        public RelayCommand WorkoutListCommand { get; set; }
        public RelayCommand AddNewWorkoutCommand { get; set; }
        public RelayCommand CreateNewExerciseCommand { get; set; }
        public RelayCommand ControlYourWeightCommand { get; set; }
        public RelayCommand SeeMoreCommand { get; set; }

        public SeeMoreViewModel SeeMoreVM { get; set; }
        public WorkoutListViewModel WorkoutListVM { get; set; }
        public AddNewWorkoutViewModel AddNewWorkoutVM { get; set; } 
        public CreateNewExerciseViewModel CreateNewExerciseVM { get; set; }
        public ControlYourWeightViewModel ControlYourWeightVM { get; set; } 

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged(); 
            }
        }

        public MainViewModel()
        {
            WorkoutListVM = new WorkoutListViewModel();
            AddNewWorkoutVM = new AddNewWorkoutViewModel();
            CreateNewExerciseVM = new CreateNewExerciseViewModel();
            ControlYourWeightVM = new ControlYourWeightViewModel();
            SeeMoreVM = new SeeMoreViewModel();
            CurrentView = WorkoutListVM;

            WorkoutListCommand = new RelayCommand(o => 
            {
                WorkoutListVM.UpdateLatestWorkout();
                WorkoutListVM.UpdateStatistics();
                CurrentView = WorkoutListVM;
                

            });

            AddNewWorkoutCommand = new RelayCommand(o => 
            {
                AddNewWorkoutVM.Update();
                CurrentView = AddNewWorkoutVM;
            
            });
            CreateNewExerciseCommand = new RelayCommand(o =>
            {
                CurrentView = CreateNewExerciseVM;

            });
            ControlYourWeightCommand = new RelayCommand(o =>
            {
                CurrentView = ControlYourWeightVM;

            });
            SeeMoreCommand = new RelayCommand(o =>
            {
                SeeMoreVM.UpdateWorkouts();
                CurrentView = SeeMoreVM;

            });
        }
    }
}
