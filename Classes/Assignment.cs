using Derrek_Application.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derrek_Application.Classes
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
   }
}
