using System;
using System.Collections.Generic;

using Xamarin.Forms;

using NotesForms.ViewModels;
using NotesForms.Services;

namespace NotesForms.Pages
{	
	public partial class ArticlesPage : ContentPage
	{

		ArticleViewModel _articleVM;

		public ArticlesPage ()
		{
			InitializeComponent ();

			var articleServ = DependencyService.Resolve<IArticleService>();

			BindingContext = _articleVM = new ArticleViewModel(articleServ);
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
			_articleVM.CmdRefresh.Execute(null);
        }
    }
}

