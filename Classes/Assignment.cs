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
      public string Note { get; set; }
      public TimeSpan Duration { get; set; }
      public string DoneCriteria { get; set; }
      public bool Done { get; set; }
      public DateTime Deadline { get; set; }
      public TimeSpan Break { get; set; } = new TimeSpan(0, 5, 0);
      private TimeSpan DefaultDuration { get; set; } = new TimeSpan(0, 25, 0);

      // Methods
      public Assignment(string title,
                        string description,
                        string note,
                        string doneCriteria,
                        bool done,
                        DateTime deadline)
      {
         Title = title;
         Description = description;
         Note = note;
         DoneCriteria = doneCriteria;
         Done = done;
         Duration = DefaultDuration;
         Deadline = deadline;
      }
      public Assignment() : this("", "", "", "", false, DateTime.Now) { }
   }
}
