using System;
using AR.TrapScorecard.Components.Constants;
using AR.TrapScorecard.Data.Managers;
using AR.TrapScorecard.Helpers;

namespace AR.TrapScorecard.Factory
{
    public class Factory
    {
        #region - variables
        #endregion

        #region - constructor
        public Factory()
        {
        }
        #endregion

        #region - Data Managers
        private TrapResultsDataManager _TrapResultsDataManager;
        public TrapResultsDataManager TrapResultsDataManager
        {
            get
            {
                if (_TrapResultsDataManager == null) _TrapResultsDataManager = new TrapResultsDataManager(DataConstants.DATABASE_NAME);
                return _TrapResultsDataManager;
            }
        }
        private TrapRoundDataManager _TrapRoundDataManager;
        public TrapRoundDataManager TrapRoundDataManager
        {
            get
            {
                if (_TrapRoundDataManager == null) _TrapRoundDataManager = new TrapRoundDataManager(DataConstants.DATABASE_NAME);
                return _TrapRoundDataManager;
            }
        }
        #endregion

        #region - Helpers
        private CSVHelper _CSVHelper;
        public CSVHelper CSVHelper
        {
            get
            {
                if (_CSVHelper == null) _CSVHelper = new CSVHelper();
                return _CSVHelper;
            }
        }

        private EmailHelper _EmailHelper;
        public EmailHelper EmailHelper
        {
            get
            {
                if (_EmailHelper == null) _EmailHelper = new EmailHelper();
                return _EmailHelper;
            }
        }

        private DataHelper _DataHelper;
        public DataHelper DataHelper
        {
            get
            {
                if (_DataHelper == null) _DataHelper = new DataHelper();
                return _DataHelper;
            }
        }
        #endregion
    }
}
