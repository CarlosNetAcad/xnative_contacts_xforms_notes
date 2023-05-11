// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ContactsApp.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton btnShowMessage { get; set; }

		[Outlet]
		UIKit.UILabel lblText { get; set; }

		[Outlet]
		UIKit.UITextField txtMessage { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblText != null) {
				lblText.Dispose ();
				lblText = null;
			}

			if (txtMessage != null) {
				txtMessage.Dispose ();
				txtMessage = null;
			}

			if (btnShowMessage != null) {
				btnShowMessage.Dispose ();
				btnShowMessage = null;
			}
		}
	}
}
