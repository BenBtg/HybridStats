using System;
using HybridStats.Core;
using HybridStats.Core.ViewModels;
using UIKit;

namespace HybridStats.iOS
{
    public partial class FirstViewController : BaseViewController<FirstViewModel>
    {
        public FirstViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void InitView()
        {
            Title = ViewModel.Title;
        }

        partial void SecondClicked(UIKit.UIButton sender)
        {
            ViewModel.SecondNavigateCommand.Execute(null);
        }
    }
}

