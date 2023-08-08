using System;
using Foundation;
using MvvmCross.Platforms.Ios.Binding.Views;
using ContactApp.Core.Entities;
using UIKit;

namespace ContactApp.iOS.DataSources
{
	public class MvxContactsDataSource : MvxTableViewSource
	{
        const string CellIdentifier = "CellIdentifier";

        public MvxContactsDataSource(UITableView tableView) : base(tableView)
        {
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var cell = tableView.DequeueReusableCell( CellIdentifier );

            if( cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier);

            var contact = item as Contact;
            //cell.ImageView.Image = Image
            cell.TextLabel.Text = contact.FullName;
            cell.DetailTextLabel.Text = contact.Phone;

            return cell;
        }
    }
}

