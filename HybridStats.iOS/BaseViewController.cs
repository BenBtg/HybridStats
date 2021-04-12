using System;
using HybridStats.Core;
using UIKit;

namespace HybridStats.iOS
{
    public abstract class BaseViewController<T> : UIViewController where T : BaseViewModel
    {

        public T ViewModel { get; set; }

        public BaseViewController(IntPtr handle) : base (handle)
        {
            ViewModel = Activator.CreateInstance(typeof(T)) as T;
        }


        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            await ViewModel.InitAsync();

            InitView();
        }

        public override void ViewDidDisappear(bool animated)
        {

            ViewModel.ClearWatchers();

            base.ViewDidDisappear(animated);
        }

        public abstract void InitView();
    }
}
