using System;
using System.IO;
using SQLite;
using _00_Activities.src.Contacts.Domain.Entity;

namespace _00_Activities.src.Contacts.Domain.Repository
{
	public class Connection
	{
        const string DatabaseName = "contacts.db3";

        private static Connection _connection;

        public SQLiteConnection Database;

        private Connection() { }

        private void Start()
        {
            if (Database == null)
            {
                var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var path = Path.Combine(folderPath, DatabaseName);
                Database = new SQLiteConnection(path, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite);
                var tables = new Type[]
                {
                    typeof(Contact),
                    typeof(Profile)
                };

                Database.CreateTables(CreateFlags.None, tables);
            }
        }


        public static SQLiteConnection Instance
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new Connection();
                    _connection.Start();
                }

                return _connection.Database;
            }
        }
    }
}

