using System;
using Nancy;
using NLog;
using csharp_location_service.DataContracts;
using GoogleMaps.LocationServices;

namespace csharp_location_service
{
	public class LocationModule : NancyModule
	{
		Logger logger = LogManager.GetCurrentClassLogger ();
		LocationConfig location = LocationProvider.Location;
		MapPoint point = LocationProvider.LatLong;

		public LocationModule ()
		{
			Get ["/location"] = parameters =>
			{
				return new { 
					results = new {
						Address = location.Address, 
						Lat = point.Latitude, 
						Long = point.Longitude
					},
					status = "OK"
				};
			};
		}
	}
}

