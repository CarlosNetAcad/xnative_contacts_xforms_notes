using Foundation;
using System;
using UIKit;

namespace ContactApp.iOS
{
    public partial class ViewController : UIViewController
    {
        void PrintMessageHandler(object sender, EventArgs e)
        {
            lblMainMessage.Text = txtMainMessage.Text;
        }

        private void OnClickMe(object sender, EventArgs e)
        {
            //welcomeLbl.Text = textField.Text;

            //Modal Programatically
            /*
            var contactsVC = (ContactDetailViewController)Storyboard.InstantiateViewController("ContactDetailViewController");
            contactsVC.Note = new Models.Note { Title = "Jair" };
            contactsVC.MyParameter = "3123132312313123";
            this.PresentViewController(contactsVC, true, null);
            */

            //stack programatically
            var contactsVC = (ContactDetailVC)Storyboard.InstantiateViewController("ContactDetailViewController");
            //contactsVC.Note = new Models.Note { Title = "Jair" };
            //contactsVC.MyParameter = "3123132312313123";
            this.NavigationController.PushViewController(contactsVC, true);
        }

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

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "ContactsVCIdentifier")
            {
                var contactsVC = (ContactDetailVC)segue.DestinationViewController;
                //contactsVC.Note = new Models.Note { Title = "Perla - Segue" };
                //contactsVC.MyParameter = "0909090909090";
            }

            if (segue.Identifier == "ContactStackId")
            {
                var contactsVC = (ContactDetailVC)segue.DestinationViewController;
                //contactsVC.Note = new Models.Note { Title = "Carlos - Segue" };
                // contactsVC.MyParameter = "1111111111111";
            }

            if (segue.Identifier == "ColorSegue")
            {
                //TODO: navigating to color
                var colorVC = segue.DestinationViewController;

                colorVC.View.BackgroundColor = UIColor.Yellow;
            }
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            Console.WriteLine("ViewWillAppear........");
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            Console.WriteLine("ViewDidAppear........");

        }
    }
}
