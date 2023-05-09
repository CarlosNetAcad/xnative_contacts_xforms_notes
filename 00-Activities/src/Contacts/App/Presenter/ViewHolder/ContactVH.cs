using System;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;

namespace _00_Activities.src.Contacts.App.Presenter.ViewHolders
{
	public class ContactVH : RecyclerView.ViewHolder
	{
		public TextView Name { get; private set; }
		public TextView Phone { get; private set; }

		public ContactVH( View itemView) : base( itemView ) 
		{
			Name  = itemView.FindViewById<TextView>( Resource.Id.lbl_contact_name);
			Phone = itemView.FindViewById<TextView>( Resource.Id.lbl_contact_phone );
		}
	}
}

