using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Interpretap.CustomRenderers;
using Interpretap.Droid.CustomRenderers;

namespace Interpretap.Droid
{
    [Activity(Label = "Interpretap", Icon = "@drawable/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            global::Xamarin.Forms.Forms.Init(this, bundle);
            //LoadApplication(new App());
            LoadApplication(UXDivers.Gorilla.Droid.Player.CreateApplication(
    this,
    new UXDivers.Gorilla.Config("Good Gorilla")
    //            .RegisterAssembly(typeof(Interpretap.App).Assembly)
    //  // Register UXDivers Effects assembly
    //  //.RegisterAssembly(typeof(UXDivers.Effects.Effects).Assembly)
    //  // FFImageLoading.Transformations
    //  //.RegisterAssemblyFromType<FFImageLoading.Transformations.BlurredTransformation>()
    //  // FFImageLoading.Forms
    //  //.RegisterAssemblyFromType<FFImageLoading.Forms.CachedImage>()
    ));
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            App.OnUnhandledException();
            var ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                App.ReportException(ex);
            }
        }
    }
}

