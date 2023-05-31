using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace NotesForms.Renderers
{
	public class LongPressButton:Button
	{
		public static readonly BindableProperty LongPressCmdProp =
			BindableProperty.Create( propertyName: nameof( LongPressCmdProp ),
				returnType: ( typeof( ICommand ) ),
				declaringType: typeof( LongPressButton ),
				defaultValue:null
			);

		public ICommand LongPressCommand
		{
			get => ( ICommand )GetValue( LongPressCmdProp );
			set => SetValue( LongPressCmdProp,value );
		}
	}
}