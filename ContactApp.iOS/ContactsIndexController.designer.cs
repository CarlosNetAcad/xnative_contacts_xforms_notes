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
	[Register ("ContactsIndexController")]
	partial class ContactsIndexController
	{
		[Outlet]
		UIKit.UITableView dgvContacts { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (dgvContacts != null) {
				dgvContacts.Dispose ();
				dgvContacts = null;
			}
		}
	}
}
