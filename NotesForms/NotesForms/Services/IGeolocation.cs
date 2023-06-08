using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace NotesForms.Services
{
	public interface IGeolocation
	{
		Task<Location> GetCurrentLocation();
	}
}

