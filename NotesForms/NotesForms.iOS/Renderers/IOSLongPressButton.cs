using System;
using System.ComponentModel;
using System.Windows.Input;
using NotesForms.iOS.Renderers;
using NotesForms.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace NotesForms.iOS.Renderers
{
	public class IOSLongPressButton:ButtonRenderer
	{
        #region attr
        ICommand _command = null;
        #endregion attr

        #region private method
        void OnLongPressed()
        {
            _command?.Execute(null);
        }
        #endregion private method

        #region protected method
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var longPressButton = Element as LongPressButton;
                var longPressed = new UILongPressGestureRecognizer();
                _command = longPressButton.LongPressCommand;

                longPressed.AddTarget( OnLongPressed );

                Control.AddGestureRecognizer( longPressed );
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if ( e.PropertyName == LongPressButton.LongPressCmdProp.PropertyName)
            {
                var longPressButton = Element as LongPressButton;

                _command = longPressButton.LongPressCommand;
            }
            {

            }
        }
        #endregion protected method
    }
}