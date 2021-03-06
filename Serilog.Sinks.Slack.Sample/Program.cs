﻿using System;
using Serilog.Events;

namespace Serilog.Sinks.Slack.Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Verbose()
               .WriteTo.Console(LogEventLevel.Debug)
               .WriteTo.Slack("https://hooks.slack.com/services/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", 20, TimeSpan.FromSeconds(10), "#test", "Im a Ghost", ":ghost:")
               .CreateLogger();

            Log.Logger.Verbose("1 Verbose");
            Log.Logger.Debug("2 Debug");
            Log.Logger.Error("3 Error");
            try
            {
                throw new Exception("some logged exception!");
            }
            catch (Exception ex)
            {
                Log.Logger.Fatal(ex, "4 Fatal");
            }
            Log.Logger.Information("5 Information");
            Log.Logger.Warning("6 Warning");
            Log.Logger.Debug("7 Formatting {myProp}", new { myProp = "test" });
            Console.ReadKey();
        }
    }
}
