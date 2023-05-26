using System;
using Xamarin.Forms;

namespace NotesForms.Triggers
{
	public class PasswordEventTrigger:TriggerAction<Entry>
	{
        #region const
        const int MIN_LENGTH = 6;
        #endregion const

        #region protected method
        /// <summary>
        /// Event called to validate de min lenght in an entry
        /// </summary>
        /// <param name="sender"></param>
        protected override void Invoke(Entry sender)
        {
            if (sender.Text != null &&
                 sender.Text.Length >= MIN_LENGTH)
                sender.BackgroundColor = Color.Accent;
            else
                sender.BackgroundColor = Color.Transparent;
        }
        #endregion protected method
       
    }
}

