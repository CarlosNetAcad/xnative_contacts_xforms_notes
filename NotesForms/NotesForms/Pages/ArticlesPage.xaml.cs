﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

using NotesForms.ViewModels;
using NotesForms.Services;

namespace NotesForms.Pages
{	
	public partial class ArticlesPage : ContentPage
	{
		public ArticlesPage ()
		{
			InitializeComponent ();

		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is ArticleViewModel vm)
            {
                vm.CmdRefresh.Execute(null);
            }
        }
    }
}

