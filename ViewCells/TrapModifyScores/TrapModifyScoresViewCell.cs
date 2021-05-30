using System;
using AR.TrapScorecard.Components.Constants;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AR.TrapScorecard.ViewCells.TrapModifyScores
{
    public class TrapModifyScoresViewCell : UICollectionViewCell
    {
        #region - variables
        public static readonly NSString Key = new NSString("TrapModifyScoresViewCell");

        private UILabel LabelName { get; set; }
        private UIButton[,] ButtonClays { get; set; }

        public Action<int> ButtonScoreClicked { get; set; }
        #endregion

        #region - constructor
        protected TrapModifyScoresViewCell(IntPtr handler) : base(handler)
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
        public void SetupTrapResultsViewCell(string shooterName, bool?[,] HitClays)
        {
            double padding = (this.Frame.Width / 2) - (SizeConstants.TrapGridCell * 2.5);
            if (LabelName == null)
                LabelName = new UILabel(new CGRect(0f, 0f, this.Frame.Width, 18f ));

            LabelName.Text = $"{shooterName}";
            LabelName.TextAlignment = UITextAlignment.Center;
            LabelName.TextColor = ColorConstants.TextColor;
            this.ContentView.AddSubview(LabelName);

            if (ButtonClays == null)
                ButtonClays = new UIButton[5, 5];

            double y = 24;
            double x;
            for (int row = 0; row < 5; row++)
            {
                x = padding;
                for (int i = 0; i < 5; i++)
                {
                    if (ButtonClays[row, i] == null)
                        ButtonClays[row, i] = new UIButton(new CGRect(x, y, SizeConstants.TrapGridCell, SizeConstants.TrapGridCell));

                    ButtonClays[row, i].BackgroundColor = ColorConstants.BackgroundColor;
                    ButtonClays[row, i].Layer.BorderColor = ColorConstants.PrimaryColor.CGColor;
                    ButtonClays[row, i].Layer.BorderWidth = 1;
                    ButtonClays[row, i].SetImage(HitClays[row, i] == null ? UIImage.FromBundle("NoClay") : HitClays[row, i].Value ? UIImage.FromBundle("HitClay") : UIImage.FromBundle("MissClay"), UIControlState.Normal);
                    ButtonClays[row, i].ContentMode = UIViewContentMode.ScaleAspectFill;
                    ButtonClays[row, i].Tag = row * 5 + i;
                    ButtonClays[row, i].Enabled = HitClays[row, i] != null;
                    ButtonClays[row, i].AddTarget(this, new ObjCRuntime.Selector("TrapModifyScoresViewCell_TouchUpInside:"), UIControlEvent.TouchDown);
                    this.ContentView.AddSubview(ButtonClays[row, i]);
                    x += SizeConstants.TrapGridCell;
                }
                y += SizeConstants.TrapGridCell;
            }
        }

        [Action("TrapModifyScoresViewCell_TouchUpInside:")]
        private void TrapModifyScoresViewCell_TouchUpInside(UIButton button)
        {
            if (this.ButtonScoreClicked != null) this.ButtonScoreClicked((int)button.Tag);
        }
        #endregion
    }
}