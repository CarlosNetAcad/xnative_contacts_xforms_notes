using System;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.Core.Entities;
using ContactApp.Core.Interfaces;
using ContactApp.Core.Repository.SQLite;
using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Contacts.MvvmCross.Core.ViewModels
{

    public class ContactsViewModel : MvxNavigationViewModel
    {
        private async Task OnContactSelectedHandler(Contact arg)
        {
            await NavigationService.Navigate<ContactDetailViewModel, Contact>( arg );
        }

        public ContactsViewModel(
            ILoggerFactory logFactory,
            IMvxNavigationService navigationService,
            IArticleService articleService
        ) : base(logFactory, navigationService)
        {
            _articlesServices = articleService;
            ContactSelectedCommand  = new MvxAsyncCommand<Contact>(OnContactSelectedHandler);
            Contacts                = new MvxObservableCollection<Contact>();
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();

            var contacts = Connection.Instance.Table<Contact>().ToList();

             if (contacts != null && contacts.Any())
            {
                Contacts.Clear();
                Contacts.AddRange(contacts);
            }

            /*
            var articles = await _articlesService.GetArticlesAsync();
            if (articles != null && articles.Any())
            {
               Contacts.Clear();

               foreach (var article in articles)
               {
                   Contacts.Add(new Contact
                   {
                       Fullname = article.Author,
                       PhoneNumber = article.PublishedAt.ToString("MM/dd yy")
                   });

               }

            }*/
        }

        #region Props
        public MvxObservableCollection<Contact> Contacts { get; private set; }
        public IMvxAsyncCommand<Contact> ContactSelectedCommand { get; private set; }
        #endregion

        #region 
        readonly IArticleService _articlesServices;
        #endregion
    }
}

