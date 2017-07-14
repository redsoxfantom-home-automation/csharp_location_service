using System;
using Nancy;
using NLog;

namespace csharp_location_service
{
	public class LocationModule : NancyModule
	{
		Logger logger = LogManager.GetCurrentClassLogger ();

		public LocationModule ()
		{
			Get ["/location"] = parameters =>
			{
				logger.Info("/location called with parameters {0}",parameters);
				return string.Empty;
			};
		}
	}
}

