using System;
using System.Collections.Generic;

namespace AR.TrapScorecard.Models.TrapResults
{
    public class PastTrapRound
    {
        public List<bool[,]> Scores { get; set; }
        public List<string> Names { get; set; }
        public DateTime Time { get; set; }
    }
}
