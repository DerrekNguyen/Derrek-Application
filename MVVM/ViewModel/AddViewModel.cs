using Derrek_Application.Core;
using Derrek_Application.MVVM.Model;
using System;
using System.Collections.Generic;
using Derrek_Application.MVVM.View;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Linq.Expressions;

namespace Derrek_Application.MVVM.ViewModel
{
   class AddViewModel : ObservableObject
   {

      public RelayCommand SubmitAssignmentCommand { get; set; }
      public RelayCommand DayButtonCommand { get; set; }

      private Style _unchecked = new Style(typeof(System.Windows.Controls.RadioButton), (Style)System.Windows.Application.Current.Resources["UnselectedDayButtonTheme"]);
      private Style _checked = new Style(typeof(System.Windows.Controls.RadioButton), (Style)System.Windows.Application.Current.Resources["SelectedDayButtonTheme"]);
      private Dictionary<string, bool> DaysSelected = new Dictionary<string, bool>();

      private string _name;
      public string Name
      {
         get
         {
            return _name;
         }
         set
         {
            _name = value;
            OnPropertyChanged(nameof(Name));
         }
      }

      private string _description;
      public string Description
      {
         get
         {
            return _description;
         }
         set
         {
            _description = value;
            OnPropertyChanged(nameof(Description));
         }
      }

      private bool CheckValid()
      {
         return Description != null && Name != null;
      }

      private Style _buttonStyle;
      public Style ButtonStyle
      {
         get
         {
            return _buttonStyle;
         }
         set
         {
            _buttonStyle = value;
            OnPropertyChanged(nameof(ButtonStyle));
         }
      }

      private void InitializeDaySelected()
      {
         DaysSelected.Add("MondayButton", false);
         DaysSelected.Add("TuesdayButton", false);
         DaysSelected.Add("WednesdayButton", false);
         DaysSelected.Add("ThursdayButton", false);
         DaysSelected.Add("FridayButton", false);
         DaysSelected.Add("SaturdayButton", false);
         DaysSelected.Add("SundayButton", false);
      }

      public AddViewModel(AssignmentListViewModel assignmentList, MainViewModel mainView)
      {
         SubmitAssignmentCommand = new RelayCommand(o =>
         {
            //TODO: Implement day button in AddView
            List<DayOfWeek> days = new() {
               DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Friday
            };
            if (CheckValid())
            {
               assignmentList.AddAssignment(new Assignment(_name, _description, false, days));
               Name = "";
               Description = "";
               mainView.DisplayVM.RefreshConfigurations(assignmentList);
            }
            //TODO: Implement conflict controls (Either name or description is empty)
            else throw new Exception();
         });
      }
   }
}

