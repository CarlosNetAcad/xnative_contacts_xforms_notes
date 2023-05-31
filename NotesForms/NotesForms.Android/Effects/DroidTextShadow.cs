using System;
using Xamarin.Forms;
using NotesForms.Constants;
using NotesForms.Effects;
using Xamarin.Forms.Platform.Android;
using Android.Widget;

namespace NotesForms.Droid.Effects
{
    public class DroidTextShadow : PlatformEffect//<element from forms, control from specific platform>
    {
        protected override void OnAttached()
        {
            if( Control is TextView textView)
            {
                textView.SetShadowLayer( 10,0,0, Color.Black.ToAndroid() ); 
            }
        }

        protected override void OnDetached()
        {
            throw new NotImplementedException();
        }
    }
}

