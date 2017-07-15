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
		LocationConfig location;

		public LocationModule ()
		{
			location = JsonFileParser.DeserializeFile<LocationConfig> ("Config/Location.json");
			logger.Info ("Location services initialized with address '{0}'",location.Address);

			var locationService = new GoogleLocationService ();
			var point = locationService.GetLatLongFromAddress (location.Address);
			logger.Info ("Retrieved lat: {0} long: {1} from google",point.Latitude,point.Longitude);

			Get ["/location"] = parameters =>
			{
				logger.Info("/location called with parameters {0}",parameters);
				return new { Lat = point.Latitude, Long = point.Longitude };
			};
		}
	}
}

