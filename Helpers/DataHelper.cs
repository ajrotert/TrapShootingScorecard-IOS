using System;
using System.Collections.Generic;
using AR.TrapScorecard.Models.TrapResults;

namespace AR.TrapScorecard.Helpers
{
    public class DataHelper
    {
        #region - variables
        private Factory.Factory Factory = new Factory.Factory();
        #endregion

        #region - constructor
        public DataHelper()
        {
        }
        #endregion

        #region - life cycle methods
        #endregion

        #region - private methods
        #endregion

        #region - public methods
        public PastTrapRound GetPastRoundResults(int trapId)
        {
            var results = Factory.TrapRoundDataManager.GetOne(trapId);
            PastTrapRound pastTrapRound = new PastTrapRound();
            pastTrapRound.Names = Factory.CSVHelper.GetNamesFromCSV(results.NamesCSV);
            pastTrapRound.Scores = Factory.CSVHelper.GetScoresFromCSV(results.ScoreCSV);
            pastTrapRound.Time = results.Date;
            return pastTrapRound;
        }

        public List<PastResults> GetPastResults()
        {
            var results = Factory.TrapResultsDataManager.GetAll();
            List<PastResults> pastResults = new List<PastResults>();
            Array.ForEach(results, x => pastResults.Insert(0, new PastResults { Id = x.Id, Name = x.Name, Date = x.Date, Score = x.Score, TrapId=x.TrapId }));
            return pastResults;
        }

        public int AddRound(string csvRound, string csvNames)
        {
            return Factory.TrapRoundDataManager.Add(csvRound, csvNames);
        }

        public void Add(PastResults pastResults, int trapId)
        {
            Factory.TrapResultsDataManager.Add(pastResults.Name, pastResults.Score, pastResults.Date, trapId);
        }

        public void Delete(int id)
        {
            Factory.TrapResultsDataManager.Delete(id);
        }
        #endregion
    }
}