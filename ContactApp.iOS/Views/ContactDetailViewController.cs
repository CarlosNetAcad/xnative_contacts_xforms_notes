using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using ContactApp.Core.Entities;
using Contacts.MvvmCross.Core.ViewModels;
using UIKit;


namespace ContactApp.iOS.Views
{
    [MvxFromStoryboard("Main")]
    [MvxChildPresentation]
    public partial class ContactDetailViewController : MvxViewController<ContactDetailViewModel>, IContactDetailViewController
    {
        public ContactDetailViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //saveBtn.TouchUpInside += OnSaveClicked;
            //fullnameView.Text = Contact?.Fullname;
            //Console.WriteLine(Contact?.Fullname);
            //phoneNumberView.Text = Contact?.PhoneNumber;
            //backBtn.TouchUpInside += BackBtn_TouchUpInside;

            var bindingSet = this.CreateBindingSet<ContactDetailViewController, ContactDetailViewModel>();
            //bindingSet.Bind(this).For(c => c.Title).To(vm => vm.Title);
            //bindingSet.Bind(fullnameView).To(vm => vm.Fullname);
            //bindingSet.Bind(phoneNumberView).To(vm => vm.PhoneNumber);
            //bindingSet.Bind(saveBtn).To(vm => vm.SaveCommand);
            //bindingSet.Bind(backBtn).To(vm => vm.DeleteCommand);
            bindingSet.Apply();
        }
    }
}

