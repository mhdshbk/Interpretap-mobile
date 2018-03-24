using System;
using Interpretap.CustomRenderers;
using Interpretap.iOS.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(MultiLineLabel),typeof(MultiLineLabelRenderer))]
namespace Interpretap.iOS.CustomRenderers
{
    public class MultiLineLabelRenderer : LabelRenderer
    {
        public MultiLineLabelRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            MultiLineLabel multiLineLabel = (MultiLineLabel)Element;

            if (multiLineLabel != null && multiLineLabel.Lines != -1)
                Control.Lines = multiLineLabel.Lines;
        }
    }
}
