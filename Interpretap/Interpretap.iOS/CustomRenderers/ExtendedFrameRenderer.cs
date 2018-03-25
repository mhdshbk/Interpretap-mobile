using System;
using CoreGraphics;
using Interpretap.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(Frame),typeof(ExtendedFrameRenderer))]
namespace Interpretap.iOS.CustomRenderers
{
    public class ExtendedFrameRenderer : FrameRenderer
    {
        public ExtendedFrameRenderer()
        {
        }

		public override void Draw(CGRect rect)
		{
            base.Draw(rect);
            if(Element.HasShadow)
            {
                Layer.ShadowRadius = 2.0f;
                Layer.ShadowColor = UIColor.Gray.CGColor;
                Layer.ShadowOffset = new CGSize(2, 2);
                Layer.ShadowOpacity = 0.80f;
                Layer.ShadowPath = UIBezierPath.FromRect(Layer.Bounds).CGPath;
                Layer.MasksToBounds = false;
            }
		}
	}
}
