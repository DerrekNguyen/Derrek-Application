using Derrek_Application.Core;
using Derrek_Application.MVVM.Model;
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

      public DisplayViewModel(AssignmentListViewModel assignmentList)
      {
         _assignments = new ObservableCollection<AssignmentViewModel>();

         List<DayOfWeek> days = new()
         {
            DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Friday
         };

         foreach (Assignment a in assignmentList.GetAssignments())
         {
            _assignments.Add(new AssignmentViewModel(a));
         }
      }
   }
}
