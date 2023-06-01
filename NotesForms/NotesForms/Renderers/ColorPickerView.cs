using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace NotesForms.Renderers
{
	public class ColorPickerView:View
	{
        #region Attr
        public static readonly BindableProperty ColorSelectedProperty =
            BindableProperty.Create(
                propertyName: nameof(ColorSelected),
                returnType:(typeof(Color)),
                declaringType:typeof(ColorPickerView),
                defaultValue: null
            );
        #endregion Attr

        #region Prop
        public Color ColorSelected
        {
            get => (Color)GetValue(ColorSelectedProperty);
            set => SetValue(ColorSelectedProperty,value);

        }
        #endregion Prop


    }
}