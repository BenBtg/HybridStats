using System;
using HybridStats.Core;
using UIKit;

namespace HybridStats.iOS
{
    public partial class SecondViewController : BaseViewController<SecondViewModel>
    {
        public SecondViewController(IntPtr handle) : base(handle)
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

        }



        public override void InitView()
        {

        }

    }
}

