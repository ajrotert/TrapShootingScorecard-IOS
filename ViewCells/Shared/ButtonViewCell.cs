using System;
using AR.TrapScorecard.Components.Constants;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AR.TrapScorecard.ViewCells.Shared
{
    public class ButtonViewCell : UICollectionViewCell
    {
        #region - variables
        public static readonly NSString Key = new NSString("ButtonViewCell");
        public Action ButtonClicked { get; set; }

        #endregion

        #region - constructor
        protected ButtonViewCell(IntPtr handler) : base(handler)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        #endregion

        #region - life cycle methods
        #endregion

        #region - private methods
        #endregion

        #region - public methods
        public void SetupButtonViewCell(string title, float? height = null)
        {
            var nHeight = height == null ? this.Frame.Height : height.Value;
            var nY = (this.Frame.Height - nHeight) / 2;
            var button = new UIButton(new CGRect(0f, nY, this.Frame.Width, nHeight));
            button.BackgroundColor = ColorConstants.PrimaryColor;
            button.SetTitleColor(ColorConstants.BackgroundColor, UIControlState.Normal);
            button.SetTitle(title, UIControlState.Normal);
            button.Layer.CornerRadius = 5;
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
