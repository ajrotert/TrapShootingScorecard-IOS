using System;
using System.Collections.Generic;
using System.Linq;
using AR.TrapScorecard.Components.Constants;
using AR.TrapScorecard.ViewCells.Shared;
using AR.TrapScorecard.ViewCells.TrapRound;
using AR.TrapScorecard.ViewControllers.TrapModifyScores;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AR.TrapScorecard.ViewControllers.TrapRound
{
    public partial class TrapRoundViewController : BaseViewController
    {
        #region - variables
        private const int TabIndex = 1;
        private UICollectionView CollectionView { get; set; }
        private Models.TrapRound.TrapRound TrapRound { get; set; }
        private TrapRoundDataSource DataSource { get; set; }
        private bool IsExpanded { get; set; }

        #endregion

        #region - constructor
        public TrapRoundViewController(Models.TrapRound.TrapRound trapRound) : base(TabIndex)
        {
            this.TrapRound = trapRound;
        }
        #endregion

        #region - life cycle methods
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            SetupTrapRoundViewController();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
        #endregion

        #region - private methods
        private void SetupTrapRoundViewController()
        {
            var layout = new UICollectionViewFlowLayout();
            layout.ItemSize = new CGSize(this.View.Frame.Width - 20, 40);
            layout.ScrollDirection = UICollectionViewScrollDirection.Vertical;

            this.CollectionView = new UICollectionView(new CGRect(0f, 0f, 1f, 1f), layout);
            this.CollectionView.Delegate = new TrapRoundLayoutDelegate(this.TrapRound.Shooters.Count, this);
            this.CollectionView.BackgroundColor = ColorConstants.BackgroundColor;
            this.CollectionView.ContentInset = new UIEdgeInsets(0, 10, 0, 10);

            this.DataSource = new TrapRoundDataSource(this);
            this.CollectionView.DataSource = this.DataSource;

            this.View = CollectionView;

            CollectionView.RegisterClassForCell(typeof(TrapLayoutViewCell), TrapLayoutViewCell.Key);
            CollectionView.RegisterClassForCell(typeof(TrapShotsViewCell), TrapShotsViewCell.Key);
            CollectionView.RegisterClassForCell(typeof(TrapShotsExpandedViewCell), TrapShotsExpandedViewCell.Key);
            CollectionView.RegisterClassForCell(typeof(TrapButtonViewCell), TrapButtonViewCell.Key);
            CollectionView.RegisterClassForCell(typeof(LabelViewCell), LabelViewCell.Key);
            CollectionView.RegisterClassForCell(typeof(ButtonViewCell), ButtonViewCell.Key);

            BaseViewController.NamesViewController = null;
            BaseViewController.RoundViewController = this;

            this.LoadShooter();
        }
        private void End()
        {
            string csvRound = Factory.CSVHelper.GetCSVScoresForShooters(this.TrapRound.Shooters);
            string csvNames = Factory.CSVHelper.GetCSVNamesForShooters(this.TrapRound.Shooters);

            int trapId = Factory.DataHelper.AddRound(csvRound, csvNames);

            for (int i = this.TrapRound.Shooters.Count - 1; i >= 0; i--)
                Factory.DataHelper.Add(new Models.TrapResults.PastResults { Name = this.TrapRound.Shooters[i].Name, Score = this.TrapRound.Shooters[i].TotalHit, Date = DateTime.Now }, trapId);

            NavigateToTrapResults(this.TrapRound.Shooters);
            BaseViewController.RoundViewController = null;
        }
        private void UpdateRotation()
        {
            if(this.TrapRound.CurrentShooterIndex == 0)
            {
                if(this.TrapRound.CurrentShooter.CurrentShot >= 5 && this.TrapRound.CurrentShooter.CurrentShot % 5 == 0)
                {
                    this.TrapRound.CurrentRotation++;
                    if (this.TrapRound.CurrentRotation < 5) ShowRotateMessage();
                    else End();
                }
            }
        }
        private void LoadShooter()
        {
            int index = (this.TrapRound.CurrentShooterIndex + this.TrapRound.CurrentRotation) % 5;
            List<bool?> shots = this.TrapRound.CurrentShooter.Score.GetRange(this.TrapRound.CurrentRotation * 5, 5);
            this.DataSource.UpdateShooterIndex(index, this.TrapRound.CurrentShooter.Name, shots, this.IsExpanded);
            if (this.IsExpanded)
            {
                var names = new List<string>();
                var roundTotals = new List<List<bool?>>();
                this.TrapRound.Shooters.ForEach(s =>
                {
                    names.Add(s.Name);
                    roundTotals.Add(s.Score.GetRange(this.TrapRound.CurrentRotation * 5, 5));
                });
                this.DataSource.UpdateShootersRound(names, roundTotals);
            }
            this.CollectionView.ReloadData();
        }
        private void ShowRotateMessage()
        {
            string message = "";
            this.TrapRound.Shooters.ForEach(shooter =>
            {
                message += $"{shooter.Name}\t{shooter.Score.GetRange(shooter.CurrentShot-5, 5).Sum(x => { return x ?? false ? 1 : 0; })}" + Environment.NewLine;
            });
            ShowMessage("Rotate", message);
        }
        #endregion

        #region - public methods
        #endregion

    }
    public partial class TrapRoundViewController : TrapRoundDataSourceDelegate
    {
        public void ModifyScores()
        {
            UIViewController vc = new TrapModifyScoresViewController(this.TrapRound.Shooters, this);
            NavigateToModalViewController(vc);
        }

        public void ShooterShot(bool hit)
        {
            this.TrapRound.CurrentShooter.Score[this.TrapRound.CurrentShooter.CurrentShot] = hit;
            this.TrapRound.CurrentShooter.CurrentShot++;
            this.TrapRound.CurrentShooterIndex = (this.TrapRound.CurrentShooterIndex+1) %this.TrapRound.Shooters.Count;
            this.UpdateRotation();
            this.LoadShooter();
        }
    }
    public partial class TrapRoundViewController : TrapRoundDelegateDelegate
    {
        public void ExpandScores(bool expand)
        {
            this.IsExpanded = expand;
            this.LoadShooter();
        }
    }
    public partial class TrapRoundViewController : IScoreModifiedDelegate
    {
        public void ScoreChanged()
        {
            this.LoadShooter();
        }
    }

    public class TrapRoundDataSource : UICollectionViewDataSource
    {
        #region - variables
        private int ShooterIndex { get; set; }
        private string CurrentShooter { get; set; }
        private List<bool?> CurrentShooterRotationHits { get; set; }
        private TrapRoundDataSourceDelegate Delegate { get; set; }

        private bool IsExpanded { get; set; }
        private List<string> Names { get; set; }
        private List<List<bool?>> RoundScores { get; set; }
        #endregion

        #region - constructor
        public TrapRoundDataSource(TrapRoundDataSourceDelegate sourceDelegate)
        {
            this.Delegate = sourceDelegate;
        }
        #endregion

        #region - life cycle methods
        #endregion

        #region - private methods
        #endregion

        #region - public methods
        public void UpdateShooterIndex(int shooterIndex, string currentShooter, List<bool?> currentShooterRotationHits, bool isExpanded)
        {
            this.ShooterIndex = shooterIndex;
            this.CurrentShooter = currentShooter;
            this.CurrentShooterRotationHits = currentShooterRotationHits;
            this.IsExpanded = isExpanded;
        }
        public void UpdateShootersRound(List<string> names, List<List<bool?>> roundScores)
        {
            this.Names = names;
            this.RoundScores = roundScores;
        }
        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }
        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return 6;
        }
        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            switch (indexPath.Row)
            {
                case 0:
                    var trapLayout = (TrapLayoutViewCell)collectionView.DequeueReusableCell(TrapLayoutViewCell.Key, indexPath);
                    trapLayout.SetupTrapLayoutViewCell(this.ShooterIndex);
                    return trapLayout;
                case 1:
                    if (this.IsExpanded)
                    {
                        var trapShooter = (TrapShotsExpandedViewCell)collectionView.DequeueReusableCell(TrapShotsExpandedViewCell.Key, indexPath);
                        trapShooter.SetupTrapShotExpandedViewCell(this.Names, this.RoundScores);
                        return trapShooter;
                    }
                    else
                    {
                        var trapShooter = (TrapShotsViewCell)collectionView.DequeueReusableCell(TrapShotsViewCell.Key, indexPath);
                        trapShooter.SetupTrapShotsViewCell(CurrentShooterRotationHits);
                        return trapShooter;
                    }
                case 2:
                    var labelShooter = (LabelViewCell)collectionView.DequeueReusableCell(LabelViewCell.Key, indexPath);
                    labelShooter.SetupLabelViewCell(CurrentShooter);
                    return labelShooter;
                case 3:
                    var trapButtonHit = (TrapButtonViewCell)collectionView.DequeueReusableCell(TrapButtonViewCell.Key, indexPath);
                    trapButtonHit.ButtonClicked = () =>
                    {
                        if (this.Delegate != null) this.Delegate.ShooterShot(true);
                    };
                    trapButtonHit.SetupTrapButtonViewCell(ColorConstants.HitColor, "Hit");
                    return trapButtonHit;
                case 4:
                    var trapButtonLoss = (TrapButtonViewCell)collectionView.DequeueReusableCell(TrapButtonViewCell.Key, indexPath);
                    trapButtonLoss.SetupTrapButtonViewCell(ColorConstants.LossColor, "Loss");
                    trapButtonLoss.ButtonClicked = () =>
                    {
                        if (this.Delegate != null) this.Delegate.ShooterShot(false);
                    };
                    return trapButtonLoss;
                case 5:
                    var trapButtonModify = (ButtonViewCell)collectionView.DequeueReusableCell(ButtonViewCell.Key, indexPath);
                    trapButtonModify.SetupButtonViewCell("Modify/View Scores");
                    trapButtonModify.ButtonClicked = () =>
                    {
                        this.Delegate.ModifyScores();
                    };
                    return trapButtonModify;
                default:
                    return null;
            }
        }
        #endregion
    }

    public class TrapRoundLayoutDelegate : UICollectionViewDelegateFlowLayout
    {
        private bool IsExpanded { get; set; }
        private int TotalShooters { get; set; }
        private TrapRoundDelegateDelegate Delegate { get; set; }

        public TrapRoundLayoutDelegate(int totalShooters, TrapRoundDelegateDelegate delegateDelegate)
        {
            this.TotalShooters = totalShooters;
            this.Delegate = delegateDelegate;
        }

        public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            var width = collectionView.Frame.Width - (collectionView.ContentInset.Left + collectionView.ContentInset.Right);
            switch (indexPath.Row)
            {
                case 0: return new CGSize(width, 123);
                case 1: return new CGSize(width, IsExpanded ? 20 + (this.TotalShooters * SizeConstants.TrapGridCell): 20 + SizeConstants.TrapGridCell);
                case 3:
                case 4: return new CGSize(width, 90);
                case 5: return new CGSize(width, 40);
                default: return new CGSize(width, 60);
            }

        }
        [Foundation.Export("collectionView:didSelectItemAtIndexPath:")]
        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            if (indexPath.Row == 1)
            {
                IsExpanded = !IsExpanded;
                if (this.Delegate != null) this.Delegate.ExpandScores(this.IsExpanded);
            }
        }
    }

    public interface TrapRoundDataSourceDelegate
    {
        void ShooterShot(bool hit);
        void ModifyScores();
    }
    public interface TrapRoundDelegateDelegate
    {
        void ExpandScores(bool expand);
    }
}

