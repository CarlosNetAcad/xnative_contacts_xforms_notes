using System;
using NotesForms.iOS.Renderers;
using NotesForms.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer( typeof(SegmentView),typeof(IOSSegmentView) )]
namespace NotesForms.iOS.Renderers
{
	public class IOSSegmentView:ViewRenderer<View,UISegmentedControl>
	{
        #region private method
        void OnSegmentOne( UIAction action)
        {
            Console.WriteLine("Segment 1 clicked!");
        }

        void OnSegmentTwo( UIAction action )
        {
            Console.WriteLine("Segment 2 clicked!!");
        }
        #endregion private method

        #region protected method
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if ( e.NewElement != null )
            {
                var segmentedControl = new UISegmentedControl();
                //var segment = UIAction.Create("title",null,null,ActionHandler);
                var segment1 = UIAction.Create("Order asc",null,null,OnSegmentOne);
                var segment2 = UIAction.Create("Orer desc",null,null,OnSegmentTwo);

                segmentedControl.InsertSegment(segment1,0,true);
                segmentedControl.InsertSegment(segment2,1,true);

                //-> Do not forget set native control.
                SetNativeControl( segmentedControl );
            }
        }
        #endregion protected method
    }
}

