using System;
using System.Collections.Generic;
using AR.TrapScorecard.Components.Constants;
using AR.TrapScorecard.ViewControllers.TrapResults;
using AR.TrapScorecard.ViewControllers.TrapRound;
using AR.TrapScorecard.ViewControllers.TrapShooters;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AR.TrapScorecard.ViewControllers
{
    public partial class BaseViewController : UIViewController
    {
        #region - variables
        protected Factory.Factory Factory = new Factory.Factory();
        private UIStackView StackViewTitleButtons { get; set; }
        private UIButton[] ButtonTabs { get; set; }
        private int Tab { get; set; }

        protected static TrapShooterNamesViewController NamesViewController { get; set; }
        protected static TrapRoundViewController RoundViewController { get; set; }
        protected static TrapResultsViewController ResultsViewController { get; set; }
        #endregion

        #region - constructor
        public BaseViewController(string xibName) : base(xibName, null)
        {
        }
        public BaseViewController(int tab) : base(null, null)
        {
            this.Tab = tab;
            RegisterForKeyboardNotifications();
        }
        #endregion

        #region - life cycle methods
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            SetupBaseViewController();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            UnregisterForKeyboardNotifications();
        }
        #endregion

        #region - private methods
        protected void NavigateToTrapShooter()
        {
            UIViewController vc = NamesViewController;
            if (vc == null)
                vc = new TrapShooterNamesViewController();
            this.NavigationController.SetViewControllers(new UIViewController[] { vc }, true);
        }
        protected void NavigateToTrapRound(List<Models.TrapShooter.TrapShooter> trapShooters)
        {
            UIViewController vc = RoundViewController;
            if (vc == null)
                vc = new TrapRoundViewController(new Models.TrapRound.TrapRound
                {
                    Shooters = trapShooters,
                    CurrentShooterIndex = 0,
                    CurrentRotation = 0
                });
            this.NavigationController.SetViewControllers(new UIViewController[] { vc }, true);
        }
        protected void NavigateToTrapResults(List<Models.TrapShooter.TrapShooter> trapShooters = null)
        {
            UIViewController vc = ResultsViewController;
            if (vc == null)
                vc = new TrapResultsViewController(trapShooters);
            this.NavigationController.SetViewControllers(new UIViewController[] { vc }, true);
        }
        protected void NavigateToModalViewController(UIViewController viewController)
        {
            viewController.ModalPresentationStyle = UIModalPresentationStyle.PageSheet;
            this.NavigationController.PresentModalViewController(viewController, true);
        }
        protected void ShowMessage(string title, string message)
        {
            UIAlertView alert = new UIAlertView()
            {
                Title = title,
                Message = message
            };
            alert.AddButton("OK");
            alert.Show();
        }

        private void SetupBaseViewController()
        {
            ButtonTabs = new UIButton[3];

            ButtonTabs[0] = new UIButton();
            ButtonTabs[0].SetImage(UIImage.FromBundle("TrapShooterIcon").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate), UIControlState.Normal);
            ButtonTabs[0].ImageView.TintColor = ColorConstants.BackgroundColor;
            ButtonTabs[0].SetTitle("Names", UIControlState.Normal);
            ButtonTabs[0].ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            ButtonTabs[0].TitleLabel.Lines = 1;
            ButtonTabs[0].TitleLabel.AdjustsFontSizeToFitWidth = true;
            ButtonTabs[0].TitleLabel.LineBreakMode = UILineBreakMode.Clip;
            ButtonTabs[0].Layer.CornerRadius = 5;
            ButtonTabs[0].ContentEdgeInsets = new UIEdgeInsets(2, 5, 2, 5);
            ButtonTabs[0].TouchUpInside += TitleButton_TouchUpInside;

            ButtonTabs[1] = new UIButton();
            ButtonTabs[1].SetImage(UIImage.FromBundle("TrapRoundIcon").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate), UIControlState.Normal);
            ButtonTabs[1].ImageView.TintColor = ColorConstants.BackgroundColor;
            ButtonTabs[1].SetTitle("Trap Round", UIControlState.Normal);
            ButtonTabs[1].ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            ButtonTabs[1].TitleLabel.Lines = 1;
            ButtonTabs[1].TitleLabel.AdjustsFontSizeToFitWidth = true;
            ButtonTabs[1].TitleLabel.LineBreakMode = UILineBreakMode.Clip;
            ButtonTabs[1].Layer.CornerRadius = 5;
            ButtonTabs[1].ContentEdgeInsets = new UIEdgeInsets(2, 5, 2, 5);
            ButtonTabs[1].TouchUpInside += TitleButton_TouchUpInside;

            ButtonTabs[2] = new UIButton();
            ButtonTabs[2].SetImage(UIImage.FromBundle("TrapResultsIcon").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate), UIControlState.Normal);
            ButtonTabs[2].ImageView.TintColor = ColorConstants.BackgroundColor;
            ButtonTabs[2].SetTitle("Results", UIControlState.Normal);
            ButtonTabs[2].ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            ButtonTabs[2].TitleLabel.Lines = 1;
            ButtonTabs[2].TitleLabel.AdjustsFontSizeToFitWidth = true;
            ButtonTabs[2].TitleLabel.LineBreakMode = UILineBreakMode.Clip;
            ButtonTabs[2].Layer.CornerRadius = 5;
            ButtonTabs[2].ContentEdgeInsets = new UIEdgeInsets(2, 5, 2, 5);
            ButtonTabs[2].TouchUpInside += TitleButton_TouchUpInside;

            this.StackViewTitleButtons = new UIStackView(ButtonTabs);
            this.StackViewTitleButtons.Alignment = UIStackViewAlignment.Center;
            this.StackViewTitleButtons.Axis = UILayoutConstraintAxis.Horizontal;
            this.StackViewTitleButtons.Distribution = UIStackViewDistribution.FillProportionally;
            this.StackViewTitleButtons.Spacing = 10;

            this.ToggleButtons(this.ButtonTabs[Tab]);

            this.OverrideUserInterfaceStyle = UIUserInterfaceStyle.Light;

            base.NavigationItem.TitleView = StackViewTitleButtons;
        }

        private void ToggleButtons(UIButton selectedButton)
        {
            Array.ForEach(ButtonTabs, view =>
            {
                if (view is UIButton button)
                {
                    button.BackgroundColor = selectedButton == button ? ColorConstants.BackgroundColor : UIColor.Clear;
                    button.SetTitleColor(selectedButton == button ? ColorConstants.PrimaryColor : ColorConstants.BackgroundColor, UIControlState.Normal);
                    button.ImageView.TintColor = selectedButton == button ? ColorConstants.PrimaryColor : ColorConstants.BackgroundColor;
                }
            });
        }
        private void NavigateToView(UIButton button)
        {
            var selectedIndex = Array.FindIndex(ButtonTabs, x => x == button);

            if (Tab != selectedIndex)
            {
                switch (selectedIndex)
                {
                    case 0: NavigateToTrapShooter(); break;
                    case 1: if (RoundViewController != null) NavigateToTrapRound(null); else ShowMessage("Enter Names", "Press start to begin a trap round."); break;
                    case 2: NavigateToTrapResults(); break;
                };
            }
        }

        //UI Responders
        private void TitleButton_TouchUpInside(object sender, EventArgs e)
        {
            if (sender is UIButton selectedButton)
            {
                NavigateToView(selectedButton);
            }
        }
        #endregion

        #region - public methods
        #endregion


        #region Keyboard
        private void RegisterForKeyboardNotifications()
        {
            NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, OnKeyboardNotification);
            NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillShowNotification, OnKeyboardNotification);
        }
        private void UnregisterForKeyboardNotifications()
        {
            NSNotificationCenter.DefaultCenter.RemoveObserver(UIKeyboard.WillHideNotification);
            NSNotificationCenter.DefaultCenter.RemoveObserver(UIKeyboard.WillShowNotification);
        }

        private void OnKeyboardNotification(NSNotification notification)
        {
            if (!IsViewLoaded) return;

            var visible = notification.Name == UIKeyboard.WillShowNotification;

            var keyboardFrame = visible ? UIKeyboard.FrameEndFromNotification(notification) : UIKeyboard.FrameBeginFromNotification(notification);

            OnKeyboardChanged(visible, keyboardFrame.Height);
        }

        protected virtual void OnKeyboardChanged(bool visible, nfloat keyboardHeight)
        {
            if (this.View is UICollectionView collectionView)
            {
                if (visible)
                {
                    var contentInsets = new UIEdgeInsets(collectionView.ContentInset.Top, collectionView.ContentInset.Left, keyboardHeight, collectionView.ContentInset.Right);
                    collectionView.ContentInset = contentInsets;
                }
                else
                {
                    var contentInsets = new UIEdgeInsets(collectionView.ContentInset.Top, collectionView.ContentInset.Left, 0, collectionView.ContentInset.Right);
                    collectionView.ContentInset = contentInsets;
                }
            }
        }
        #endregion


    }

}