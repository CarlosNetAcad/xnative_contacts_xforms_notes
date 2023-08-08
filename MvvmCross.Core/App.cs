using System;
using MvvmCross;
using MvvmCross.ViewModels;
using System.Threading.Tasks;
using MvvmCross.IoC;
using Contacts.MvvmCross.Core.ViewModels;
using ContactApp.Core.Interfaces;
using ContactApp.Core.Services;

namespace Contacts.MvvmCross.Core
{
    public class App:MvxApplication
    {
        /// <summary>
        /// Breaking change in v6: This method is called on a background thread. Use
        /// Startup for any UI bound actions
        /// </summary>
        public override void Initialize()
        {
            //base.Initialize();
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IArticleService, APIService>();
            RegisterAppStart<ContactsViewModel>();
        }

        /// <summary>
        /// Do any UI bound startup actions here
        /// </summary>
        /// <returns></returns>
        public override Task Startup()
        {
            return base.Startup();
        }

        /// <summary>
        /// If the application is restarted (eg primary activity on Android
        /// can be restarted) this method will be called before Startup
        /// is called again
        /// </summary>
        public override void Reset()
        {
            base.Reset();
        }
    }
}

