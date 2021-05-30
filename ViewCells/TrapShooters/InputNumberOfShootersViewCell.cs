using System;
using AR.TrapScorecard.Components.Constants;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AR.TrapScorecard.ViewCells.TrapShooters
{
    public class InputNumberOfShootersViewCell : UICollectionViewCell
    {
        #region - variables
        public static readonly NSString Key = new NSString("InputNumberOfShootersViewCell");
        public Action<int> ValueChanged { get; set; }
        private int Value { get; set; }

        //private UIStackView StackView;
        //private UILabel TitleLabel;
        private UISlider Slider;

        #endregion

        #region - constructor
        protected InputNumberOfShootersViewCell(IntPtr handler) : base(handler)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        #endregion

        #region - life cycle methods
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            Slider.ValueChanged -= Slider_ValueChanged;
        }
        #endregion

        #region - private methods
        #endregion

        #region - public methods
        public void SetupInputNumberOfShootersViewCell(int value)
        {
            this.Value = value;
            //if(StackView == null)
            //{
            //    StackView = new UIStackView(new CGRect(0f, 0f, this.Frame.Width, this.Frame.Height));
            //    StackView.Axis = UILayoutConstraintAxis.Vertical;
            //}
            //if(TitleLabel == null)
            //{
            //    TitleLabel = new UILabel();
            //    TitleLabel.Text = "Trap Shooters:";
            //    TitleLabel.TextAlignment = UITextAlignment.Center;
            //    TitleLabel.TextColor = ColorConstants.PrimaryColor;
            //}
            if(Slider == null)
                Slider = new UISlider(new CGRect(0f, 0f, this.Frame.Width, this.Frame.Height));
            Slider.MinValue = 1;
            Slider.MaxValue = 5;
            Slider.TintColor = ColorConstants.PrimaryColor;
            Slider.MinimumTrackTintColor = ColorConstants.PrimaryColor;
            Slider.MaximumTrackTintColor = ColorConstants.TextColor;
            Slider.ValueChanged += Slider_ValueChanged;

            Slider.Value = this.Value;
            //StackView.AddArrangedSubview(TitleLabel);
            //StackView.AddArrangedSubview(Slider);
            this.ContentView.AddSubview(Slider);
        }

        private void Slider_ValueChanged(object sender, EventArgs e)
        {
            int value = 0; 
            if (sender is UISlider slider)
            {
                value = (int)Math.Round(slider.Value);
                slider.Value = value;
            }
            if (this.ValueChanged != null && value != this.Value)
            {
                this.ValueChanged(value);
                this.Value = value;
            }
        }
        #endregion
    }
}
