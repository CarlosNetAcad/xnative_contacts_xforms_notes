using System;
using System.Collections.Generic;
using Foundation;
using ContactApp.Core.Entities;
using UIKit;

namespace ContactApp.iOS.DataSources
{
	public class ContactDS : UITableViewSource
	{
		const string CELL_ID = "CellIdentifier";

		private List<Contact> _contactsList = null;

		private UIViewController _parent;

		public ContactDS( List<Contact> contactsList, UIViewController parent )
		{
            _contactsList   = contactsList;
            _parent         = parent;
		}

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var tblContacts = tableView.DequeueReusableCell( CELL_ID );

            if( tblContacts == null )
                tblContacts = new UITableViewCell( UITableViewCellStyle.Subtitle, CELL_ID );

            var contact = _contactsList[ indexPath.Row ];

            tblContacts.TextLabel.Text          = contact.FullName;
            tblContacts.DetailTextLabel.Text    = contact.Phone;

            return tblContacts;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _contactsList.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //base.RowSelected(tableView, indexPath);

            var contact = _contactsList[ indexPath.Row ];

            var contactDetailVC     = (ContactDetailVC)_parent.Storyboard.InstantiateViewController( "ContactDetailVC" ) ;
            contactDetailVC.Contact = contact;
            contactDetailVC.ExistContact = true;
            _parent.NavigationController.PushViewController( contactDetailVC, true );
        }
    }
}

