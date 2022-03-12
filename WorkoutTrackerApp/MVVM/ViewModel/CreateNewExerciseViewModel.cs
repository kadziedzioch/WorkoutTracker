using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkoutTrackerApp.Core;
using WorkoutTrackerApp.Database.Repositories;
using WorkoutTrackerApp.Database.Entities;
using System.Windows.Input;

namespace WorkoutTrackerApp.MVVM.ViewModel
{
    class CreateNewExerciseViewModel:ObservableObject
    {
        public ExerciseListItemsRepository repository = new ExerciseListItemsRepository(DatabaseLocator.Database);

        public ObservableCollection<ExerciseListItem> ExerciseList { get; set; } = new ObservableCollection<ExerciseListItem>();

        public string newName { get; set; }

        public ICommand AddNewExerciseCommand { get; set; }
        public ICommand DeleteExerciseCommand { get; set; }


        public CreateNewExerciseViewModel()
        {
            AddNewExerciseCommand = new RelayCommand(o => { AddNewExercise(); });
            DeleteExerciseCommand = new RelayCommand(o => { DeleteSelectedExercises(); });
            UpdateList();

        }

        public void UpdateList()
        {
            var list = repository.GetAllExerciseListItems();
            ExerciseList.Clear();
            foreach (var exerciseListItem in list)
            {
                ExerciseList.Add(exerciseListItem);
            }
            OnPropertyChanged(nameof(newName));
        }

        public void AddNewExercise()
        {
            var newExerciseListItem = new ExerciseListItem
            {

                Name = newName

            };

            repository.UpdateExerciseListItem(newExerciseListItem);

            newName = string.Empty;

            OnPropertyChanged(nameof(newName));
            UpdateList();

        }

        public void DeleteSelectedExercises()
        {
            var selectedExercises = ExerciseList.Where(x => x.IsSelected).ToList();
            if (selectedExercises != null)
            {
                foreach (var exercise in selectedExercises)
                {
                    ExerciseList.Remove(exercise);
                    repository.RemoveExerciseListItem(exercise);
                }

                UpdateList();

            }
        }


    }
}
