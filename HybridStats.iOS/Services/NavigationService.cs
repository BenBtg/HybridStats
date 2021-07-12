using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using HybridStats.Core;
using HybridStats.Core.Services;
using HybridStats.Core.ViewModels;
using HybridStats.Core.Views;
using UIKit;
using Xamarin.Forms.Platform.iOS;

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
            
            if (controllerType.IsSubclassOf(typeof(BasePage<T>)))
            {
                Debug.WriteLine("Is Forms page!");

                var formPage = Activator.CreateInstance(controllerType) as BasePage<T>;
                     
                var formsController = formPage.CreateViewController();
                formsController.Title = formPage.Title;
                navigationController.PushViewController(formsController, true);
            }
            else
            {
                var controller = Storyboard.InstantiateViewController(controllerType.Name);
                navigationController.PushViewController(controller, true);
            }

            return Task.CompletedTask;
        }
    }
}