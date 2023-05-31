using System;
using NotesForms.Effects;
using NotesForms.Constants;
using NotesForms.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ResolutionGroupName(Constant.AssamblyName)]
[assembly:ExportEffect(typeof(IOSTextShadow),nameof(TextShadow))]
namespace NotesForms.iOS.Effects
{
    public class IOSTextShadow : PlatformEffect //<Label, UILabel>
    {
        protected override void OnAttached()
        {
           if( Control is UILabel label)
            {
                label.Layer.ShadowColor = UIColor.Black.CGColor;
                label.Layer.ShadowRadius = 3.0f;
                label.Layer.ShadowOpacity = 1.0f;
                label.Layer.ShadowOffset = new CoreGraphics.CGSize(width: 4, height: 4);
                label.Layer.MasksToBounds = false;
            }
        }

        protected override void OnDetached()
        {
            throw new NotImplementedException();
        }
    }
}

