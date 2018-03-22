using System;
using Interpretap.CustomRenderers;
using Interpretap.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(CustomPicker), typeof(ExtendedPickerRenderer))]
namespace Interpretap.iOS.CustomRenderers
{
    public class ExtendedPickerRenderer : PickerRenderer
    {
		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
            base.OnElementChanged(e);
            var element = (CustomPicker)this.Element;

            if (this.Control != null && this.Element != null && !string.IsNullOrEmpty(element.Image))
            {
                var downarrow = UIImage.FromBundle(element.Image);
                Control.RightViewMode = UITextFieldViewMode.Always;
                Control.RightView = new UIImageView(downarrow);
                Control.Font = UIFont.SystemFontOfSize(14);
            }
		}
	}
}
