using System;
using Foundation;
using NotesForms.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportEffect( typeof(UnderlineLabelEffect),nameof(NotesForms.Effects.UnderlineLabelEffect) )]
namespace NotesForms.iOS.Effects
{
    public class UnderlineLabelEffect : PlatformEffect<Label,UILabel>
    {
        protected override void OnAttached()
        {
            var element                 = new Label(); 
            var label                   = new UILabel();
            var newString               = new NSMutableAttributedString(element.Text ?? "");
            var attributes              = new UIStringAttributes();
            attributes.UnderlineStyle   = NSUnderlineStyle.Single;
            newString.AddAttributes(attributes, new NSRange(0, newString.Length));
            label.AttributedText        = newString;
        }

        protected override void OnDetached()
        {
            throw new NotImplementedException();
        }
    }
}

