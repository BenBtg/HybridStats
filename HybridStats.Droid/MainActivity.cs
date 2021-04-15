using System;
using Android.OS;
using Android.Runtime;
using AndroidX.Fragment.App;
using Android.App;
using HybridStats.Droid.Services;
using HybridStats.Core.Services;
using HybridStats.Core;
using System.Collections.Generic;
using HybridStats.Droid.Fragments;

namespace HybridStats.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : FragmentActivity
    {
        AndroidX.Fragment.App.FragmentManager FragmentManager;
        INavigationService navigation;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            FragmentManager = this.SupportFragmentManager;
            navigation = new NavigationService(FragmentManager, new Dictionary<Type, Type>()
            {
                {typeof(SecondViewModel), typeof(FirstFragment) }
            });

            App.Naviagtion = new NavigationService(FragmentManager, new Dictionary<Type, Type>()
            {
                {typeof(SecondViewModel), typeof(SecondFragment) },
                {typeof(ThirdViewModel), typeof(ThirdFragment) }
            });

            navigation.NavigateAsync<SecondViewModel>();
         }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}
