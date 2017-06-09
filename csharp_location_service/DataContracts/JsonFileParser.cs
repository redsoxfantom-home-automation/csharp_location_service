using System;
using NLog;
using System.IO;
using RestSharp;

namespace csharp_location_service.DataContracts
{
	public class JsonFileParser
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		public static T DeserializeFile<T> (String filename)
		{
			filename = Path.Combine (AppDomain.CurrentDomain.BaseDirectory, filename);
			logger.Info ("Reading {0}", filename);
			String text = File.ReadAllText (filename);
			logger.Debug ("File contents:\n{0}", text);
			return SimpleJson.DeserializeObject<T> (text);
		}
	}
}

