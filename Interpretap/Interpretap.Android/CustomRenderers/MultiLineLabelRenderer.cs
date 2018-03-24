using System;
using Android.Content;
using Interpretap.CustomRenderers;
using Interpretap.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(MultiLineLabel),typeof(MultiLineLabelRenderer))]
namespace Interpretap.Droid.CustomRenderers
{
    public class MultiLineLabelRenderer : LabelRenderer
    {
        public MultiLineLabelRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            MultiLineLabel multiLineLabel = (MultiLineLabel)Element;
            if (multiLineLabel != null && multiLineLabel.Lines != -1)
            {
                Control.SetSingleLine(false);
                Control.SetLines(multiLineLabel.Lines);
            }
        }
        }
}
