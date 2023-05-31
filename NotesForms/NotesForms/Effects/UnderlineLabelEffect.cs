using System;
using Xamarin.Forms;
using NotesForms.Constants;

namespace NotesForms.Effects
{
    public class UnderlineLabelEffect : RoutingEffect
    {
        protected UnderlineLabelEffect() : base($"{Constant.AssamblyName}.{nameof(UnderlineLabelEffect)}"){}
    }
}