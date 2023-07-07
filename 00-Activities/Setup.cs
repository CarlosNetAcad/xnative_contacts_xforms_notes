using System;
using Android.Util;
using Microsoft.Extensions.Logging;
using MvvmCross.Converters;
using MvvmCross.IoC;
using MvvmCross.Platforms.Android.Core;
using System.Collections.Generic;
using System.Reflection;
using MvvmCross.DroidX.RecyclerView;
using Serilog.Extensions.Logging;
using Serilog;
using Log = Serilog.Log;
using Contact.MvvmCross.Core;

namespace _00_Activities
{
	public class Setup:MvxAndroidSetup<App>
	{
        protected override IEnumerable<Assembly> AndroidViewAssemblies => new List<Assembly>(base.AndroidViewAssemblies)
        {
            typeof(MvxRecyclerView).Assembly
        };

        protected override ILoggerProvider CreateLogProvider()
        {
            return new SerilogLoggerProvider();
        }

        protected override void InitializeFirstChance(IMvxIoCProvider iocProvider)
        {
            base.InitializeFirstChance(iocProvider);
            //initialize db service
            //await DBSQLiteService.Instance.Initialize(Constants.DatabasePath);
        }

        protected override ILoggerFactory CreateLogFactory()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.AndroidLog()
                .CreateLogger();

            return new SerilogLoggerFactory();
        }

        protected override void FillValueConverters(IMvxValueConverterRegistry registry)
        {
            base.FillValueConverters(registry);
            //registry.AddOrOverwrite(nameof(DateConverter), new DateConverter());
            //registry.AddOrOverwrite(nameof(FlightNumberConverter), new FlightNumberConverter());
        }
    }
}

