using System;
using System.Collections.Generic;
using System.IO;
using SQLite;

namespace AR.TrapScorecard.Data.Managers
{
    public class TrapRoundDataManager
    {
        #region - variables
        private SQLiteConnection database { get; set; }
        #endregion

        #region - constructor
        public TrapRoundDataManager(string databaseName)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), databaseName);
            this.database = new SQLiteConnection(dbPath);
            this.database.CreateTable<DataModels.TrapRound>();
        }
        #endregion

        #region - life cycle methods
        #endregion

        #region - private methods
        #endregion

        #region - public methods
        public int Add(string csvScores, string csvNames)
        {
            database.CreateTable<DataModels.TrapRound>();

            DataModels.TrapRound newData = new DataModels.TrapRound();
            newData.Date = DateTime.Now;
            newData.ScoreCSV = csvScores;
            newData.NamesCSV = csvNames;
            newData.ShotsPerShooter = 25;
            database.Insert(newData);
            return newData.Id;
        }

        public DataModels.TrapRound GetOne(int id)
        {
            var all = GetAll();
            DataModels.TrapRound trapRound = null;
            all.ForEach(x =>
            {
                if (x.Id == id) trapRound = x;
            });
            return trapRound;
        }

        private List<DataModels.TrapRound> GetAll()
        {
            List<DataModels.TrapRound> list = new List<DataModels.TrapRound>();
            TableQuery<DataModels.TrapRound> table = database.Table<DataModels.TrapRound>();
            foreach (var s in table)
            {
                list.Add(s);
            }
            return list;
        }

        public bool Delete(int id)
        {
            var rowcount = database.Delete(new DataModels.TrapRound() { Id = id });

            return rowcount == 0;
        }
        #endregion

    }
}
