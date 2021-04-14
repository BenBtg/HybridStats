using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HybridStats.Core;
using HybridStats.Core.Services;
using UIKit;

namespace HybridStats.iOS.Services
{
    class NavigationService : INavigationService
    {
        private UINavigationController navigationController;
        private UIStoryboard storyboard;

        public NavigationService(UINavigationController navigationController, Dictionary<Type, Type> viewControllerMap)
        {
            ViewControllerMap = viewControllerMap;
            this.navigationController = navigationController;
        }


        public UIStoryboard Storyboard { get
                {
                if (storyboard == null)
                    storyboard = UIStoryboard.FromName("Main", null);
                return storyboard;
            } set => storyboard = value; }

        public Dictionary<Type, Type> ViewControllerMap { get; }

        public Task GoBack()
        {
            // Todo: implement go back
            navigationController.PopViewController(true);

            return Task.CompletedTask;
        }

        public Task NavigateAsync<T>() where T : BaseViewModel
        {
            var controllerType = ViewControllerMap[typeof(T)];
            var controller = Storyboard.InstantiateViewController(controllerType.Name);
            navigationController.PushViewController(controller, true);
            return Task.CompletedTask;
        }
    }
}