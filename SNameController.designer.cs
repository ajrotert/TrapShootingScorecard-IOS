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
    [Register ("SNameController")]
    partial class SNameController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FiveLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FourLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel OneLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField ShooterTextBox1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField ShooterTextBox2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField ShooterTextBox3 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField ShooterTextBox4 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField ShooterTextBox5 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ThreeLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TwoLabel { get; set; }

        [Action ("Shooter1_Changed:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Shooter1_Changed (UIKit.UITextField sender);

        [Action ("Shooter2_Changed:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Shooter2_Changed (UIKit.UITextField sender);

        [Action ("Shooter3_Changed:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Shooter3_Changed (UIKit.UITextField sender);

        [Action ("Shooter4_Changed:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Shooter4_Changed (UIKit.UITextField sender);

        [Action ("Shooter5_Changed:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Shooter5_Changed (UIKit.UITextField sender);

        void ReleaseDesignerOutlets ()
        {
            if (FiveLabel != null) {
                FiveLabel.Dispose ();
                FiveLabel = null;
            }

            if (FourLabel != null) {
                FourLabel.Dispose ();
                FourLabel = null;
            }

            if (OneLabel != null) {
                OneLabel.Dispose ();
                OneLabel = null;
            }

            if (ShooterTextBox1 != null) {
                ShooterTextBox1.Dispose ();
                ShooterTextBox1 = null;
            }

            if (ShooterTextBox2 != null) {
                ShooterTextBox2.Dispose ();
                ShooterTextBox2 = null;
            }

            if (ShooterTextBox3 != null) {
                ShooterTextBox3.Dispose ();
                ShooterTextBox3 = null;
            }

            if (ShooterTextBox4 != null) {
                ShooterTextBox4.Dispose ();
                ShooterTextBox4 = null;
            }

            if (ShooterTextBox5 != null) {
                ShooterTextBox5.Dispose ();
                ShooterTextBox5 = null;
            }

            if (ThreeLabel != null) {
                ThreeLabel.Dispose ();
                ThreeLabel = null;
            }

            if (TwoLabel != null) {
                TwoLabel.Dispose ();
                TwoLabel = null;
            }
        }
    }
}