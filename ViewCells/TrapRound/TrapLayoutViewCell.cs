using System;
using AR.TrapScorecard.Components.Constants;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AR.TrapScorecard.ViewCells.TrapRound
{
    public class TrapLayoutViewCell : UICollectionViewCell
    {
        #region - variables
        public static readonly NSString Key = new NSString("TrapRound.TrapLayoutViewCell");

        private UIImageView ImageView;
        private UIStackView StackView;

        private UIImageView Shooter1 = new UIImageView(new CGRect(0f, 0f, 30, 30));
        private UIImageView Shooter2 = new UIImageView(new CGRect(0f, 0f, 30, 30));
        private UIImageView Shooter3 = new UIImageView(new CGRect(0f, 0f, 30, 30));
        private UIImageView Shooter4 = new UIImageView(new CGRect(0f, 0f, 30, 30));
        private UIImageView Shooter5 = new UIImageView(new CGRect(0f, 0f, 30, 30));
        #endregion

        #region - constructor
        protected TrapLayoutViewCell(IntPtr handler) : base(handler)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        #endregion

        #region - life cycle methods
        #endregion

        #region - private methods
        #endregion

        #region - public methods
        public void SetupTrapLayoutViewCell(int shooterPosition)
        {
            if (ImageView == null)
            {
                ImageView = new UIImageView(new CGRect(0f, 0f, this.Frame.Width, this.Frame.Height));
                ImageView.Image = UIImage.FromBundle("TrapLayout");
            }
            if (StackView == null)
            {
                StackView = new UIStackView(new CGRect(20f, 0f, this.Frame.Width - 40, this.Frame.Height / 1.25));
                StackView.Alignment = UIStackViewAlignment.Center;
                StackView.Axis = UILayoutConstraintAxis.Horizontal;
                StackView.Distribution = UIStackViewDistribution.EqualCentering;
            }

            Shooter1.Image = shooterPosition == 0 ? UIImage.FromBundle("TrapShooterIcon").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate) : null;
            Shooter1.TintColor = ColorConstants.PrimaryColor;
            StackView.AddArrangedSubview(Shooter1);

            Shooter2.Image = shooterPosition == 1 ? UIImage.FromBundle("TrapShooterIcon").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate) : null;
            Shooter2.TintColor = ColorConstants.PrimaryColor;
            StackView.AddArrangedSubview(Shooter2);

            Shooter3.Image = shooterPosition == 2 ? UIImage.FromBundle("TrapShooterIconAway").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate) : null;
            Shooter3.TintColor = ColorConstants.PrimaryColor;
            StackView.AddArrangedSubview(Shooter3);

            Shooter4.Image = shooterPosition == 3 ? UIImage.FromBundle("TrapShooterIconFlipped").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate) : null;
            Shooter4.TintColor = ColorConstants.PrimaryColor;
            StackView.AddArrangedSubview(Shooter4);

            Shooter5.Image = shooterPosition == 4 ? UIImage.FromBundle("TrapShooterIconFlipped").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate) : null;
            Shooter5.TintColor = ColorConstants.PrimaryColor;
            StackView.AddArrangedSubview(Shooter5);

            this.ContentView.AddSubview(ImageView);
            this.ContentView.AddSubview(StackView);
        }
        #endregion
    }
}
