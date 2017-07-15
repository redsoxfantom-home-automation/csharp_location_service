using System;
using Nancy;
using NLog;
using GoogleMaps.TimeZoneServices;
using RestSharp;

namespace csharp_location_service
{
	public class TimeModule : NancyModule
	{
		Logger logger = LogManager.GetCurrentClassLogger();
		private const double NUM_TICKS = 4500.0;

		public TimeModule ()
		{
			var point = LocationProvider.LatLong;
			var timeZoneSvc = new GoogleTimeZoneServices ();
			var tz = timeZoneSvc.GetTimeZoneFromLatLong (point.Latitude, point.Longitude);
			var tzoffset = tz.RawOffset / NUM_TICKS;
			var tzDecimalPart = tzoffset - Math.Truncate (tzoffset.Value);
			TimeSpan tzSpan = new TimeSpan ((int)tzoffset,(int)(tzDecimalPart * 60),0);

			var sunClient = new RestClient ("http://api.sunrise-sunset.org");
			var sunClientReq = new RestRequest (string.Format ("/json?lat={0}&lng={1}&formatted=0",point.Latitude,point.Longitude), Method.GET);

			Get ["/time"] = parameters =>
			{
				var resp = sunClient.Execute<SunriseSunsetResponse>(sunClientReq);

				return new {
					results = new {
						TimeZone = tzSpan,
						TimeZoneName = tz.TimeZoneName,
						CurrentTime = DateTime.UtcNow,
						SunData = resp.Data.results
					},
					status = "OK"
				};
			};
		}
	}
}

