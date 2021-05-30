using System;
using AR.TrapScorecard.Components.Constants;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AR.TrapScorecard.ViewControllers
{
    public class BaseModalViewController : UIViewController
    {
        #region - variables
        protected Factory.Factory Factory = new Factory.Factory();
        protected UICollectionView CollectionView { get; set; }

        #endregion

        #region - constructor
        public BaseModalViewController() : base()
        {
        }
        #endregion

        #region - life cycle methods
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
        #endregion

        #region - private methods
        protected void SetupBaseModalViewController()
        {
            var layout = new UICollectionViewFlowLayout();
            layout.ItemSize = new CGSize(this.View.Frame.Width - 20, 40);
            layout.ScrollDirection = UICollectionViewScrollDirection.Vertical;
            layout.SectionInset = new UIEdgeInsets(0f, 0f, 10f, 0f);

            this.CollectionView = new UICollectionView(new CGRect(0f, 40f, this.View.Frame.Width, this.View.Frame.Height - 40), layout);
            this.CollectionView.BackgroundColor = ColorConstants.BackgroundColor;
            this.CollectionView.ContentInset = new UIEdgeInsets(20, 10, 0, 10);

            UIView view = new UIView(new CGRect(0f, 0f, this.View.Frame.Width, 40f));
            view.BackgroundColor = ColorConstants.PrimaryColor;

            UIButton button = new UIButton(new CGRect(0f, 0f, 40f, 40f));
            button.SetTitle("X", UIControlState.Normal);
            button.TitleLabel.Font = UIFont.PreferredTitle1;
            button.TitleLabel.LineBreakMode = UILineBreakMode.Clip;
            button.TitleLabel.Lines = 1;
            button.TitleLabel.AdjustsFontSizeToFitWidth = true;
            button.SetTitleColor(ColorConstants.BackgroundColor, UIControlState.Normal);
            button.TouchUpInside += (o, e) =>
            {
                this.DismissModalViewController(true);
            };

            view.AddSubview(button);

            this.View.AddSubview(view);
            this.View.AddSubview(this.CollectionView);
        }
        #endregion

        #region - public methods
        #endregion

    }
}
