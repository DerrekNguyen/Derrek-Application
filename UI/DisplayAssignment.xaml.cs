using Derrek_Application.Classes;
using Derrek_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Derrek_Application.UI
{
   /// <summary>
   /// Interaction logic for Window1.xaml
   /// </summary>
   public partial class DisplayAssignment : Window
   {
      List<Assignment> assignmentList = new List<Assignment>();
      SortedDictionary<DateTime, List<string>> assignmentNames = new SortedDictionary<DateTime, List<string>>();  

      /// <summary>
      /// Prepares title of all the assignemts. Sorted and stored by date.
      /// </summary>
      private void PrepareData()
      {
         assignmentList = GlobalConfig.sql.GetAllAssignment().OrderBy(o=>o.Deadline).ToList();

         List<string> tempTitle = new List<string>();
         DateTime tempDate = DateTime.Now;

         for (int i = 0; i < assignmentList.Count(); i++)
         {
            tempTitle.Add(assignmentList[i].Title);
            tempDate = assignmentList[i].Deadline.Date;

            if (i + 1 < assignmentList.Count())
            {
               if (assignmentList[i + 1].Deadline.Date != tempDate)
               {
                  assignmentNames.Add(tempDate, tempTitle);
                  tempTitle = new List<string>();
               }
            } 

            else
            {
               assignmentNames.Add(tempDate, tempTitle);
            }
         }
      }
      public DisplayAssignment()
      {
         InitializeComponent();
         PrepareData();
      }
   }
}
