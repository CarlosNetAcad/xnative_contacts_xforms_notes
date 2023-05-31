using System;
using Xamarin.Forms;
using NotesForms.Constants;

namespace NotesForms.Effects
{
    public class TextShadow : RoutingEffect
    {
        //-> Note: The constructor must be public.
        public TextShadow() : base( $"{Constant.AssamblyName}.{nameof(TextShadow)}" ){}
    }
}