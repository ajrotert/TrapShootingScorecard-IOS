using System;
using SQLite;

namespace AR.TrapScorecard.Data.DataModels
{
    [Table("Items")]
    public class TrapResult
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(9)]
        public string Name { get; set; }

        public int Score { get; set; }

        public DateTime Date { get; set; }

        public int TrapId { get; set; }
    }
}
