using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace AR.TrapScorecard
{
    public partial class TableContorller : UITableViewController
    {
        public TableContorller (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableSource ts;
            Data[] data;
            try { data = DatabaseManagement.GetAll(); }
            catch { data = new Data[0]; }
            TableSource.ds = new List<Data>();
            string[] sds = new string[data.Length];
            for (int a = 0; a < data.Length; a++)
            {
                TableSource.ds.Add(data[a]);
                sds[a] = data[a].Name + ": " + data[a].Score + "\t\t(" + data[a].Date.ToShortDateString() + ", " + data[a].Date.ToShortTimeString() + ")";
            }
                try { ts = new TableSource(sds); }
            catch { ts = new TableSource(new string[0] ); }
            PastTableView.Source = ts;
            for(int a =0; a<TableSource.ds.Count; a++)
            {
                Console.WriteLine(TableSource.ds[a].Name);
            }
        }
    }
    public class TableSource : UITableViewSource
    {
        public static List<Data> ds = new List<Data>();
        List<string> Items = new List<string>();
        string identifier = "Table Cell";

        public TableSource(string[] items)
        {
            for (int a = 0; a < items.Length; a++)
            {
                Items.Add(items[a]);
            }
        }
        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return Items.Count;
        }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(identifier);
            string item = Items[indexPath.Row];

            //---- if there are no cells to reuse, create a new one
            if (cell == null)
            { cell = new UITableViewCell(UITableViewCellStyle.Default, identifier); }

            cell.TextLabel.Text = item;

            return cell;
        }


        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
        {
            switch (editingStyle)
            {
                case UITableViewCellEditingStyle.Delete:
                    // remove the item from the underlying data source

                    Items.RemoveAt(indexPath.Row);
                    DatabaseManagement.Delete(ds[indexPath.Row].Id);
                    ds.RemoveAt(indexPath.Row);
                    tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade); // delete the row from the table

                    break;
                case UITableViewCellEditingStyle.None:
                    Console.WriteLine("CommitEditingStyle:None called");
                    break;
            }
        }
        public override string TitleForDeleteConfirmation(UITableView tableView, NSIndexPath indexPath)
        {   // Optional - default text is 'Delete'
            //return "Trash (" + Items[indexPath.Row] + ")";
            return "Remove";
        }
    }
}