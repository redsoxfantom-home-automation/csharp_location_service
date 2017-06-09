using System;
using log4net.Appender;
using log4net.Core;
using System.Diagnostics;

namespace csharp_location_service.Appender
{
	public class CustomAppender : AppenderSkeleton
	{
		protected override void Append (LoggingEvent loggingEvent)
		{
			Process.GetCurrentProcess().
			Console.Write(RenderLoggingEvent (loggingEvent));
		}

		protected override bool RequiresLayout
		{
			get
			{
				return true;
			}
		}
	}
}

