using System;
using csharp_location_service.DataContracts;
using NLog;
using GoogleMaps.LocationServices;

namespace csharp_location_service
{
	public class LocationProvider
	{
		static Logger logger = LogManager.GetCurrentClassLogger ();
		public static LocationConfig Location { get; private set;}
		public static MapPoint LatLong{ get; private set;}

		static LocationProvider ()
		{
			Location = JsonFileParser.DeserializeFile<LocationConfig> ("Config/Location.json");
			logger.Info ("Location services initialized with address '{0}'",Location.Address);
			var locationService = new GoogleLocationService ();
			LatLong = locationService.GetLatLongFromAddress (Location.Address);
			logger.Info ("Retrieved lat: {0} long: {1} from google",LatLong.Latitude,LatLong.Longitude);
		}
	}
}

