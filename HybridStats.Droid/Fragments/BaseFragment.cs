using System;
using AndroidX.Fragment.App;
using HybridStats.Core.ViewModels;

namespace HybridStats.Droid.Fragments
{
    public abstract class BaseFragment : Fragment
    {
        public abstract BaseViewModel BaseViewModel { get; }
    }

    public abstract class BaseFragment<T> : BaseFragment where T : BaseViewModel
    {
        public override BaseViewModel BaseViewModel => ViewModel;

        public T ViewModel { get; set; }

        public BaseFragment()
        {
            ViewModel = Activator.CreateInstance(typeof(T)) as T;
            InitView();
        }

        public async virtual void InitView()
        {
            await ViewModel.InitAsync();
        }
    }
}