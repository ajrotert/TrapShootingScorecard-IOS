using System;
using System.Collections.Generic;
using System.IO;
using SQLite;

namespace AR.TrapScorecard.Data.Managers
{
    public class TrapResultsDataManager
    {
        #region - variables
        private SQLiteConnection database { get; set; }
        #endregion

        #region - constructor
        public TrapResultsDataManager(string databaseName)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), databaseName);
            this.database = new SQLiteConnection(dbPath);
            this.database.CreateTable<DataModels.TrapResult>();
        }
        #endregion

        #region - life cycle methods
        #endregion

        #region - private methods
        #endregion

        #region - public methods
        public void Add(string name, int score, DateTime date, int trapId)
        {
            database.CreateTable<DataModels.TrapResult>();

            DataModels.TrapResult newData = new DataModels.TrapResult();
            newData.Name = name;
            newData.Score = score;
            newData.Date = date;
            newData.TrapId = trapId;
            database.Insert(newData);
        }

        public DataModels.TrapResult[] GetAll()
        {
            List<DataModels.TrapResult> list = new List<DataModels.TrapResult>();
            TableQuery<DataModels.TrapResult> table = database.Table<DataModels.TrapResult>();
            foreach (var s in table)
            {
                list.Add(s);
            }
            return list.ToArray();
        }

        public bool Delete(int id)
        {
            var rowcount = database.Delete(new DataModels.TrapResult() { Id = id });

            return rowcount == 0;
        }
        #endregion


    }
}
