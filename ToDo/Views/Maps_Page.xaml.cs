using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Devices.Geolocation;
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
    public sealed partial class Maps_Page : Page
    {
        
        public Maps_Page()
        {
            this.InitializeComponent();
            getLocation();
        }

        private void AppBarCalendar_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Home_Page));
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Home_Page));
        }
        private void AppBarLogOut_Click(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
        }

        private async void getLocation()
        {
            var position = await Models.M_Location.GeoPosition();
            double geoLat = position.Coordinate.Latitude;
            double geoLong = position.Coordinate.Longitude;
            BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = geoLat, Longitude = geoLong };
            Geopoint cityCenter = new Geopoint(cityPosition);

            // Set the map location.
            MapControl1.Center = cityCenter;
            MapControl1.ZoomLevel = 18;
            MapControl1.LandmarksVisible = true;
        }
    }
}
