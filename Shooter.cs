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
            set { _name = value; }
        }

        public int shot = 0;
        public int[] score = new int[25];

        public void UpdateScore(bool hit)
        {
            if (hit)
                score[shot] = 1;
            else
                score[shot] = 0;
            shot++;
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
