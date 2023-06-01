using System;
using NotesForms.iOS.Renderers;
using NotesForms.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer( typeof(ColorPickerView),typeof(IOSColorPickerView) )]
namespace NotesForms.iOS.Renderers
{
	public class IOSColorPickerView:ViewRenderer<View,UIColorWell>
	{
        #region - methods

        void OnSelected( object sender, EventArgs e)
        {
            var colorPicker = Element as ColorPickerView;
            colorPicker.ColorSelected = Control.SelectedColor.ToColor();
        }

        #endregion -  methods

        #region # methods

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if ( e.NewElement != null)
            {
                var ColorWell = new UIColorWell();
                //var action = UIAction.Create(OnSelected);

                ColorWell.AddTarget( OnSelected,UIControlEvent.ValueChanged);

                SetNativeControl(ColorWell);
            }
        }

        #endregion # methods
    }
}

