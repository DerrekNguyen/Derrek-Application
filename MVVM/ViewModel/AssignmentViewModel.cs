using Derrek_Application.MVVM.Model;
using Derrek_Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derrek_Application.MVVM.ViewModel
{
   public class AssignmentViewModel : ObservableObject
   {
      private readonly Assignment _assignment;

      public int AssignmentID => _assignment.AssignmentID;
      public string Title => _assignment.Title;
      public string Description => _assignment.Description;
      public bool Done => _assignment.Done;
      public string Schedule => _assignment.GetScheduleDisplay();

      public AssignmentViewModel(Assignment assignment)
      {
         _assignment = assignment;
      }
      public override string ToString()
      {
         return $"{Title}, {Description}, {Schedule}";
      }
   }
}
