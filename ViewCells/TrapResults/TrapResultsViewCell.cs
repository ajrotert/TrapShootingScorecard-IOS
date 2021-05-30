using System;
using System.Collections.Generic;
using AR.TrapScorecard.Components.Constants;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AR.TrapScorecard.ViewCells.TrapResults
{
    public class TrapResultsViewCell : UICollectionViewCell
    {
        #region - variables
        public static readonly NSString Key = new NSString("TrapResultsViewCell");

        private UILabel LabelName { get; set; }
        private UIButton ButtonClaysTotal { get; set; }
        private UIButton[,] ButtonClays { get; set; }
        #endregion

        #region - constructor
        protected TrapResultsViewCell(IntPtr handler) : base(handler)
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
        public void SetupTrapResultsViewCell(string shooterName, int totalHit, bool[,] HitClays)
        {
            double padding = (this.Frame.Width / 2) - (SizeConstants.TrapGridCell * 2.5);

            if (LabelName == null)
                LabelName = new UILabel(new CGRect(0f, 0f, this.Frame.Width, 18f));

            LabelName.Text = $"{shooterName}";
            LabelName.TextAlignment = UITextAlignment.Center;
            LabelName.TextColor = ColorConstants.TextColor;
            this.ContentView.AddSubview(LabelName);

            if (ButtonClaysTotal == null)
                ButtonClaysTotal = new UIButton(new CGRect(0f, (this.Frame.Height/2) - 12, padding, 50f));
            ButtonClaysTotal.ImageEdgeInsets = new UIEdgeInsets(0, 0, 0, 0);
            ButtonClaysTotal.ContentEdgeInsets = new UIEdgeInsets(0, 0, 0, 0);
            ButtonClaysTotal.BackgroundColor = ColorConstants.BackgroundColor;
            ButtonClaysTotal.SetImage(UIImage.FromBundle("HitClay"), UIControlState.Disabled);
            ButtonClaysTotal.ContentMode = UIViewContentMode.ScaleAspectFit;
            ButtonClaysTotal.SetTitle($"x {totalHit}", UIControlState.Normal);
            ButtonClaysTotal.SetTitleColor(ColorConstants.PrimaryColor, UIControlState.Disabled);
            ButtonClaysTotal.Enabled = false;
            this.ContentView.AddSubview(ButtonClaysTotal);


            if (ButtonClays == null)
                ButtonClays = new UIButton[5,5];

            double y = 24;
            double x;
            for (int row = 0; row < 5; row++)
            {
                x = padding;
                for (int i = 0; i < 5; i++)
                {
                    if (ButtonClays[row,i] == null)
                        ButtonClays[row, i] = new UIButton(new CGRect(x, y, SizeConstants.TrapGridCell, SizeConstants.TrapGridCell));

                    ButtonClays[row, i].BackgroundColor = ColorConstants.BackgroundColor;
                    ButtonClays[row, i].Layer.BorderColor = ColorConstants.PrimaryColor.CGColor;
                    ButtonClays[row, i].Layer.BorderWidth = 1;
                    ButtonClays[row, i].SetImage(HitClays[row, i] ? UIImage.FromBundle("HitClay") : UIImage.FromBundle("MissClay"), UIControlState.Disabled);
                    ButtonClays[row, i].ContentMode = UIViewContentMode.ScaleAspectFit;
                    ButtonClays[row, i].Enabled = false;
                    this.ContentView.AddSubview(ButtonClays[row, i]);
                    x += SizeConstants.TrapGridCell;
                }
                y += SizeConstants.TrapGridCell;
            }
        }
        #endregion
    }
}