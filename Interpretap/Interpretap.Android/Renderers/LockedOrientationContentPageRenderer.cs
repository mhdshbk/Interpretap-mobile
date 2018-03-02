using Android.App;
using Interpretap.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ContentPage), typeof(LockedOrientationContentPageRenderer))]
namespace Interpretap.Droid.Renderers
{
#pragma warning disable CS0618 // Type or member is obsolete
    public class LockedOrientationContentPageRenderer : PageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            var activity = Context as Activity;
            activity.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete
}