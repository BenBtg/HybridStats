using System;
using HybridStats.Core;
using UIKit;

namespace HybridStats.iOS
{
    public partial class SecondViewController : BaseViewController<SecondViewModel>
    {
        public SecondViewController() : base("SecondViewController", null)
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
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            ViewModel.WatchProperty(nameof(SecondViewModel.UserName), TitleChanged);
        }

        void TitleChanged()
        {
            this.NameLabel.Text = ViewModel.UserName;
        }

        public override void InitView()
        {
            NameLabel.Text = ViewModel.UserName;
            TitleLabel.Text = ViewModel.Title;
        }
    }
}

