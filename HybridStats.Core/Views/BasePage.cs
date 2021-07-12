using System;
using HybridStats.Core.ViewModels;
using Xamarin.Forms;

namespace HybridStats.Core.Views
{
    public abstract class BasePage : ContentPage
    {
        public abstract BaseViewModel BaseViewModel { get;}
    }

    public abstract class BasePage<T> : BasePage where T : BaseViewModel
    {
        public override BaseViewModel BaseViewModel => ViewModel;

        public T ViewModel { get; set; }

        public BasePage()
        {
            ViewModel = Activator.CreateInstance(typeof(T)) as T;
            InitView();
        }

        public async virtual void InitView()
        {
            await ViewModel.InitAsync();
            BindingContext = ViewModel;
            Title = ViewModel.Title;
        }
    }
}