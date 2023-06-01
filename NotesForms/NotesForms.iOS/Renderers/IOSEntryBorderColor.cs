using System;
using NotesForms.iOS.Renderers;
using NotesForms.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer( typeof(MyEntryBordered),typeof(IOSEntryBorderColor) )]
namespace NotesForms.iOS.Renderers
{
	public class IOSEntryBorderColor:EntryRenderer
	{
        #region private method

        void OnEditingChanged( object sender, EventArgs e)
        {
            var textField = sender as UITextField;

            if ( textField.Text.Length >= 3 )
            {
                textField.Layer.BorderColor = UIColor.Red.CGColor;
                textField.Layer.BorderWidth = 1;
            }
            else
            {
                textField.Layer.BorderWidth = 0;
            }
        }
        #endregion private method

        #region protected method
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if( e.OldElement != null )
            {
                Control.EditingChanged -= OnEditingChanged;
            }

            if( e.NewElement != null)
            {
                Control.EditingChanged += OnEditingChanged;
            }
        }
        #endregion protected method
    }
}