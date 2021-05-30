using System;
namespace AR.TrapScorecard.Models.TrapResults
{
    public class PastResults
    {
        public int Id { get; set; }
        public int TrapId { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
    }
}
