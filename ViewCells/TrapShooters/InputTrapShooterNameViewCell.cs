using System;
using AR.TrapScorecard.Components.Constants;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AR.TrapScorecard.ViewCells.TrapShooters
{
    public partial class InputShooterNameViewCell : UICollectionViewCell
    {
        #region - variables
        public static readonly NSString Key = new NSString("InputShooterNameViewCell");
        public Action<string> ValueChanged { get; set; }
        private UITextField TextField { get; set; }
        #endregion

        #region - constructor
        protected InputShooterNameViewCell(IntPtr handler) : base(handler)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        #endregion

        #region - life cycle methods
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            TextField.EditingChanged -= Textbox_ValueChanged;
            TextField.EditingDidEnd -= TextField_EditingDidEnd;
        }
        #endregion

        #region - private methods
        #endregion

        #region - public methods
        public void SetupInputShooterNameViewCell(string placeholder, string text)
        {
            var padding = new UIView(new CGRect(0f, 0f, 8f, 8f));
            TextField = new UITextField(new CGRect(0f, 0f, this.Frame.Width, this.Frame.Height));
            TextField.BackgroundColor = ColorConstants.BackgroundColor;
            TextField.TextColor = ColorConstants.TextColor;
            TextField.Placeholder = placeholder;
            TextField.Text = text;
            TextField.AutocorrectionType = UITextAutocorrectionType.No;
            TextField.LeftView = padding;
            TextField.LeftViewMode = UITextFieldViewMode.Always;
            TextField.Layer.BorderWidth = 2f;
            TextField.Layer.CornerRadius = 5f;
            TextField.Layer.BorderColor = ColorConstants.PrimaryColor.CGColor;
            TextField.EditingChanged += Textbox_ValueChanged;
            TextField.EditingDidEnd += TextField_EditingDidEnd;

            this.ContentView.AddSubview(TextField);
        }

        private void TextField_EditingDidEnd(object sender, EventArgs e)
        {
            this.ResignFirstResponder();
        }

        private void Textbox_ValueChanged(object sender, EventArgs e)
        {
            if (sender is UITextField textField && this.ValueChanged != null) this.ValueChanged(textField.Text);
        }
        #endregion
    }
}
