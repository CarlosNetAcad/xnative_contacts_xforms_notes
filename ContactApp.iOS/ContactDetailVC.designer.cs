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
	[Register ("ContactDetailVC")]
	partial class ContactDetailVC
	{
		[Outlet]
		UIKit.UIButton btnSaveContactUI { get; set; }

		[Outlet]
		UIKit.UITextField txtContactFullNameUI { get; set; }

		[Outlet]
		UIKit.UITextField txtContactPhoneUI { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (txtContactFullNameUI != null) {
				txtContactFullNameUI.Dispose ();
				txtContactFullNameUI = null;
			}

			if (txtContactPhoneUI != null) {
				txtContactPhoneUI.Dispose ();
				txtContactPhoneUI = null;
			}

			if (btnSaveContactUI != null) {
				btnSaveContactUI.Dispose ();
				btnSaveContactUI = null;
			}
		}
	}
}
