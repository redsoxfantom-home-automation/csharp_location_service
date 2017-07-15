using System;

namespace csharp_location_service
{
	public class SunriseSunsetResponse
	{
		public SunriseSunsetResponseData results{get;set;}
		public string status{get;set;}
	}
	public class SunriseSunsetResponseData
	{
		public string sunrise{get;set;}
		public string sunset{get;set;}
	}
}

