using Derrek_Application.Classes;
using Derrek_Application.Data;
using System;
using System.Configuration;
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

namespace Derrek_Application.UI
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class CreateAssignment : Window
   {
      public CreateAssignment()
      {
         InitializeComponent();
      }
      private void createAssignmentForm_Load(object sender, EventArgs e)
      {

      }

      private void submitButton_Click(object sender, EventArgs e)
      {
         if (ValidForm())
         {
            DateTime deadline = DateTime.Parse(deadlineDatePicker.Text);

            if (ValidDateAmount() != 0)
            {
               deadline = DateTime.Today.AddDays(ValidDateAmount());
            }

            Assignment t = new Assignment(titleTextBox.Text, descriptionTextBox.Text, noteTextBox.Text, doneCriteriaTextBox.Text, false, deadline);
            GlobalConfig.sql.StoreAssignment(t);

            titleTextBox.Text = "";
            descriptionTextBox.Text = "";
            noteTextBox.Text = "";
            doneCriteriaTextBox.Text = "";
            deadlineDatePicker.Text = DateTime.Now.ToString();
            dateAmountTextBox.Text = "";
         }
         else MessageBox.Show("Invalid value detected. Please try again");
      }

      private void dateAmountTextBox_TextChanged(object sender, EventArgs e)
      {

      }

      // Prerequisite: ValidForm() == true
      private int ValidDateAmount()
      {
         int result = 0;
         if (dateAmountTextBox.Text != "")
         {
            result = int.Parse(dateAmountTextBox.Text);
         }

         return result;
      }

      private bool ValidForm()
      {
         if (titleTextBox.Text == "") return false;
         if (descriptionTextBox.Text == "") return false;
         if (dateAmountTextBox.Text == "" && DateTime.Parse(deadlineDatePicker.Text) == DateTime.Now.Date) return false;
         else
         {
            int.TryParse(dateAmountTextBox.Text, out int t);
            if (t < 0 || DateTime.Parse(deadlineDatePicker.Text) < DateTime.Now.Date) return false;
            if (t > 0 && DateTime.Parse(deadlineDatePicker.Text) != DateTime.Now.Date) return false;
         }

         return true;
      }

   }
}
