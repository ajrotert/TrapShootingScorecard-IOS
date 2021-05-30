using System;
using System.Collections.Generic;
using AR.TrapScorecard.Components.Constants;
using AR.TrapScorecard.Models.TrapShooter;
using AR.TrapScorecard.ViewCells.Shared;
using AR.TrapScorecard.ViewCells.TrapShooters;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AR.TrapScorecard.ViewControllers.TrapShooters
{
    public partial class TrapShooterNamesViewController : BaseViewController
    {
        #region - variables
        private const int TabIndex = 0;
        private UICollectionView CollectionView { get; set; }
        private List<TrapShooter> TrapShooters { get; set; }
        #endregion

        #region - constructor
        public TrapShooterNamesViewController() : base(TabIndex)
        {
        }
        #endregion

        #region - life cycle methods
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            SetupTrapShootersViewController();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
        #endregion

        #region - private methods
        private void SetupTrapShootersViewController()
        {
            BaseViewController.NamesViewController = this;

            var layout = new UICollectionViewFlowLayout();
            layout.ItemSize = new CGSize(this.View.Frame.Width-20, 40);
            layout.ScrollDirection = UICollectionViewScrollDirection.Vertical;
            layout.SectionInset = new UIEdgeInsets(0f, 0f, 10f, 0f);

            this.CollectionView = new UICollectionView(new CGRect(0f, 0f, 1f, 1f), layout);
            this.CollectionView.Delegate = new TrapShooterLayoutDelegate();
            this.CollectionView.BackgroundColor = ColorConstants.BackgroundColor;
            this.CollectionView.ContentInset = new UIEdgeInsets(0, 10, 0, 10);

            this.View = CollectionView;

            CollectionView.RegisterClassForCell(typeof(TrapLayoutViewCell), TrapLayoutViewCell.Key);
            CollectionView.RegisterClassForCell(typeof(InputShooterNameViewCell), InputShooterNameViewCell.Key);
            CollectionView.RegisterClassForCell(typeof(InputNumberOfShootersViewCell), InputNumberOfShootersViewCell.Key);
            CollectionView.RegisterClassForCell(typeof(ButtonViewCell), ButtonViewCell.Key);
            CollectionView.RegisterClassForCell(typeof(LabelViewCell), LabelViewCell.Key);

            this.View.AddGestureRecognizer(new UITapGestureRecognizer(() =>
            {
                this.View.EndEditing(true);
            }));

            this.LoadShooters();

            this.CollectionView.DataSource = new TrapShooterDataSource(this.TrapShooters, BaseViewController.RoundViewController == null ? "Start" : "Start a New Round", this);
        }

        private void LoadShooters()
        {
            this.TrapShooters = new List<TrapShooter>()
            {
                new TrapShooter(),
                new TrapShooter(),
                new TrapShooter(),
                new TrapShooter(),
                new TrapShooter()
            };
        }

        private void StartTrapRound(List<TrapShooter> trapShooters)
        {
            BaseViewController.RoundViewController = null;
            NavigateToTrapRound(trapShooters);
        }
        #endregion

        #region - public methods
        #endregion

    }
    public partial class TrapShooterNamesViewController : TrapShooterDataSourceDelegate
    {
        public void Start(int totalShooters)
        {
            var trapShooters = new List<TrapShooter>();
            for (int i = 0; i < totalShooters; i++)
            {
                trapShooters.Add(this.TrapShooters[i]);
                trapShooters[i].Name = string.IsNullOrWhiteSpace(trapShooters[i].Name) ? $"Shooter {i+1}" : trapShooters[i].Name;
            }
            StartTrapRound(trapShooters);
        }
    }

    public class TrapShooterDataSource : UICollectionViewDataSource
    {
        #region - variables
        private int TotalShooters { get; set; }
        private List<TrapShooter> TrapShooters { get; set; }
        private TrapShooterDataSourceDelegate Delegate { get; set; }
        private string ButtonTitle { get; set; }
        #endregion

        #region - constructor
        public TrapShooterDataSource(List<TrapShooter> trapShooters, string buttonTitle, TrapShooterDataSourceDelegate delegates)
        {
            this.TotalShooters = trapShooters.Count;
            this.TrapShooters = trapShooters;
            this.Delegate = delegates;
            this.ButtonTitle = buttonTitle;
        }
        #endregion

        #region - life cycle methods
        #endregion

        #region - private methods
        #endregion

        #region - public methods
        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 3;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            switch (section)
            {
                case 0: return 3; //Header
                case 1: return this.TotalShooters; //Shooter Names
                case 2: default: return 1; //Footer
            }
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            switch (indexPath.Section)
            {
                case 0:
                    switch (indexPath.Row)
                    {
                        case 0:
                            var trapLayout = (TrapLayoutViewCell)collectionView.DequeueReusableCell(TrapLayoutViewCell.Key, indexPath);
                            trapLayout.SetupTrapLayoutViewCell(this.TotalShooters);
                            return trapLayout;
                        case 1:
                            var trapLabel = (LabelViewCell)collectionView.DequeueReusableCell(LabelViewCell.Key, indexPath);
                            trapLabel.SetupLabelViewCell("Trap Shooters:");
                            return trapLabel;
                        case 2:
                        default:
                            var numShooters = (InputNumberOfShootersViewCell)collectionView.DequeueReusableCell(InputNumberOfShootersViewCell.Key, indexPath);

                            numShooters.ValueChanged = (value) =>
                            {
                                this.TotalShooters = value;
                                collectionView.ReloadData();
                            };

                            numShooters.SetupInputNumberOfShootersViewCell(this.TotalShooters);
                            return numShooters;
                    }
                case 1:
                    var inputNameCell = (InputShooterNameViewCell)collectionView.DequeueReusableCell(InputShooterNameViewCell.Key, indexPath);
                    inputNameCell.ValueChanged = (name) =>
                    {
                        this.TrapShooters[indexPath.Row].Name = name;
                    };
                    inputNameCell.SetupInputShooterNameViewCell($"Shooter {indexPath.Row + 1}", this.TrapShooters[indexPath.Row].Name);
                    return inputNameCell;
                case 2: default:
                    var footer = (ButtonViewCell)collectionView.DequeueReusableCell(ButtonViewCell.Key, indexPath);
                    footer.ButtonClicked = () =>
                    {
                        if (this.Delegate != null) this.Delegate.Start(this.TotalShooters);
                    };
                    footer.SetupButtonViewCell(this.ButtonTitle);
                    return footer;
            }
        }
        #endregion

    }

    public class TrapShooterLayoutDelegate : UICollectionViewDelegateFlowLayout
    {
        public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            var width = collectionView.Frame.Width - (collectionView.ContentInset.Left + collectionView.ContentInset.Right);
            switch (indexPath.Section)
            {
                case 0: return new CGSize(width, indexPath.Row == 0 ? 123 : 30);
                case 1: case 2: default: return new CGSize(width, 40);
            }
            
        }
    }

    public interface TrapShooterDataSourceDelegate
    {
        void Start(int totalShooters);
    }
}

