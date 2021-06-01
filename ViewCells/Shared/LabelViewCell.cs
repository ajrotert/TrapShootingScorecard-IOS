using System;
using AR.TrapScorecard.Components.Constants;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AR.TrapScorecard.ViewCells.Shared
{
    public class LabelViewCell : UICollectionViewCell
    {
        #region - variables
        public static readonly NSString Key = new NSString("LabelViewCell");

        private UILabel LabelText { get; set; }
        #endregion

        #region - constructor
        protected LabelViewCell(IntPtr handler) : base(handler)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        #endregion

        #region - life cycle methods
        #endregion

        #region - private methods
        #endregion

        #region - public methods
        public void SetupLabelViewCell(string text = null, NSAttributedString attributedText = null)
        {
            if (LabelText == null)
                LabelText = new UILabel(new CGRect(0f, 0f, this.Frame.Width, this.Frame.Height));
            LabelText.Font = UIFont.PreferredTitle1;
            LabelText.Lines = 1;
            LabelText.AdjustsFontSizeToFitWidth = true;
            LabelText.LineBreakMode = UILineBreakMode.Clip;
            if(text != null)
            {
                LabelText.Text = text;
                LabelText.TextColor = ColorConstants.TextColor;
            }
            else if(attributedText != null)
            {
                LabelText.AttributedText = attributedText;
            }

            LabelText.TextAlignment = UITextAlignment.Center;
            LabelText.ContentMode = UIViewContentMode.Bottom;

            this.ContentView.AddSubview(LabelText);
        }
        #endregion
    }
}