using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derrek_Application.MVVM.Model
{
   public class AssignmentList
   {
      public string Name { get; set; }
      public List<Assignment> _assignments = new List<Assignment>();

      public void AddAssignment(Assignment assignment)
      {
         if (!_assignments.Contains(assignment))
            _assignments.Add(assignment);
         else throw new Exception(); //TODO: Implement conflict controls.
      }

      public AssignmentList(string name)
      {
         Name = name;
      }

   }
}
