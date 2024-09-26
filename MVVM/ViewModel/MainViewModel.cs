using Derrek_Application.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derrek_Application.MVVM.ViewModel
{
   class MainViewModel : ObservableObject
   {
      public RelayCommand AddViewCommand { get; set; }
      public RelayCommand DisplayViewCommand { get; set; }
      public AddViewModel AddVM { get; set; }
      public DisplayViewModel DisplayVM { get; set; }

      private object _currentView;
      public object CurrentView
      {
         get { return _currentView; }
         set
         {
            _currentView = value;
            OnPropertyChanged();
         }
      }

      public MainViewModel()
      {
         AddVM = new AddViewModel();
         DisplayVM = new DisplayViewModel();

         CurrentView = AddVM;

         AddViewCommand = new RelayCommand(o =>
         {
            CurrentView = AddVM;
         });

         DisplayViewCommand = new RelayCommand(o =>
         {
            CurrentView = DisplayVM;
         });

      }
   }
}
