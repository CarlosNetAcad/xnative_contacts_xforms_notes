using System;
using Microsoft.Extensions.Logging;

using Contacts.MvvmCross.Core;
//using Contacts.MvvmCross.Core;
using MvvmCross.Platforms.Ios.Core;
using Serilog.Extensions.Logging;
using Serilog;
using MvvmCross.IoC;

namespace ContactApp.iOS
{
	public class Setup : MvxIosSetup<App>
	{
        protected override ILoggerFactory CreateLogFactory()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .CreateLogger();

            return new SerilogLoggerFactory();
        }

        protected override ILoggerProvider CreateLogProvider()
        {
            return new SerilogLoggerProvider();
        }

        protected override void InitializeFirstChance(IMvxIoCProvider iocProvider)
        {
            base.InitializeFirstChance(iocProvider);
        }
    }
}

