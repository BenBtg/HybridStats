// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace HybridStats.iOS
{
	[Register ("FirstViewController")]
	partial class FirstViewController
	{
		[Outlet]
		UIKit.UINavigationItem TitleLabel { get; set; }

		[Action ("SecondClicked:")]
		partial void SecondClicked (UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (TitleLabel != null) {
				TitleLabel.Dispose ();
				TitleLabel = null;
			}
		}
	}
}
