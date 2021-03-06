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
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            FragmentManager = this.SupportFragmentManager;

            FragmentManager.BackStackChanged += FragmentManager_BackStackChanged;
            
            App.Navigation = new NavigationService(FragmentManager, new Dictionary<Type, Type>()
            {
                {typeof(FirstViewModel), typeof(FirstFragment) },
                {typeof(SecondViewModel), typeof(SecondFragment) },
                {typeof(ThirdViewModel), typeof(ThirdFragment) }
            });

            App.Navigation.NavigateAsync<FirstViewModel>();
         }

        public override void OnBackPressed()
        {
            App.Navigation.GoBack();
            base.OnBackPressed();
        }

        private void FragmentManager_BackStackChanged(object sender, EventArgs e)
        {
            Console.WriteLine(e);
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
