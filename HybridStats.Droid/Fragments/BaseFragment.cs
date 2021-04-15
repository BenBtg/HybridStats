using System;
using Android.OS;
using Android.Views;
using AndroidX.Fragment.App;
using HybridStats.Core;

namespace HybridStats.Droid.Fragments
{
    public class BaseFragment<T> : Fragment where T : BaseViewModel
    {
        public T ViewModel { get; set; }

        public override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ViewModel = Activator.CreateInstance(typeof(T)) as T;

            await ViewModel.InitAsync();

            this.Activity.Title = ViewModel.Title;
        }
    }
}
