﻿using System;
using Nancy.Hosting.Self;
using System.IO;
using NLog;
using NLog.Config;
using NLog.Targets;
using RestSharp;
using csharp_location_service.DataContracts;
using Utilities.Zookeeper;

namespace csharp_location_service
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			MainConfig app = JsonFileParser.DeserializeFile<MainConfig> ("Config/MainConfig.json");

			var cfg = new LoggingConfiguration ();
			var console = new ConsoleTarget ();
			console.Layout = @"${level} [${logger}] - ${message}";
			cfg.AddTarget ("console", console);
			LogLevel level = DetermineLogLevel (app.LogLevel);
			cfg.LoggingRules.Add (new LoggingRule("*", level, console));
			LogManager.Configuration = cfg;
			Logger logger = LogManager.GetCurrentClassLogger ();

			var uri = String.Format("http://localhost:{0}",app.Port);
			var host = new NancyHost (new Uri (uri));
			logger.Info ("Listening on {0}", uri);
			host.Start ();

			logger.Info ("Connecting to zookeeper and registering service...");
			ZookeeperAccessor accessor = new ZookeeperAccessor (app.ZookeeperHost, app.ZookeeperPort);
			accessor.RegisterService ("1.0", "location", app.Port);
			logger.Info ("Service registration complete");

			while (true)
			{
				
			}
		}

		private static LogLevel DetermineLogLevel(string logLevel)
		{
			switch(logLevel)
			{
				case "debug":
					return LogLevel.Debug;
				case "info":
					return LogLevel.Info;
				case "warning":
					return LogLevel.Warn;
				case "error":
					return LogLevel.Error;
				default:
					throw new ApplicationException ("Log level " + logLevel + " is not valid");
			}
		}
	}		
}
