using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace ToDo.Models
{
    public class M_Location
    {
       
        public async static Task<Geoposition> GeoPosition()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();
            if (accessStatus != GeolocationAccessStatus.Allowed) throw new Exception();

            var geoLocator = new Geolocator { DesiredAccuracyInMeters=0};
            var position = await geoLocator.GetGeopositionAsync();

            return position;

            
        }
    }
}
