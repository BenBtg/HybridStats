using Android.Content;
using AndroidX.Fragment.App;
using HybridStats.Core.Services;
using HybridStats.Core.ViewModels;
using HybridStats.Core.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace HybridStats.Droid.Services
{
    class NavigationService : INavigationService
    {
        private readonly Context context;
        private Dictionary<Type, Type> ViewMap;
        public NavigationService(Android.Content.Context context, Dictionary<Type, Type> viewMap)
        {
            this.context = context;
            this.ViewMap = viewMap;
        }

        public Task GoBack()
        {
            this.context.GetFragmentManager().PopBackStackImmediate();
            return Task.CompletedTask;
        }

        public Task NavigateAsync<T>() where T : BaseViewModel
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                var transaction = this.context.GetFragmentManager().BeginTransaction();

                var target = Activator.CreateInstance(ViewMap[typeof(T)]);

                Fragment fragment = null;

                transaction.AddToBackStack(null);

                if (target is ContentPage cp)
                    target = cp.CreateSupportFragment(context);

                transaction.Replace(Resource.Id.root_container,  target as Fragment).Commit();
            });
            return Task.CompletedTask;
        }
    }
}