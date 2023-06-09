using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContactApp.Core.Entities;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace NotesForms.Services
{
	public interface IGeolocation
	{
		int Altitude { get; set; }
		Task<Location> GetCurrentLocation();
		Task SetPinsOnTheMapAsync(IList<Note> notes, Xamarin.Forms.Maps.Map map);
	}
}

