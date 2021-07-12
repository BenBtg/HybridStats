using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.Content;
using AndroidX.Fragment.App;
using HybridStats.Core.Services;
using HybridStats.Core.ViewModels;
using HybridStats.Core.Views;
using HybridStats.Droid.Fragments;
using Xamarin.Forms.Platform.Android;

namespace HybridStats.Droid.Services
{
    class NavigationService : INavigationService
    {
        private readonly Context context;
        private readonly Dictionary<Type, Type> ViewMap;
        private readonly FragmentManager fragmentManager;
        private readonly Dictionary<Type, string> _pageTitlesMap = new Dictionary<Type, string>();

        public NavigationService(Context context, Dictionary<Type, Type> viewMap)
        {
            this.context = context;
            this.ViewMap = viewMap;

            fragmentManager = this.context.GetFragmentManager();
            fragmentManager.BackStackChanged += fragmentManager_BackStackChanged;
        }

        public Task GoBack()
        {
            fragmentManager.PopBackStackImmediate();
            return Task.CompletedTask;
        }

        public Task NavigateAsync<T>() where T : BaseViewModel
        {
            var transaction = fragmentManager.BeginTransaction();
            var target = Activator.CreateInstance(ViewMap[typeof(T)]);
            transaction.AddToBackStack(null);

            if (target is BasePage cp)
            {
                target = cp.CreateSupportFragment(context);
                _pageTitlesMap[target.GetType()] = cp.BaseViewModel?.Title;
            }
            else if (target is BaseFragment bf)
            {
                _pageTitlesMap[target.GetType()] = bf.BaseViewModel?.Title;
            }

            transaction.Replace(Resource.Id.root_container, target as Fragment).Commit();

            return Task.CompletedTask;
        }

        private void fragmentManager_BackStackChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"fragmentManager_BackStackChanged");

            var topFragment = fragmentManager.Fragments.FirstOrDefault();
            var topFragmentType = topFragment?.GetType();
            if (_pageTitlesMap.ContainsKey(topFragmentType))
            {
                topFragment.Activity.Title = _pageTitlesMap[topFragmentType];
            }
        }
    }
}