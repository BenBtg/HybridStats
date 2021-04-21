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
        private Dictionary<Type, Type> FragmentMap;
        public NavigationService(Android.Content.Context context, Dictionary<Type, Type> fragmentMap)
        {
            this.context = context;
            this.FragmentMap = fragmentMap;
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


                var fragment = FragmentMap[typeof(T)];

                transaction.AddToBackStack(null);

                if (fragment.IsSubclassOf(typeof(BasePage<T>)))
                {
                    Debug.WriteLine("Is Forms page!");

                    
                    var formPage = Activator.CreateInstance(fragment) as BasePage<T>;
                     
                    var formsFragment = formPage.CreateSupportFragment(context);
                    transaction.Replace(Resource.Id.root_container, formsFragment).Commit();
                }
                else
                {
                    transaction.Replace(Resource.Id.root_container, Activator.CreateInstance(fragment) as Fragment).Commit();
                }
            });
            return Task.CompletedTask;
        }
    }
}