using System;
using System.Collections.Generic;
using AR.TrapScorecard.Components.Constants;
using AR.TrapScorecard.Models.TrapShooter;
using AR.TrapScorecard.ViewCells.Shared;
using AR.TrapScorecard.ViewCells.TrapModifyScores;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AR.TrapScorecard.ViewControllers.TrapModifyScores
{
    public class TrapModifyScoresViewController : BaseModalViewController
    {
        #region - variables
        private IScoreModifiedDelegate Delegate;
        private List<TrapShooter> TrapShooters { get; set; }

        #endregion

        #region - constructor
        public TrapModifyScoresViewController(List<TrapShooter> trapShooters, IScoreModifiedDelegate modifiedDelegate) : base()
        {
            this.TrapShooters = trapShooters;
            this.Delegate = modifiedDelegate;
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

            SetupTrapModifyScoresViewController();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
        #endregion

        #region - private methods
        private void SetupTrapModifyScoresViewController()
        {
            SetupBaseModalViewController();
            var layout = new UICollectionViewFlowLayout();

            this.CollectionView.Delegate = new TrapShooterLayoutDelegate();

            CollectionView.RegisterClassForCell(typeof(TrapModifyScoresViewCell), TrapModifyScoresViewCell.Key);
            CollectionView.RegisterClassForCell(typeof(LabelViewCell), LabelViewCell.Key);

            this.CollectionView.DataSource = new TrapModifyScoresDataSource(this.TrapShooters, this.Delegate);
        }
        #endregion

        #region - public methods
        #endregion

    }

    public class TrapModifyScoresDataSource : UICollectionViewDataSource
    {
        #region - variables
        private IScoreModifiedDelegate Delegate;
        private int TotalShooters { get; set; }
        private List<TrapShooter> TrapShooters { get; set; }
        #endregion

        #region - constructor
        public TrapModifyScoresDataSource(List<TrapShooter> trapShooters, IScoreModifiedDelegate modifiedDelegate)
        {
            this.TotalShooters = trapShooters.Count;
            this.TrapShooters = trapShooters;
            this.Delegate = modifiedDelegate;
        }
        #endregion

        #region - life cycle methods
        #endregion

        #region - private methods
        private bool?[,] GetResultsFromScores(List<bool?> scores)
        {
            bool?[,] hitScores = new bool?[5, 5];
            for (int i = 0; i < 25; i++)
            {
                hitScores[i / 5, i % 5] = scores[i];
            }
            return hitScores;
        }
        #endregion

        #region - public methods
        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 2;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            switch (section)
            {
                case 0: return 1; //Header
                case 1: default: return this.TotalShooters; //Shooter Names
            }
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            switch (indexPath.Section)
            {
                case 0:
                    var trapLabel = (LabelViewCell)collectionView.DequeueReusableCell(LabelViewCell.Key, indexPath);
                    trapLabel.SetupLabelViewCell("Modify Scores:");
                    return trapLabel;
                case 1: default:
                    var trapResults = (TrapModifyScoresViewCell)collectionView.DequeueReusableCell(TrapModifyScoresViewCell.Key, indexPath);
                    trapResults.ButtonScoreClicked = (index) =>
                    {
                        TrapShooters[indexPath.Row].Score[index] = !TrapShooters[indexPath.Row].Score[index];
                        collectionView.ReloadItems(new NSIndexPath[] { indexPath });
                        if (this.Delegate != null) this.Delegate.ScoreChanged();
                    };
                    trapResults.SetupTrapResultsViewCell(this.TrapShooters[indexPath.Row].Name, GetResultsFromScores(this.TrapShooters[indexPath.Row].Score));
                    return trapResults;
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
                case 0: return new CGSize(width, 40);
                case 1: default: return new CGSize(width, 24 + (SizeConstants.TrapGridCell * 5));
            }

        }
    }

    public interface IScoreModifiedDelegate
    {
        void ScoreChanged();
    }
}

