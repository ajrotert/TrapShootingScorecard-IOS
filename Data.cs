using System;
using System.IO;
using SQLite;
using System.Collections.Generic;

namespace AR.TrapScorecard
{
    [Table("Items")]
    public class Data
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(9)]
        public string Name { get; set; }

        //[MaxLength(8)]
        public int Score { get; set; }

        //[MaxLength(8)]
        public DateTime Date { get; set; }

    }


    public static class DatabaseManagement
    {
        public static void Access(string name, int score, DateTime date)
        {
            string output = "";
            output += "\nCreating database, if it doesn't already exist";
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdata.db3");

            SQLiteConnection db = new SQLiteConnection(dbPath);
            db.CreateTable<Data>();

            if (db.Table<Data>().Count() == 0)
            {
                // only insert the data if it doesn't already exist
                var newData = new Data();
                newData.Name = name;
                newData.Score = score;
                newData.Date = date;
                db.Insert(newData);
            }

            output += "\nReading data using Orm";
            TableQuery<Data> table = db.Table<Data>();
            foreach (var s in table)
            {
                output += "\n" + s.Id + " " + s.Name + " " + s.Score + " " + s.Date;
            }

            Console.WriteLine(output);
        }
        public static void Add(string name, int score, DateTime date)
        {
            string output = "";
            output += "\nCreating database, if it doesn't already exist";
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdata.db3");

            SQLiteConnection db = new SQLiteConnection(dbPath);
            db.CreateTable<Data>();

            Data newData = new Data();
            newData.Name = name;
            newData.Score = score;
            newData.Date = date;
            db.Insert(newData);

            Console.WriteLine(output);
        }

        /*public static string MoreComplexQuery()
        {
            var output = "";
            output += "\nComplex query example: ";
            string dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdata.db3");

            var db = new SQLiteConnection(dbPath);

            var query = db.Query<Stock>("SELECT * FROM [Items] WHERE Symbol = ?", "MSFT");
            foreach (var s in query)
            {
                output += "\n" + s.Id + " " + s.Symbol;
            }

            return output;
        }*/

        public static string[] GetAllFormatted()
        {
            string output = "";
            output += "\nGet query example: ";
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdata.db3");

            SQLiteConnection db = new SQLiteConnection(dbPath);

            //var returned = db.Get<Data>(2);//get one item
            List<string> list = new List<string>();
            TableQuery<Data> table = db.Table<Data>();//get all items
            foreach (var s in table)
            {
                list.Add(s.Name + ": " + s.Score + "\t\t(" + s.Date.ToShortDateString() + ", " + s.Date.ToShortTimeString() + ")");
                output += "\n" + s.Id + " " + s.Name + " " + s.Score + " " + s.Date;
            }
            Console.WriteLine(output);
            return list.ToArray();
        }
        public static Data[] GetAll()
        {
            string output = "";
            output += "\nGet query example: ";
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdata.db3");

            SQLiteConnection db = new SQLiteConnection(dbPath);

            //var returned = db.Get<Data>(2);//get one item
            List<Data> list = new List<Data>();
            TableQuery<Data> table = db.Table<Data>();//get all items
            foreach (var s in table)
            {
                list.Add(s);
                output += "\n" + s.Id + " " + s.Name + " " + s.Score + " " + s.Date;
            }
            Console.WriteLine(output);
            return list.ToArray();
        }

        public static string Delete(int id)
        {
            string output = "";
            output += "\nDelete query example: ";
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdata.db3");

            SQLiteConnection db = new SQLiteConnection(dbPath);

            var rowcount = db.Delete(new Data() { Id = id });

            return output;
        }
        public static void Delete(string id)
        {
            string output = "";
            output += "\nDelete query example: ";
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdata.db3");

            SQLiteConnection db = new SQLiteConnection(dbPath);

            var rowcount = db.Delete(new Data() { Name = id });

             Console.WriteLine(output);
        }

        /*public static string ScalarQuery()
        {
            var output = "";
            output += "\nScalar query example: ";
            string dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ormdemo.db3");

            var db = new SQLiteConnection(dbPath);

            var rowcount = db.ExecuteScalar<int>("SELECT COUNT(*) FROM [Items] WHERE Symbol <> ?", "MSFT");

            output += "\nNumber of rows : " + rowcount;

            return output;
        }
        */
    }

}
