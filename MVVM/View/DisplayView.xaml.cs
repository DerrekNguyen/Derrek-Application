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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Derrek_Application.MVVM.View
{
   /// <summary>
   /// Interaction logic for DisplayView.xaml
   /// </summary>
   public partial class DisplayView : UserControl
   {
      List<TestData> items = new List<TestData>();
      public DisplayView()
      {
         InitializeComponent();
         items.Add(new TestData()
         {
            Name = "Clean the house",
            Description = "Mob and wipe the floor of the house",
            Schedule = new List<string> { "Mon", "Tue" }
         });
         items.Add(new TestData()
         {
            Name = "Walk dog",
            Description = "Take Butters out for a Walk",
            Schedule = new List<string> { "Wed", "Thu" }
         });
         items.Add(new TestData()
         {
            Name = "Do laundry",
            Description = "Wash and dry clothes",
            Schedule = new List<string> { "Fri", "Sat", "Sun" }
         });
      }

      public class TestData
      {
         public string Name { get; set; }
         public string Description { get; set; }
         public List<string> Schedule { get; set; }
      }
   }
}
