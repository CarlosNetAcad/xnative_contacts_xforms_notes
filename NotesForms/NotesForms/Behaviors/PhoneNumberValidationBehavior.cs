using System;
using Xamarin.Forms;

namespace NotesForms.Behaviors
{
	public class PhoneNumberValidationBehavior:Behavior<Entry>
	{
        #region const
        #endregion const

        #region attr
        #endregion attr

        #region Prop
        #endregion Prop

        #region __Constructors
        #endregion __Constructors 

        #region methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnChanged(object sender, TextChangedEventArgs e)
        {
            var self = sender as Entry;

            if ( !string.IsNullOrEmpty(e.NewTextValue) &&
                 e.NewTextValue.Length == 10 )
                self.TextColor = Color.Green;
            else
                self.TextColor = Color.Red;
        }
        #endregion methods

        #region protected methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bindable"></param>
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnChanged;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bindable"></param>
        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnChanged;
        }

        #endregion protected methods

        #region public methods
        #endregion public methods
    }
}

