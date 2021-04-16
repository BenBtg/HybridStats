using AndroidX.Fragment.App;
using HybridStats.Core;
using HybridStats.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

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
            var transaction = fragmentManager.BeginTransaction();

            var fragment = FragmentMap[typeof(T)];
         
            transaction.AddToBackStack(nameof(T));
            transaction.Replace(Resource.Id.root_container, Activator.CreateInstance(fragment) as Fragment).Commit();

            return Task.CompletedTask;
        }
    }
}