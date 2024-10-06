using Derrek_Application.Core;
using Derrek_Application.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derrek_Application.MVVM.ViewModel
{
   class MainViewModel : ObservableObject
   {
      //TODO: Implement getting Assignment list from SQL
      private AssignmentListViewModel _assignmentList = new AssignmentListViewModel(new AssignmentList("Test Assignment List"));

      public RelayCommand AddViewCommand { get; set; }
      public RelayCommand DisplayViewCommand { get; set; }
      public AddViewModel AddVM { get; set; }
      public DisplayViewModel DisplayVM { get; set; }

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
         List<DayOfWeek> days = new List<DayOfWeek> {
            DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Friday
         };

         _assignmentList.AddAssignment(new Assignment("Walk Dog", "Walk Butters around the block", false, days));
         _assignmentList.AddAssignment(new Assignment("Do Laundry", "Wash and dry clothes", false, days));
         _assignmentList.AddAssignment(new Assignment("Do Homework", "Finish all homework for the day", false, days));

         AddVM = new AddViewModel();
         DisplayVM = new DisplayViewModel(_assignmentList);

         CurrentView = AddVM;

         AddViewCommand = new RelayCommand(o =>
         {
            CurrentView = AddVM;
         });

         DisplayViewCommand = new RelayCommand(o =>
         {
            CurrentView = DisplayVM;
         });

      }
   }
}
