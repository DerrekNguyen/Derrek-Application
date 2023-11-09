using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derrek_Application.Classes
{
   public class Course
   {
      // Attributes
      public int CourseID { get; set; }
      public string Name { get; set; }
      public DateTime StartDate { get; set; }
      public DateTime EndDate { get; set; }

      private class Schedule
      {
         private DayOfWeek DayOfWeek { get; set; }
         private TimeSpan TimeOfDay { get; set; }
      }
   }
}
