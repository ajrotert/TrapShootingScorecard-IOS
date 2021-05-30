using System;
using System.Collections.Generic;
using AR.TrapScorecard.Components.Constants;
using AR.TrapScorecard.Models.TrapResults;
using AR.TrapScorecard.ViewCells.Shared;
using AR.TrapScorecard.ViewCells.TrapModifyScores;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AR.TrapScorecard.ViewControllers.PastTrapResults
{
    public class PastTrapResultsViewController : BaseModalViewController
    {
        #region - variables
        private int TrapId { get; set; }

        #endregion

        #region - constructor
        public PastTrapResultsViewController(int trapId) : base()
        {
            this.TrapId = trapId;
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

            SetupPastTrapResultsViewController();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
        #endregion

        #region - private methods
        private void SetupPastTrapResultsViewController()
        {
            SetupBaseModalViewController();

            this.CollectionView.Delegate = new PastTrapResultsLayoutDelegate();

            CollectionView.RegisterClassForCell(typeof(PastTrapRoundViewCell), PastTrapRoundViewCell.Key);
            CollectionView.RegisterClassForCell(typeof(LabelViewCell), LabelViewCell.Key);

            this.LoadData();
        }
        private void LoadData()
        {
            var pastTrapRound = Factory.DataHelper.GetPastRoundResults(this.TrapId);
            this.CollectionView.DataSource = new PastTrapResultsDataSource(pastTrapRound.Scores, pastTrapRound.Names, pastTrapRound.Time);
        }
        #endregion

        #region - public methods
        #endregion

    }

    public class PastTrapResultsDataSource : UICollectionViewDataSource
    {
        #region - variables
        private List<bool[,]> Scores { get; set; }
        private List<string> Names { get; set; }
        private DateTime Time { get; set; }

        #endregion

        #region - constructor
        public PastTrapResultsDataSource(List<bool[,]> scores, List<string> names, DateTime time)
        {
            this.Scores = scores;
            this.Names = names;
            this.Time = time;
        }
        #endregion

        #region - life cycle methods
        #endregion

        #region - private methods
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
                case 1: default: return this.Scores.Count;
            }
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            switch (indexPath.Section)
            {
                case 0:
                    var trapLabel = (LabelViewCell)collectionView.DequeueReusableCell(LabelViewCell.Key, indexPath);
                    trapLabel.SetupLabelViewCell($"Past Round: {this.Time}");
                    return trapLabel;
                case 1:
                default:
                    var trapResults = (PastTrapRoundViewCell)collectionView.DequeueReusableCell(PastTrapRoundViewCell.Key, indexPath);
                    trapResults.SetupPastTrapRoundViewCell(Names[indexPath.Row], Scores[indexPath.Row]);
                    return trapResults;
            }
        }
        #endregion

    }

    public class PastTrapResultsLayoutDelegate : UICollectionViewDelegateFlowLayout
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

