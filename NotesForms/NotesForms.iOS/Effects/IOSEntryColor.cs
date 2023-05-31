using System;
using System.Linq;
using NotesForms.Constants;
using NotesForms.Effects;
using NotesForms.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportEffect(typeof(IOSEntryColor),nameof(EntryBorderColor))]
namespace NotesForms.iOS.Effects
{
    public class IOSEntryColor : PlatformEffect //<Label,UILabel>
    {
        #region private methods

        void OnEditingChanged( object sender, EventArgs e )
        {
            var textField = sender as UITextField;

            if( textField.Text.Length >= 3)
            {
                textField.Layer.BorderColor = UIColor.Red.CGColor;
                textField.Layer.BorderWidth = 1;
            }
            else
            {
                textField.Layer.BorderWidth = 0;
            }
        }

        #endregion private methods

        #region protected methods
        protected override void OnAttached()
        {
            if (Control is UITextField textField)
            {
                textField.EditingChanged += OnEditingChanged;
            }
        }

        protected override void OnDetached()
        {
            throw new NotImplementedException();
        }
        #endregion protected methods

    }
}

