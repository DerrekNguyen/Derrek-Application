using System.Windows;

namespace Derrek_Application.UI
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
      }

      private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
      {
         if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            DragMove();
      }

      private void MinimizeButton_Click(object sender, RoutedEventArgs e)
      {
         WindowState = WindowState.Minimized;
      }

      private void CloseButton_Click(object sender, RoutedEventArgs e)
      {
         Application.Current.Shutdown();
      }

    }
}
