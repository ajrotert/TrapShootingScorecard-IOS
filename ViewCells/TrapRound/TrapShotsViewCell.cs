using System;
using System.Collections.Generic;
using AR.TrapScorecard.Components.Constants;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AR.TrapScorecard.ViewCells.TrapRound
{
    public class TrapShotsViewCell : UICollectionViewCell
    {
        #region - variables
        public static readonly NSString Key = new NSString("TrapShotsViewCell");

        private UIButton[] ButtonClays { get; set; }
        private UIImageView ButtonDropdown { get; set; }
        #endregion

        #region - constructor
        protected TrapShotsViewCell(IntPtr handler) : base(handler)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        #endregion

        #region - life cycle methods
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        #endregion

        #region - private methods
        #endregion

        #region - public methods
        public void SetupTrapShotsViewCell(List<bool?> HitClays)
        {
            double padding = (this.Frame.Width / 2) - (SizeConstants.TrapGridCell * 2.5);
            var paddingDropdown = (this.Frame.Width / 2) - 5;

            if (ButtonClays == null)
                ButtonClays = new UIButton[5];

            double x = padding;
            for (int i = 0; i < 5; i++)
            {
                if(ButtonClays[i] == null)
                    ButtonClays[i] = new UIButton(new CGRect(x, 0f, SizeConstants.TrapGridCell, SizeConstants.TrapGridCell));

                ButtonClays[i].BackgroundColor = ColorConstants.BackgroundColor;
                ButtonClays[i].Layer.BorderColor = ColorConstants.PrimaryColor.CGColor;
                ButtonClays[i].Layer.BorderWidth = 1;
                ButtonClays[i].SetImage(HitClays[i] == null ? UIImage.FromBundle("NoClay") : HitClays[i].Value ? UIImage.FromBundle("HitClay") : UIImage.FromBundle("MissClay"), UIControlState.Disabled);
                ButtonClays[i].ContentMode = UIViewContentMode.ScaleAspectFit;
                ButtonClays[i].Enabled = false;
                this.ContentView.AddSubview(ButtonClays[i]);
                x += SizeConstants.TrapGridCell;
            }

            if (ButtonDropdown == null)
                ButtonDropdown = new UIImageView(new CGRect(paddingDropdown, this.Frame.Height-10, 10, 10));

            ButtonDropdown.Image = (UIImage.FromBundle("dropdown"));
            this.ContentView.AddSubview(ButtonDropdown);
        }

        #endregion
    }
}