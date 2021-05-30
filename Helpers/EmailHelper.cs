using System;
using System.IO;
using Xamarin.Essentials;

namespace AR.TrapScorecard.Helpers
{
    public class EmailHelper
    {
        #region - variables
        Factory.Factory factory = new Factory.Factory();
        #endregion

        #region - constructor
        public EmailHelper()
        {
        }
        #endregion

        #region - life cycle methods
        #endregion

        #region - private methods
        public EmailMessage GetEmailMessage(string CSV)
        {
            CSV = factory.CSVHelper.AppendLinesToCSV(CSV, " ", " ", "Thanks for using Trap Shooting Scorecard.");

            var message = new EmailMessage
            {
                Subject = "Trap Shooting Scorecard Results",
                Body = "The trap round results are attached. Results are stored as a CSV file. CSV files can be opened by spreadsheet applications such as Microsoft Excel.",
            };
            var filename = DateTime.Now.ToString("MM-dd-yy-hh-mm-ss") + "-TrapshooingResults.csv";
            var file = Path.Combine(FileSystem.CacheDirectory, filename);
            File.WriteAllText(file, CSV);
            message.Attachments.Add(new EmailAttachment(file));
            return message;
        }
        #endregion

        #region - public methods
        #endregion

    }
}
