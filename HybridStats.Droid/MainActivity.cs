using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using HybridStats.Core.ViewModels;
using HybridStats.Core.Views;
using HybridStats.Droid.Fragments;
using HybridStats.Droid.Services;
using System;
using System.Collections.Generic;

namespace HybridStats.Droid
{
    [Activity(Label = "HybridStats", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            App.Navigation = new NavigationService(this, new Dictionary<Type, Type>()
            {
                {typeof(FirstViewModel), typeof(FirstFragment) },
                {typeof(SecondViewModel), typeof(SecondPage) },
                {typeof(ThirdViewModel), typeof(ThirdFragment) }
            });

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
         }

        protected override void OnStop()
        {
            base.OnStop();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}
