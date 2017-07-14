using System;

namespace csharp_location_service.DataContracts
{
	public class MainConfig
	{
		public string LogLevel{get;set;}
		public int Port{ get; set;}
		public string ZookeeperHost{get;set;}
		public int ZookeeperPort{get;set;}
	}
}

