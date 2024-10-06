using Derrek_Application.MVVM.Model;
using Derrek_Application.MVVM.ViewModel;
using Derrek_Application.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Derrek_Application
{
   /// <summary>
   /// Interaction logic for App.xaml
   /// </summary>
   public partial class App : System.Windows.Application
   {
      protected override void OnStartup(StartupEventArgs e)
      {
         MainWindow = new MainWindow()
         {
            DataContext = new MainViewModel()
         };
         MainWindow.Show();

         base.OnStartup(e);
      }
   }
}
