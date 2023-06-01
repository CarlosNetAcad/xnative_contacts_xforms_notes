using System;
using Android.Content;
using Google.Android.Material.Tabs;
using NotesForms.Droid.Renderers;
using NotesForms.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer( typeof(SegmentView),typeof(DroidSegmentView) )]
namespace NotesForms.Droid.Renderers
{
    public class DroidSegmentView : ViewRenderer<View, TabLayout>, TabLayout.IOnTabSelectedListener
    {

        #region constructor
        public DroidSegmentView( Context context) : base(context) { }
        #endregion constructor

        #region - methods
        #endregion -  methods

        #region # methods
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if ( e.NewElement != null )
            {
                var tabLayout = new TabLayout( this.Context );
                tabLayout.AddOnTabSelectedListener( this );

                var tab1 = tabLayout.NewTab();
                tab1.SetId(1);
                tab1.SetText("Order asc");

                var tab2 = tabLayout.NewTab();
                tab2.SetId(2);
                tab2.SetText("Order desc");

                tabLayout.AddTab(tab1);
                tabLayout.AddTab(tab2);

                SetNativeControl(tabLayout);
            }
        }
        #endregion # methods

        #region + methods
        public void OnTabReselected(TabLayout.Tab tab)
        {
            //throw new NotImplementedException();
        }

        public void OnTabSelected(TabLayout.Tab tab)
        {
            switch( tab.Id)
            {
                case 1:
                    Console.WriteLine("Order asc selected!");
                    break;
                case 2:
                    Console.WriteLine("Order desc selected!!");
                    break;
            }
        }

        public void OnTabUnselected(TabLayout.Tab tab)
        {
            //throw new NotImplementedException();
        }
        #endregion + methods
    }
}

