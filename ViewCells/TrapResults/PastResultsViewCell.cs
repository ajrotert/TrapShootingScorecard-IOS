using System;
using AR.TrapScorecard.Components.Constants;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AR.TrapScorecard.ViewCells.TrapResults
{
    public class PastResultsViewCell : UICollectionViewCell
    {
        #region - variables
        public static readonly NSString Key = new NSString("PastResultsViewCell");

        public Action ButtonDeleteClicked { get; set; }
        public Action ButtonViewRoundClicked { get; set; }

        private UIStackView StackView { get; set; }
        private UILabel LabelName { get; set; }
        private UILabel LabelDate { get; set; }
        private UIButton ButtonClays { get; set; }
        private UIButton ButtonDelete { get; set; }
        private UIButton ButtonRound { get; set; }
        private UIScrollView ScrollView { get; set; }
        #endregion

        #region - constructor
        protected PastResultsViewCell(IntPtr handler) : base(handler)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        #endregion

        #region - life cycle methods
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            ButtonDelete.TouchUpInside -= ButtonDelete_TouchUpInside;
            ButtonRound.TouchUpInside -= ButtonViewRound_Clicked;
        }
        #endregion

        #region - private methods
        #endregion

        #region - public methods
        public void SetupPastResultsViewCell(string shooterName, int totalHit, string date, bool hasRound)
        {
            if (StackView == null)
                StackView = new UIStackView(new CGRect(0f, 0f, this.Frame.Width, this.Frame.Height));
            StackView.Alignment = UIStackViewAlignment.Center;
            StackView.Axis = UILayoutConstraintAxis.Horizontal;
            StackView.Distribution = UIStackViewDistribution.FillEqually;
            StackView.Spacing = 10;

            if (LabelName == null)
                LabelName = new UILabel(new CGRect(0f, 10f, this.Frame.Width, 18f));
            LabelName.Text = shooterName;
            LabelName.TextAlignment = UITextAlignment.Left;
            LabelName.TextColor = ColorConstants.TextColor;
            LabelName.Lines = 1;
            LabelName.LineBreakMode = UILineBreakMode.Clip;
            LabelName.AdjustsFontSizeToFitWidth = true;

            if (ButtonClays == null)
                ButtonClays = new UIButton(new CGRect(0f, 0f, this.Frame.Width, 50f));
            ButtonClays.ImageEdgeInsets = new UIEdgeInsets(0, 0, 0, 0);
            ButtonClays.ContentEdgeInsets = new UIEdgeInsets(0, 0, 0, 0);
            ButtonClays.BackgroundColor = ColorConstants.BackgroundColor;
            ButtonClays.SetImage(UIImage.FromBundle("HitClay"), UIControlState.Disabled);
            ButtonClays.ContentMode = UIViewContentMode.ScaleAspectFit;
            ButtonClays.SetTitle($"x {totalHit}", UIControlState.Normal);
            ButtonClays.SetTitleColor(ColorConstants.PrimaryColor, UIControlState.Disabled);
            ButtonClays.Enabled = false;

            if (ButtonRound == null)
                ButtonRound = new UIButton(new CGRect(this.Frame.Width + 10, 0f, 120f, this.Frame.Height));
            ButtonRound.ImageEdgeInsets = new UIEdgeInsets(0, 0, 0, 0);
            ButtonRound.ContentEdgeInsets = new UIEdgeInsets(0, 0, 0, 0);
            ButtonRound.BackgroundColor = ColorConstants.HitColor;
            ButtonRound.SetTitle("View Round", UIControlState.Normal);
            ButtonRound.SetTitleColor(ColorConstants.BackgroundColor, UIControlState.Normal);
            ButtonRound.TouchUpInside += ButtonViewRound_Clicked;

            if (ButtonDelete == null)
                ButtonDelete = new UIButton();
            ButtonDelete.Frame = new CGRect(this.Frame.Width + (hasRound ? 140 : 10), 0f, 120f, this.Frame.Height);
            ButtonDelete.ImageEdgeInsets = new UIEdgeInsets(0, 0, 0, 0);
            ButtonDelete.ContentEdgeInsets = new UIEdgeInsets(0, 0, 0, 0);
            ButtonDelete.BackgroundColor = ColorConstants.LossColor;
            ButtonDelete.SetTitle("Delete", UIControlState.Normal);
            ButtonDelete.SetTitleColor(ColorConstants.BackgroundColor, UIControlState.Normal);
            ButtonDelete.TouchUpInside += ButtonDelete_TouchUpInside;

            if (LabelDate == null)
                LabelDate = new UILabel(new CGRect(0f, 10f, this.Frame.Width, 18f));
            LabelDate.Text = date;
            LabelDate.TextAlignment = UITextAlignment.Right;
            LabelDate.TextColor = ColorConstants.TextColor;
            LabelDate.Lines = 1;
            LabelDate.LineBreakMode = UILineBreakMode.Clip;
            LabelDate.AdjustsFontSizeToFitWidth = true;

            StackView.AddArrangedSubview(LabelName);
            StackView.AddArrangedSubview(ButtonClays);
            StackView.AddArrangedSubview(LabelDate);

            if (ScrollView == null)
                ScrollView = new UIScrollView(new CGRect(0f, 0f, this.Frame.Width, this.Frame.Height));
            ScrollView.ShowsHorizontalScrollIndicator = false;
            ScrollView.ContentSize = new CGSize(this.Frame.Width + (hasRound ? 260f : 130f), this.Frame.Height);
            ScrollView.SetContentOffset(new CGPoint(0f, 0f), false);

            ScrollView.AddSubview(StackView);
            if(hasRound) ScrollView.AddSubview(ButtonRound);
            ScrollView.AddSubview(ButtonDelete);

            this.ContentView.AddSubview(ScrollView);
        }

        private void ButtonDelete_TouchUpInside(object sender, EventArgs e)
        {
            if (this.ButtonDeleteClicked != null) ButtonDeleteClicked();
        }

        private void ButtonViewRound_Clicked(object sender, EventArgs e)
        {
            if (this.ButtonViewRoundClicked != null) ButtonViewRoundClicked();
        }
        #endregion
    }
}