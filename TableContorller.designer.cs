// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace AR.TrapScorecard
{
    [Register ("TableContorller")]
    partial class TableContorller
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView PastTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (PastTableView != null) {
                PastTableView.Dispose ();
                PastTableView = null;
            }
        }
    }
}