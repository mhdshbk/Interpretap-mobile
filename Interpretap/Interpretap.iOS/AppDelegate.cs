using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Interpretap.CustomRenderers;
using Interpretap.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Interpretap.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            global::Xamarin.Forms.Forms.Init();

            //NavigationBar customization
            UINavigationBar.Appearance.BarTintColor = null;
            UINavigationBar.Appearance.TintColor = Color.FromHex("#f37a3f").ToUIColor();
            UINavigationBar.Appearance.TitleTextAttributes = new UIStringAttributes()
            {
                ForegroundColor = UIColor.Black
            };

            //Tab Customization
            UITabBar.Appearance.SelectedImageTintColor = Color.FromHex("#f37a3f").ToUIColor();

            LoadApplication(new App());
            //          LoadApplication(UXDivers.Gorilla.iOS.Player.CreateApplication(
            //new UXDivers.Gorilla.Config("Good Gorilla")
            //// Register Grial Shared assembly
            ////.RegisterAssemblyFromType<UXDivers.Artina.Shared.CircleImage>()
            //// Register UXDivers Effects assembly
            ////.RegisterAssembly(typeof(UXDivers.Effects.Effects).Assembly)
            //// FFImageLoading.Transformations
            ////.RegisterAssemblyFromType<FFImageLoading.Transformations.BlurredTransformation>()
            //// FFImageLoading.Forms
            ////.RegisterAssemblyFromType<FFImageLoading.Forms.CachedImage>()
            //));

            return base.FinishedLaunching(app, options);
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
