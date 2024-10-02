using Derrek_Application.Classes;
using Derrek_Application.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Derrek_Application.MVVM.ViewModel
{
   public class DisplayViewModel : ObservableObject
   {
      private readonly ObservableCollection<AssignmentViewModel> _assignments;
      public IEnumerable<AssignmentViewModel> Assignments => _assignments;

      public DisplayViewModel()
      {
         _assignments = new ObservableCollection<AssignmentViewModel>();

         List<DayOfWeek> days = new List<DayOfWeek>();
         days.Add(DayOfWeek.Monday);
         days.Add(DayOfWeek.Tuesday);
         days.Add(DayOfWeek.Friday);

         _assignments.Add(new AssignmentViewModel(new Assignment("Walk Dog", "Walk Butters around the block", false, days)));
         _assignments.Add(new AssignmentViewModel(new Assignment("Do Laundry", "Wash and dry clothes", false, days)));
      }
   }
}
