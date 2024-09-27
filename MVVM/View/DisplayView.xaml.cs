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
      public DisplayView()
      {
         InitializeComponent();
         List<TestData> items = new();
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

         lvItemSource.ItemsSource = items;
      }

      public class TestData
      {
         public string? Name { get; set; }
         public string? Description { get; set; }
         public List<string>? Schedule { get; set; }

         public override string ToString()
         {
            string day = "";
            for (int i = 0; i < Schedule.Count - 1; i++)
            {
               day += $"{Schedule[i]}, ";
            }
            day += Schedule[Schedule.Count - 1];
            return $"Name: {this.Name}, Description: {this.Description}, Schedule: {day}.";
         }
      }
   }
}
