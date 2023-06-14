using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using NotesCarlos.Core.Models.API;
using NotesForms.Services;
using NotesForms.ViewModels.Base;
using Xamarin.Forms;
using Prism.Navigation;

namespace NotesForms.ViewModels
{
	public class ArticleViewModel:BaseVM
	{
        #region Flds

        readonly IArticleService _articleService;

        #endregion Flds

        #region Props
        public ObservableCollection<Article> Articles { get; private set; }
        #endregion Props

        #region Ctors
        public ArticleViewModel( IArticleService articleService)
		{
            _articleService = articleService;

            Articles = new ObservableCollection<Article>();
		}
        #endregion Ctors

        #region -  methods
        #endregion - methods

        #region # methods
        protected override async Task Refreshing()
        {
            IsRefreshing = true;

            var articles = await _articleService.GetAllAsync();

            Articles.Clear();

            foreach( var article in articles)
            {
                Articles.Add(article);
            }

            IsRefreshing = false;
        }
        #endregion # methods

        #region + methods
        #endregion + methods
    }
}

