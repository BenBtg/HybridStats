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
        private readonly FragmentManager fragmentManager;
        private Dictionary<Type, Type> FragmentMap;
        public NavigationService(FragmentManager fragmentManager, Dictionary<Type, Type> fragmentMap)
        {
            this.fragmentManager = fragmentManager;

            this.FragmentMap = fragmentMap;

        }

        public Task GoBack()
        {
            this.fragmentManager.PopBackStackImmediate();
            return Task.CompletedTask;
        }

        public Task NavigateAsync<T>() where T : BaseViewModel
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                var transaction = fragmentManager.BeginTransaction();


                var fragment = FragmentMap[typeof(T)];

                transaction.AddToBackStack(null);

                if (fragment.IsSubclassOf(typeof(BasePage<T>)))
                {
                    Debug.WriteLine("Is Forms page!");

                    var formPage = Activator.CreateInstance(fragment) as BasePage<T>;

                    var formsFragment = formPage.CreateSupportFragment(Xamarin.Essentials.Platform.AppContext);
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