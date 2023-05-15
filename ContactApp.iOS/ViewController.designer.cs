// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ContactApp.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton btnPrintMessage { get; set; }

		[Outlet]
		UIKit.UILabel lblMainMessage { get; set; }

		[Outlet]
		UIKit.UITextField txtMainMessage { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblMainMessage != null) {
				lblMainMessage.Dispose ();
				lblMainMessage = null;
			}

			if (txtMainMessage != null) {
				txtMainMessage.Dispose ();
				txtMainMessage = null;
			}

			if (btnPrintMessage != null) {
				btnPrintMessage.Dispose ();
				btnPrintMessage = null;
			}
		}
	}
}
