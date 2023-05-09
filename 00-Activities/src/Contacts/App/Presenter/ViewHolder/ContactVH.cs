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

		private Action<int> _action;

		public ContactVH( View itemView, Action<int> action) : base( itemView ) 
		{
			Name  = itemView.FindViewById<TextView>( Resource.Id.lbl_contact_name);
			Phone = itemView.FindViewById<TextView>( Resource.Id.lbl_contact_phone );

			_action = action;

			itemView.Click += OnClickHandler;
		}

        private void OnClickHandler( object sender, EventArgs e)
		{
#pragma warning disable CS0618 // Type or member is obsolete
            _action?.Invoke( this.Position );
#pragma warning restore CS0618 // Type or member is obsolete
        }
	}
}

