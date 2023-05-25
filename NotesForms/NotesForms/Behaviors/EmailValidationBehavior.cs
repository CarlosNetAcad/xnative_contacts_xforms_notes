using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace NotesForms.Behaviors
{
	public class EmailValidationBehavior:Behavior<Entry>
	{
        #region const
        const string EMAIL_PATTERN = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        #endregion const

        #region attr
        Regex regex = new Regex( EMAIL_PATTERN );
        #endregion attr

        #region private methods
        void OnChanged(object sender, TextChangedEventArgs e)
        {
            var self = sender as Entry;
            Console.WriteLine($"Entry.val: {e.NewTextValue}");
            if (regex.IsMatch(e.NewTextValue)) self.TextColor = Color.Black;
            else self.TextColor = Color.Red;
        }
        #endregion private methods

        #region protected methods
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnChanged;
        }
        #endregion protected methods

    }
}

