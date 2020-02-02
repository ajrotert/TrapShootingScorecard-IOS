using System;
namespace AR.TrapScorecard
{
    public class Shooter
    {
        public Shooter(string name)
        {
            Name = name;
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set 
            {
                if(value.Length<9)
                {
                    _name = value;
                    if (value.Length < 5)
                        _name += '\t';
                    else if (value.Length < 6)
                        _name += "  ";
                }
                else if(value.Length == 9)
                    _name = value;
                if(value.Length>9)
                {
                    _name = "";
                    for (int a = 0; a < 9; a++)
                        _name += value[a];
                }

            }
        }

        public int shot = 0;
        public int[] score = new int[25];
        public int[] StandingRound = { 2, 2, 2, 2, 2};
        private int RoundTotal = 0;

        public void UpdateScore(bool hit)
        {
            if (hit)
                score[shot] = 1;
            else
                score[shot] = 0;
            if(hit)
                RoundTotal++;
            UpdateStandingRound(score[shot]);
            shot++;

        }
        private void UpdateStandingRound(int n)
        {
            int a = 0;
            while (a<5 && StandingRound[a] != 2)
                a++;
            if (a == 5)
            {
                for (int b = 0; b < 5; b++)
                    StandingRound[b] = 2;
                a = 0;
            }
            StandingRound[a] = n;

        }
        public void UpdateScoresFromRound()
        {
            int last = 0;
            for(int a = 4; a >= 0; a--)
            {
                if(StandingRound[a] != 2)
                {
                    score[shot - 1 - last] = StandingRound[a];
                    last++;
                }
            }
        }
        public int GetRoundTotal()
        {
            int temp = RoundTotal;
            RoundTotal = 0;
            return temp;
        }
        public int GetStandingTotal()
        {
            int score = 0;
            for(int a = 0; a<shot; a++)
            {
                score += this.score[a];
            }
            return score;
        }
        public int GetTotal()
        {
            int total = 0;
            if(shot == 25)
            {
                for (int a = 0; a < score.Length; a++)
                    total += score[a];
                return total;
            }
            return -1;

        }
    }
}
