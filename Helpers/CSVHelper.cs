using System;
using System.Collections.Generic;
using System.Text;
using AR.TrapScorecard.Models.TrapShooter;

namespace AR.TrapScorecard.Helpers
{
    public class CSVHelper
    {
        #region - variables
        #endregion

        #region - constructor
        public CSVHelper()
        {
        }
        #endregion

        #region - life cycle methods
        #endregion

        #region - private methods
        private string GetCSVForShooter(TrapShooter trapShooter)
        {
            List<string> scores = new List<string> { $"{trapShooter.Name}: " };
            trapShooter.Score.GetRange(0, 25).ForEach(score =>
            {
                scores.Add(score??false ? "Hit" : "Loss");
            });
            scores.Add($"Total: {trapShooter.Score.FindAll(score => { return score??false; }).Count}");
            return string.Join(",", scores);
        }
        #endregion

        #region - public methods
        public string GetCSVForShooters(List<TrapShooter> trapShooters)
        {
            StringBuilder csv = new StringBuilder();
            csv.AppendLine("Shooters ,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25, ,Totals ");
            trapShooters.ForEach(shooter =>
            {
                csv.AppendLine(GetCSVForShooter(shooter));
            });
            return csv.ToString();
        }

        public string GetCSVScoresForShooters(List<TrapShooter> trapShooters)
        {
            List<string> scores = new List<string>();
            trapShooters.ForEach(shooter =>
            {
                shooter.Score.GetRange(0, 25).ForEach(score =>
                {
                    scores.Add(score ?? false ? "1" : "0");
                });
            });
            return string.Join(",", scores);
        }

        public string GetCSVNamesForShooters(List<TrapShooter> trapShooters)
        {
            List<string> names = new List<string>();
            trapShooters.ForEach(shooter =>
            {
                names.Add(shooter.Name);
            });
            return string.Join(",", names);
        }

        public string AppendLinesToCSV(string csv, params string[] lines)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(csv);
            Array.ForEach(lines, line =>
            {
                stringBuilder.AppendLine(line);
            });
            return stringBuilder.ToString();
        }

        public List<bool[,]> GetScoresFromCSV(string scores)
        {
            string[] scoreArray = scores.Split(",");
            List<bool[,]> scoresList = new List<bool[,]>();

            int shooters = scoreArray.Length / 25;
            for(int i = 0; i< shooters; i++)
            {
                scoresList.Add(new bool[5, 5]);
                for(int r =0; r<5; r++)
                {
                    for(int c = 0; c<5; c++)
                    {
                        scoresList[i][r, c] = scoreArray[(i*25) + (r*5) + c] == "1";
                    }
                }
            }

            return scoresList;
        }

        public List<string> GetNamesFromCSV(string names)
        {
            List<string> nameList = new List<string>();
            Array.ForEach(names.Split(","), name => nameList.Add(name));
            return nameList;
        }
        #endregion
    }
}
