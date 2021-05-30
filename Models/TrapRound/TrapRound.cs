using System;
using System.Collections.Generic;

namespace AR.TrapScorecard.Models.TrapRound
{
    public class TrapRound
    {
        public List<TrapShooter.TrapShooter> Shooters { get; set; }
        public TrapShooter.TrapShooter CurrentShooter { get { return Shooters[CurrentShooterIndex]; } }
        public int CurrentShooterIndex { get; set; }
        public int CurrentRotation { get; set; }
    }
}
