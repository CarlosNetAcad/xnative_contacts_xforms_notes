using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContactApp.Core.Entities;
using NotesForms.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace NotesForms.Repository
{
    public class GeoLocationService : IGeolocation
    {
        public int Altitude { get; set; } = 1000;

        public async Task<Location> GetCurrentLocation()
        {
            return await Geolocation.GetLocationAsync();
        }

        public Task SetPinsOnTheMapAsync(IList<Note> notes, Xamarin.Forms.Maps.Map map)
        {
            //if (notes == null) return await Task.FromResult(null);

            try
            {
                foreach (var location in notes)
                {
                    var position = new Position(location.Latitude, location.Longitude);

                    var distance = new Distance(Altitude);

                    //var mapSpan = MapSpan.FromCenterAndRadius(position, distance);

                    var currentPosition = new Pin()
                    {
                        Label = location.Title,
                        Position = position
                    };

                    map.Pins.Add(currentPosition);
                    //map.MoveToRegion(mapSpan);
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

            return Task.CompletedTask;
        }
    }
}

