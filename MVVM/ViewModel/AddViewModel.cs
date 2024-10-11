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
using Wpf.Ui.Input;
using System.DirectoryServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Derrek_Application.Data;

namespace Derrek_Application.MVVM.ViewModel
{
   class AddViewModel : ObservableObject
   {

      public RelayCommand SubmitAssignmentCommand { get; set; }
      public RelayCommand DayButtonCommand { get; set; }

      private Style _checked = new Style(typeof(System.Windows.Controls.CheckBox), (Style)System.Windows.Application.Current.Resources["SelectedDayButtonTheme"]);
      private Style _unchecked = new Style(typeof(System.Windows.Controls.CheckBox), (Style)System.Windows.Application.Current.Resources["UnselectedDayButtonTheme"]);

      private Dictionary<string, bool> DaysSelected = new Dictionary<string, bool>();
      private Dictionary<string, Style> DaysStyle = new Dictionary<string, Style>();

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

      public Style MondayButton
      {
         get
         {
            return DaysStyle["MondayButton"];
         }
      }

      public Style TuesdayButton
      {
         get
         {
            return DaysStyle["TuesdayButton"];
         }
      }

      public Style WednesdayButton
      {
         get
         {
            return DaysStyle["WednesdayButton"];
         }
      }

      public Style ThursdayButton
      {
         get
         {
            return DaysStyle["ThursdayButton"];
         }
      }

      public Style FridayButton
      {
         get
         {
            return DaysStyle["FridayButton"];
         }
      }

      public Style SaturdayButton
      {
         get
         {
            return DaysStyle["SaturdayButton"];
         }
      }

      public Style SundayButton
      {
         get
         {
            return DaysStyle["SundayButton"];
         }
      }

      private void InitializeDaysSelected()
      {
         DaysSelected.Add("MondayButton", false);
         DaysSelected.Add("TuesdayButton", false);
         DaysSelected.Add("WednesdayButton", false);
         DaysSelected.Add("ThursdayButton", false);
         DaysSelected.Add("FridayButton", false);
         DaysSelected.Add("SaturdayButton", false);
         DaysSelected.Add("SundayButton", false);
      }

      private void InitializeDaysStyle()
      {
         DaysStyle.Add("MondayButton", _unchecked);
         DaysStyle.Add("TuesdayButton", _unchecked);
         DaysStyle.Add("WednesdayButton", _unchecked);
         DaysStyle.Add("ThursdayButton", _unchecked);
         DaysStyle.Add("FridayButton", _unchecked);
         DaysStyle.Add("SaturdayButton", _unchecked);
         DaysStyle.Add("SundayButton", _unchecked);
      }

      private bool CheckValid()
      {
         bool validDay = false;
         foreach (var day in DaysSelected)
         {
            if (day.Value == true) validDay = true;
         }

         return Description != null && Name != null && validDay;
      }

      private string GetDay()
      {
         string result = "";
         foreach (var day in DaysSelected)
         {
            if (day.Value == true) result += day.Key.Replace("Button","") + ",";
         }
         return result.Remove(result.Length - 1);
      }

      public AddViewModel(AssignmentListViewModel assignmentList, MainViewModel mainView)
      {
         InitializeDaysSelected();
         InitializeDaysStyle();
         SubmitAssignmentCommand = new RelayCommand(o =>
         {
            //TODO: Implement day button in AddView
            if (CheckValid())
            {
               string days = GetDay();
               Assignment temp = new Assignment(_name, _description, false, days);
               temp = GlobalConfig.sql.StoreAssignment(temp);
               assignmentList.ReloadAssignment(GlobalConfig.sql.GetAllAssignment());
               Name = "";
               Description = "";
               mainView.DisplayVM.RefreshConfigurations(assignmentList);
            }
            //TODO: Implement conflict controls (Either name or description is empty, or no days are selected)
            else throw new Exception();
         });
         DayButtonCommand = new RelayCommand(o =>
         {
            if (o != null)
            {
               System.Windows.Controls.CheckBox sender = (System.Windows.Controls.CheckBox)o;
               DaysSelected[sender.Name] = (bool)sender.IsChecked;
               if (DaysSelected[sender.Name] == true)
               {
                  DaysStyle[sender.Name] = _checked;
                  OnPropertyChanged(sender.Name);
               }
               else
               {
                  DaysStyle[sender.Name] = _unchecked;
                  OnPropertyChanged(sender.Name);
               }
            }
         });
      }
   }
}

