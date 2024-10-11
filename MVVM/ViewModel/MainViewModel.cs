using Derrek_Application.Core;
using Derrek_Application.Data;
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
      private AssignmentListViewModel _assignmentList = new AssignmentListViewModel(new AssignmentList("Test Assignment List", GlobalConfig.sql.GetAllAssignment()));

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
         string days = "Monday,Wednesday,Friday";

         AddVM = new AddViewModel(_assignmentList, this);
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
