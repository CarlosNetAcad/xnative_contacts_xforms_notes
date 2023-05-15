// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ContactsApp.iOS.src.Contacts.Views
{
	[Register ("ThirdOne")]
	partial class ThirdOne
	{
		[Outlet]
		UIKit.UIButton btnDoAnything { get; set; }

		[Outlet]
		UIKit.UILabel lblThirdOneTitle { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblThirdOneTitle != null) {
				lblThirdOneTitle.Dispose ();
				lblThirdOneTitle = null;
			}

			if (btnDoAnything != null) {
				btnDoAnything.Dispose ();
				btnDoAnything = null;
			}
		}
	}
}
