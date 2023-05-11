using Foundation;
using System;
using UIKit;

namespace ContactsApp.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            btnShowMessage.TouchUpInside += ShowMessageHandler;
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        private void ShowMessageHandler( object sender, EventArgs e)
        {
            lblText.Text = txtMessage.Text;
        }
    }
}
