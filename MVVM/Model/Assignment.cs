using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derrek_Application.MVVM.Model
{
   public class Assignment
   {
      // Attributes
      public int AssignmentID = 0;
      public string Title { get; set; }
      public string Description { get; set; }
      public bool Done { get; set; }
      public List<DayOfWeek> Schedule { get; set; }

      // Methods
      public Assignment(string title,
                        string description,
                        bool done,
                        List<DayOfWeek> schedule)
      {
         Title = title;
         Description = description;
         Done = done;
         Schedule = schedule;
      }
      public Assignment() : this("", "", false, new List<DayOfWeek>()) { }

      public string GetSchedule()
      {
         string result = string.Empty;
         foreach (DayOfWeek day in Schedule)
         {
            result += day.ToString() + " ";
         }
         return result;
      }

      private bool Equals(Assignment other)
      {
         if (other == null) return false;
         //TODO: delete this when SQL is implemented for retrieving Assignment with ID.
         return true;
         //return (AssignmentID.Equals(other.AssignmentID));
      }

      public bool Equals(object obj)
      {
         if (obj == null) return false;
         if (obj is not Assignment objAsAssignment) return false;
         return Equals(objAsAssignment);
      }
   }
}
