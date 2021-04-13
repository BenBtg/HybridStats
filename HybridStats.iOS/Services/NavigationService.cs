using System;
using System.Threading.Tasks;
using HybridStats.Core;
using HybridStats.Core.Services;

namespace HybridStats.iOS.Services
{
    class NavigationService : INavigationService
    {
        public Task GoBack()
        {
            // Todo: implement go back
            return Task.CompletedTask;
        }

        public Task NavigateAsync<T>() where T : BaseViewModel
        {
            // Todo: Implement navigation
            return Task.CompletedTask;
        }
    }
}