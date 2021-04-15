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
	[Register ("SecondViewController")]
	partial class SecondViewController
	{
		[Outlet]
		UIKit.UINavigationItem TitleLabel { get; set; }

		[Action ("NextClicked:")]
		partial void NextClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (TitleLabel != null) {
				TitleLabel.Dispose ();
				TitleLabel = null;
			}
		}
	}
}
