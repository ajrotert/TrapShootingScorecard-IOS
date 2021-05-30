using System;
using System.Collections.Generic;

namespace AR.TrapScorecard.Models.TrapShooter
{
    public class TrapShooter
    { 
        public string Name { get; set; }
        public int CurrentShot { get; set; }

        private List<bool?> _Score;
        public List<bool?> Score { get { if (_Score == null) _Score = new List<bool?>(); for(int i = 0; i<25; i++)_Score.Add(null); return _Score; } }

        public int TotalHit { get { int total = 0; Score.ForEach(clay => total += clay ?? false ? 1 : 0 ); return total; } }
    }
}
