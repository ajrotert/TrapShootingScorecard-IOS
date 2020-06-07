using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AR.TrapScorecard
{
    public class CSVFile
    {
        public CSVFile(Shooter[] shooters)
        {
            _shooters = shooters;
            csv = new StringBuilder();
        }
        private Shooter[] _shooters;
        private StringBuilder csv;

        public void getCSV()
        {
            WriteCSV();
            CreateCSV();
        }

        private void WriteCSV()
        {
            Console.WriteLine("Save CSV");
            csv.AppendLine("Shooters ,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25, ,Totals ");
            for(int shooter = 0; shooter < _shooters.Length; shooter++)
            {
                string line = _shooters[shooter].Name + ": ,";
                
                for(int single = 0; single < _shooters[shooter].score.Length; single++)
                {
                    line += (_shooters[shooter].score[single] == 1 ? "Hit" : "Loss") + ",";
                }
                line += ","+"Total: "+ _shooters[shooter].GetTotal();
                csv.AppendLine(line);
            }
            csv.AppendLine(" ");
            csv.AppendLine(" ");
            csv.AppendLine("Thanks for using Trapshooting Scorecard.");
        }
        private async void CreateCSV()
        {
            try
            {
                var message = new EmailMessage
                {
                    Subject = "Trapshooting Scorecard Results",
                    Body = "See attached for results. Results are stored as a CSV file. CSV files can be opened by spreadsheet applications such as Microsoft Excel.",
                };
                var filename = DateTime.Now.ToString("MM-dd-yy-hh-mm-ss") + "-TrapshooingResults.csv";
                var file = Path.Combine(FileSystem.CacheDirectory, filename);
                File.WriteAllText(file, csv.ToString());
                message.Attachments.Add(new EmailAttachment(file));
                await Email.ComposeAsync(message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured {0}", e);
            }
            
        }
    }
}
