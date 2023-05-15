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
	[Register ("Contact")]
	partial class Contact
	{
		[Outlet]
		UIKit.UIButton btnContactAction { get; set; }

		[Outlet]
		UIKit.UITextField txtContactName { get; set; }

		[Outlet]
		UIKit.UITextField txtContactPhone { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (txtContactName != null) {
				txtContactName.Dispose ();
				txtContactName = null;
			}

			if (txtContactPhone != null) {
				txtContactPhone.Dispose ();
				txtContactPhone = null;
			}

			if (btnContactAction != null) {
				btnContactAction.Dispose ();
				btnContactAction = null;
			}
		}
	}
}
