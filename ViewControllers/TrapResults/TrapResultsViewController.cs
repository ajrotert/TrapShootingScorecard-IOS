using System;
using System.Collections.Generic;
using AR.TrapScorecard.Components.Constants;
using AR.TrapScorecard.Models.TrapResults;
using AR.TrapScorecard.Models.TrapShooter;
using AR.TrapScorecard.ViewCells.Shared;
using AR.TrapScorecard.ViewCells.TrapResults;
using AR.TrapScorecard.ViewControllers.PastTrapResults;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AR.TrapScorecard.ViewControllers.TrapResults
{
    public partial class TrapResultsViewController : BaseViewController
    {
        #region - variables
        private const int TabIndex = 2;
        private UICollectionView CollectionView { get; set; }
        private TrapResultsDataSource DataSource { get; set; }
        private List<TrapShooter> TrapShooters { get; set; }
        #endregion

        #region - constructor
        public TrapResultsViewController(List<TrapShooter> trapShooters = null) : base(TabIndex)
        {
            if (trapShooters == null)
                trapShooters = new List<TrapShooter>();
            this.TrapShooters = trapShooters;
        }
        #endregion

        #region - life cycle methods
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            SetupTrapResultsViewController();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
        #endregion

        #region - private methods
        private void SetupTrapResultsViewController()
        {
            var layout = new UICollectionViewFlowLayout();
            layout.ItemSize = new CGSize(this.View.Frame.Width - 20, 40);
            layout.ScrollDirection = UICollectionViewScrollDirection.Vertical;
            layout.SectionInset = new UIEdgeInsets(0f, 0f, 10f, 0f);

            this.CollectionView = new UICollectionView(new CGRect(0f, 0f, 1f, 1f), layout);
            this.CollectionView.Delegate = new TrapResultsLayoutDelegate();
            this.CollectionView.BackgroundColor = ColorConstants.BackgroundColor;
            this.CollectionView.ContentInset = new UIEdgeInsets(10, 10, 0, 10);

            this.View = CollectionView;

            CollectionView.RegisterClassForCell(typeof(TrapResultsViewCell), TrapResultsViewCell.Key);
            CollectionView.RegisterClassForCell(typeof(ButtonViewCell), ButtonViewCell.Key);
            CollectionView.RegisterClassForCell(typeof(LabelViewCell), LabelViewCell.Key);
            CollectionView.RegisterClassForCell(typeof(PastResultsViewCell), PastResultsViewCell.Key);

            this.LoadData();
        }

        private void LoadData()
        {
            var results = Factory.DataHelper.GetPastResults();
            this.DataSource = new TrapResultsDataSource(this.TrapShooters, results, this);
            this.CollectionView.DataSource = this.DataSource;
        }

        private async void SendEmail()
        {
            var csv = Factory.CSVHelper.GetCSVForShooters(this.TrapShooters);
            var email = Factory.EmailHelper.GetEmailMessage(csv);
            await Xamarin.Essentials.Email.ComposeAsync(email);
        }

        #endregion

        #region - public methods
        #endregion

    }
    public partial class TrapResultsViewController : TrapResultsDataSourceDelegate
    {
        public void Delete(int id)
        {
            Factory.TrapResultsDataManager.Delete(id);
            this.LoadData();
            this.CollectionView.ReloadData();
        }

        public void Email()
        {
            this.SendEmail();
        }

        public void PastRound(int trapId)
        {
            UIViewController vc = new PastTrapResultsViewController(trapId);
            this.NavigateToModalViewController(vc);
        }
    }

    public class TrapResultsDataSource : UICollectionViewDataSource
    {
        #region - variables
        private List<TrapShooter> TrapShooters { get; set; }
        private List<PastResults> PastResults { get; set; }
        private TrapResultsDataSourceDelegate Delegate { get; set; }
        #endregion

        #region - constructor
        public TrapResultsDataSource(List<TrapShooter> trapShooters, List<PastResults> pastResults, TrapResultsDataSourceDelegate sourceDelegate)
        {
            this.TrapShooters = trapShooters;
            this.PastResults = pastResults;
            this.Delegate = sourceDelegate;
        }
        #endregion

        #region - life cycle methods
        #endregion

        #region - private methods
        private bool[,] GetResultsFromScores(List<bool?> scores)
        {
            bool[,] hitScores = new bool[5, 5];
            for (int i = 0; i < 25; i++)
            {
                hitScores[i/5, i % 5] = scores[i] ?? false;
            }
            return hitScores;
        }
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
                case 0: return this.TrapShooters.Count;
                case 1: return this.TrapShooters.Count > 0 ? 2 : 1;
                case 2: default: return this.PastResults.Count;
            }
        }
        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            switch (indexPath.Section)
            {
                case 0:
                    var trapResults = (TrapResultsViewCell)collectionView.DequeueReusableCell(TrapResultsViewCell.Key, indexPath);
                    trapResults.SetupTrapResultsViewCell(this.TrapShooters[indexPath.Row].Name, this.TrapShooters[indexPath.Row].TotalHit, GetResultsFromScores(this.TrapShooters[indexPath.Row].Score));
                    return trapResults;
                case 1:
                    if(indexPath.Row == 0 && this.TrapShooters.Count > 0)
                    {
                        var trapButton = (ButtonViewCell)collectionView.DequeueReusableCell(ButtonViewCell.Key, indexPath);
                        trapButton.ButtonClicked = () =>
                        {
                            if (this.Delegate != null) this.Delegate.Email();
                        };
                        trapButton.SetupButtonViewCell("Email Results", 40);
                        return trapButton;
                    }
                    else
                    {
                        var labelResults = (LabelViewCell)collectionView.DequeueReusableCell(LabelViewCell.Key, indexPath);
                        labelResults.SetupLabelViewCell("Past Results:");
                        return labelResults;
                    }
                case 2: default:
                    var pastResults = (PastResultsViewCell)collectionView.DequeueReusableCell(PastResultsViewCell.Key, indexPath);
                    pastResults.ButtonViewRoundClicked = () =>
                    {
                        if (this.Delegate != null) this.Delegate.PastRound(this.PastResults[indexPath.Row].TrapId);
                    };
                    pastResults.ButtonDeleteClicked = () =>
                    {
                        if (this.Delegate != null) this.Delegate.Delete(this.PastResults[indexPath.Row].Id);
                    };
                    pastResults.SetupPastResultsViewCell(this.PastResults[indexPath.Row].Name, this.PastResults[indexPath.Row].Score, this.PastResults[indexPath.Row].Date.ToString(), this.PastResults[indexPath.Row].TrapId > 0);
                    return pastResults;
            }
        }
        #endregion
    }

    public class TrapResultsLayoutDelegate : UICollectionViewDelegateFlowLayout
    {
        public override CGSize GetSizeForItem(UICollectionView collectionView, UICollectionViewLayout layout, NSIndexPath indexPath)
        {
            var width = collectionView.Frame.Width - (collectionView.ContentInset.Left + collectionView.ContentInset.Right);

            switch (indexPath.Section)
            {
                case 0: return new CGSize(width, 24 + (SizeConstants.TrapGridCell * 5));
                case 1: case 2: default: return new CGSize(width, 70);
            }
        }
    }

    public interface TrapResultsDataSourceDelegate
    {
        void Delete(int id);
        void PastRound(int trapId);
        void Email();
    }
}

