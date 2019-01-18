// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace AR.TrapScorecard
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton HitButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton MissButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider NumberOfShooterSlider { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel NumShootersLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton PauseButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView RedBox1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView RedBox2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView RedBox3 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView RedBox4 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView RedBox5 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ShooterNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton StartButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView TrapMapIV { get; set; }

        [Action ("Hit_Clicked:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Hit_Clicked (UIKit.UIButton sender);

        [Action ("Miss_Clicked:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Miss_Clicked (UIKit.UIButton sender);

        [Action ("Pause_Clicked:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Pause_Clicked (UIKit.UIButton sender);

        [Action ("Slider_Changed:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Slider_Changed (UIKit.UISlider sender);

        [Action ("Start_Clicked:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Start_Clicked (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (HitButton != null) {
                HitButton.Dispose ();
                HitButton = null;
            }

            if (MissButton != null) {
                MissButton.Dispose ();
                MissButton = null;
            }

            if (NumberOfShooterSlider != null) {
                NumberOfShooterSlider.Dispose ();
                NumberOfShooterSlider = null;
            }

            if (NumShootersLabel != null) {
                NumShootersLabel.Dispose ();
                NumShootersLabel = null;
            }

            if (PauseButton != null) {
                PauseButton.Dispose ();
                PauseButton = null;
            }

            if (RedBox1 != null) {
                RedBox1.Dispose ();
                RedBox1 = null;
            }

            if (RedBox2 != null) {
                RedBox2.Dispose ();
                RedBox2 = null;
            }

            if (RedBox3 != null) {
                RedBox3.Dispose ();
                RedBox3 = null;
            }

            if (RedBox4 != null) {
                RedBox4.Dispose ();
                RedBox4 = null;
            }

            if (RedBox5 != null) {
                RedBox5.Dispose ();
                RedBox5 = null;
            }

            if (ShooterNameLabel != null) {
                ShooterNameLabel.Dispose ();
                ShooterNameLabel = null;
            }

            if (StartButton != null) {
                StartButton.Dispose ();
                StartButton = null;
            }

            if (TrapMapIV != null) {
                TrapMapIV.Dispose ();
                TrapMapIV = null;
            }
        }
    }
}