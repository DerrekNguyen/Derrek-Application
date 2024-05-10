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
      List<string> assignmentNames = new List<string>();
      private void PrepareData()
      {
         assignmentList = GlobalConfig.sql.GetAllAssignment().OrderBy(o=>o.Deadline).ToList();
         foreach (Assignment a in assignmentList)
         {
            // TODO
         }
      }
      public DisplayAssignment()
      {
         InitializeComponent();
         PrepareData();
      }
   }
}
