using System;
using AR.TrapScorecard.Components.Constants;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AR.TrapScorecard.ViewCells.TrapRound
{
    public class TrapButtonViewCell : UICollectionViewCell
    {
        #region - variables
        public static readonly NSString Key = new NSString("TrapButtonViewCell");
        public Action ButtonClicked { get; set; }

        #endregion

        #region - constructor
        protected TrapButtonViewCell(IntPtr handler) : base(handler)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        #endregion

        #region - life cycle methods
        #endregion

        #region - private methods
        #endregion

        #region - public methods
        public void SetupTrapButtonViewCell(UIColor color, string title)
        {
            var button = new UIButton(new CGRect(0f, 0f, this.Frame.Width, this.Frame.Height));
            button.BackgroundColor = ColorConstants.BackgroundColor;
            button.SetTitleColor(color, UIControlState.Normal);
            button.SetTitle(title, UIControlState.Normal);
            button.Layer.CornerRadius = 5;
            button.Layer.BorderColor = color.CGColor;
            button.Layer.BorderWidth = 2;
            button.TouchUpInside += Button_TouchUpInside;

            this.ContentView.AddSubview(button);
        }

        private void Button_TouchUpInside(object sender, EventArgs e)
        {
            if (this.ButtonClicked != null) ButtonClicked();
        }
        #endregion
    }
}
