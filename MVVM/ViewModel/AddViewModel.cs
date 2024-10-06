using Derrek_Application.Core;
using Derrek_Application.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derrek_Application.MVVM.ViewModel
{
   class AddViewModel : ObservableObject
   {
      public RelayCommand SubmitAssignmentCommand { get; set; }

      private string _name;
      public string Name
      {
         get
         {
            return _name;
         }
         set
         {
            _name = value;
            OnPropertyChanged(nameof(Name));
         }
      }

      private string _description;
      public string Description
      {
         get
         {
            return _description;
         }
         set
         {
            _description = value;
            OnPropertyChanged(nameof(Description));
         }
      }

      private bool CheckValid()
      {
         return Description != null && Name != null;
      }

      public AddViewModel(AssignmentListViewModel assignmentList, MainViewModel mainView)
      {
         SubmitAssignmentCommand = new RelayCommand(o =>
         {
            //TODO: Implement day button in AddView
            List<DayOfWeek> days = new() {
               DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Friday
            };
            if (CheckValid())
            {
               assignmentList.AddAssignment(new Assignment(_name, _description, false, days));
               Name = "";
               Description = "";
               mainView.DisplayVM.RefreshConfigurations(assignmentList);
            }
            //TODO: Implement conflict controls (Either name or description is empty)
            else throw new Exception();
         });
      }
   }
}

