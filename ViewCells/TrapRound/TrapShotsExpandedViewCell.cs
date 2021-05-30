using System;
using System.Collections.Generic;
using AR.TrapScorecard.Components.Constants;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AR.TrapScorecard.ViewCells.TrapRound
{
    public class TrapShotsExpandedViewCell : UICollectionViewCell
    {
        #region - variables
        public static readonly NSString Key = new NSString("TrapShotsExpandedViewCell");

        private UILabel[] LabelNames { get; set; }
        private UIButton[,] ButtonClays { get; set; }
        private UIImageView ButtonDropup { get; set; }
        #endregion

        #region - constructor
        protected TrapShotsExpandedViewCell(IntPtr handler) : base(handler)
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
        public void SetupTrapShotExpandedViewCell(List<string> names, List<List<bool?>> roundScores)
        {
            double padding = (this.Frame.Width / 2) - (SizeConstants.TrapGridCell * 2.5);
            var paddingDropup = (this.Frame.Width / 2) - 5;

            if (ButtonClays == null)
                ButtonClays = new UIButton[5, 5];

            if (LabelNames == null)
                LabelNames = new UILabel[5];

            double y = 0;
            double x;

            for (int row = 0; row < names.Count; row++)
            {
                x = padding;

                if(LabelNames[row] == null)
                    LabelNames[row] = new UILabel(new CGRect(0f, y, padding, SizeConstants.TrapGridCell));

                LabelNames[row].TextColor = ColorConstants.TextColor;
                LabelNames[row].TextAlignment = UITextAlignment.Left;
                LabelNames[row].Text = names[row];
                LabelNames[row].Lines = 1;
                LabelNames[row].AdjustsFontSizeToFitWidth = true;
                LabelNames[row].LineBreakMode = UILineBreakMode.Clip;
                this.ContentView.AddSubview(LabelNames[row]);

                for (int i = 0; i < 5; i++)
                {
                    if (ButtonClays[row, i] == null)
                        ButtonClays[row, i] = new UIButton(new CGRect(x, y, SizeConstants.TrapGridCell, SizeConstants.TrapGridCell));

                    ButtonClays[row, i].BackgroundColor = ColorConstants.BackgroundColor;
                    ButtonClays[row, i].Layer.BorderColor = ColorConstants.PrimaryColor.CGColor;
                    ButtonClays[row, i].Layer.BorderWidth = 1;
                    ButtonClays[row, i].SetImage(roundScores[row][i] == null ? UIImage.FromBundle("NoClay") : roundScores[row][i].Value ? UIImage.FromBundle("HitClay") : UIImage.FromBundle("MissClay"), UIControlState.Disabled);
                    ButtonClays[row, i].Enabled = false;
                    ButtonClays[row, i].ContentMode = UIViewContentMode.ScaleAspectFit;
                    this.ContentView.AddSubview(ButtonClays[row, i]);
                    x += SizeConstants.TrapGridCell;
                }
                y += SizeConstants.TrapGridCell;
            }

            if (ButtonDropup == null)
                ButtonDropup = new UIImageView(new CGRect(paddingDropup, this.Frame.Height-10f, 10, 10));

            ButtonDropup.Image = (UIImage.FromBundle("dropup"));

            this.ContentView.AddSubview(ButtonDropup);
        }
        #endregion
    }
}