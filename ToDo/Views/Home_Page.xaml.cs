using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ToDo.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home_Page : Page
    {
        int calStats = 0;
        public Home_Page()
        {
            this.InitializeComponent();

        }

        private void AppBarCalendar_Click(object sender, RoutedEventArgs e)
        {
            if (calStats == 0)
            {
                calendarPopup.IsOpen = true;
                calStats = 1;
            }else
            {
                calendarPopup.IsOpen = false;
                calStats = 0;
            }
            
        }

        private void AppBarMap_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Maps_Page));

        }

        private void AppBarLogOut_Click(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
        }
    }
}
