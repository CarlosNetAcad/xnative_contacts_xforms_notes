using System;
using System.Threading.Tasks;
using NotesForms.Services;
using Xamarin.Essentials;

namespace NotesForms.Repository
{
    public class GeoLocationService : IGeolocation
    {
        public async Task<Location> GetCurrentLocation()
        {
            return await Geolocation.GetLocationAsync();
        }
    }
}

