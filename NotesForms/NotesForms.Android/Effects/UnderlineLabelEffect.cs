using System;
using Android.Widget;
using NotesForms.Constants;
using NotesForms.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(UnderlineLabelEffect),nameof(NotesForms.Effects.UnderlineLabelEffect))]
namespace NotesForms.Droid.Effects
{
	public class UnderlineLabelEffect:PlatformEffect
	{
        protected override void OnAttached()
        {
            if (Control is TextView)
            {
                var textView        = (TextView)Control;
                var element         = (Label)Element;
                textView.PaintFlags = textView.PaintFlags | Android.Graphics.PaintFlags.UnderlineText;
                textView.Text       = element.Text ?? "";
            }
        }

        protected override void OnDetached()
        {
            //throw new NotImplementedException();
        }
    }
}

