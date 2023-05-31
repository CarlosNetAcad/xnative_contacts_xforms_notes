using System;
using NotesForms.Constants;
using Xamarin.Forms;

namespace NotesForms.Effects
{
    public class EntryBorderColor : RoutingEffect
    {
        //-> Note: The constructor must be public.
        public EntryBorderColor() : base($"{Constant.AssamblyName}.{nameof(EntryBorderColor)}") {}
    }
}