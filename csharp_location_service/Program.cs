using System;
using Nancy.Hosting.Self;
using log4net;
using log4net.Config;
using System.IO;

namespace csharp_location_service
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			ILog logger = LogManager.GetLogger (typeof(MainClass));
			//XmlConfigurator.Configure (new FileInfo (Path.Combine("Config","log4netconfiguration.xml")));
			BasicConfigurator.Configure ();

			var uri = "http://localhost:8888";
			var host = new NancyHost (new Uri (uri));
			logger.InfoFormat ("Listening on {0}", uri);
			host.Start ();

			while (true)
			{
				
			}
		}
	}
}
