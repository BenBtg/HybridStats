using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using AndroidX.Fragment.App;
using HybridStats.Core;
using HybridStats.Core.ViewModels;
using HybridStats.Core.Views;
using HybridStats.Droid.Fragments;
using HybridStats.Droid.Services;
using System;
using System.Collections.Generic;

namespace HybridStats.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Xamarin.Forms.Forms.Init(this, null);
            SetContentView(Resource.Layout.activity_main);

            App.Navigation = new NavigationService(this, new Dictionary<Type, Type>()
            {
                {typeof(FirstViewModel), typeof(FirstFragment) },
                {typeof(SecondViewModel), typeof(SecondPage) },
                {typeof(ThirdViewModel), typeof(ThirdFragment) }
            });

            App.Navigation.NavigateAsync<FirstViewModel>();
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
