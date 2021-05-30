using System;
using SQLite;

namespace AR.TrapScorecard.Data.DataModels
{
    [Table("TrapRound")]
    public class TrapRound
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string ScoreCSV { get; set; }

        public string NamesCSV { get; set; }

        public int ShotsPerShooter { get; set; }

        public DateTime Date { get; set; }

    }
}
