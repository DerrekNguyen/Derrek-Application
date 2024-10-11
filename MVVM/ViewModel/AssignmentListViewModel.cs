using Derrek_Application.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derrek_Application.MVVM.ViewModel
{
   public class AssignmentListViewModel
   {
      private AssignmentList _assignmentList;

      public string GetName() { return _assignmentList.Name; }
      public List<Assignment> GetAssignments() { return _assignmentList._assignments; }
      public void AddAssignment(Assignment assignment) { _assignmentList.AddAssignment(assignment); }
      public void ReloadAssignment(List<Assignment> assignments) {  _assignmentList._assignments = assignments; }
      
      public AssignmentListViewModel(AssignmentList assignmentList)
      {
         _assignmentList = assignmentList;
      }
   }
}
