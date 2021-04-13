using Foundation;
using HybridStats.Core;
using System;
using UIKit;

namespace HybridStats.iOS
{
    public partial class ViewController : BaseViewController<SecondViewModel>
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            ViewModel.WatchProperty(nameof(SecondViewModel.UserName), TitleChanged);
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        void TitleChanged()
        {
            NameLabel.Text = ViewModel.UserName;
            NextButton.TouchUpInside += NextButton_TouchUpInside;
        }

        private void NextButton_TouchUpInside(object sender, EventArgs e)
        {
            ViewModel.NextPageCommand?.Execute(null);
        }

        public override void InitView()
        {
            NameLabel.Text = ViewModel.UserName;
            TitleLabel.Text = ViewModel.Title;
        }
    }
}