using System;
using CoreGraphics;
using Interpretap.CustomRenderers;
using Interpretap.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(RoundedEntry), typeof(RoundedEntryRenderer))]
namespace Interpretap.iOS.CustomRenderers
{
    public class RoundedEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)  
        {  
            base.OnElementChanged(e);
            Control.BorderStyle = UITextBorderStyle.None;
            if (e.NewElement != null)  
            {  
                var view = (RoundedEntry)Element;  
  
                Control.LeftView = new UIView(new CGRect(0f, 0f, 9f, 20f));
                Control.LeftViewMode = UITextFieldViewMode.Always;  
  
                Control.KeyboardAppearance = UIKeyboardAppearance.Dark;  
                Control.ReturnKeyType = UIReturnKeyType.Done;  
                // Radius for the curves  
                Control.Layer.CornerRadius = Convert.ToSingle(view.CornerRadius);  
                // Thickness of the Border Color  
                Control.Layer.BorderColor = view.BorderColor.ToCGColor();  
                // Thickness of the Border Width  
                Control.Layer.BorderWidth = view.BorderWidth;  
                Control.ClipsToBounds = true;  
            }  
        } 
    }
}
