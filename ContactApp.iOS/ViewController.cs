using Foundation;
using System;
using UIKit;

namespace ContactApp.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            btnPrintMessage.TouchUpInside += PrintMessageHandler;
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        private void PrintMessageHandler( object sender, EventArgs e)
        {
            lblMainMessage.Text = txtMainMessage.Text;
        }
    }
}
