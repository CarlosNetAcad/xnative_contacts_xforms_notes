using System;
using System.IO;
using ContactApp.Core.Entities;
using SQLite;


namespace ContactApp.Core.Repository.SQLite
{
	public class Connection
	{
		/// <summary>
		/// + string Constant to define the database name. 
		/// </summary>
		const string DB_NAME = "contacts.db3";

        /// <summary>
        /// <value> @Attribute{Connection} </value> <c>dataBase</c>
        /// </summary>
        public SQLiteConnection dataBase;

        /// <summary>
        ///  <value> @Attribute{Connection} </value> <c>_CnnContacts</c> to get the instance of the self class
        ///		necessary to the singleton.
        /// </summary>
        private static Connection _CnnContacts;

        /// <summary>
        /// <value> @Property{SQLiteConnection} </value> <c>Instance</c> Property use
        /// to get the self singleton instance
        /// <returns>  </returns>
        /// </summary>
        public static SQLiteConnection Instance {
            get
            {
                if ( _CnnContacts == null)
                {
                    _CnnContacts = new Connection();
                    _CnnContacts.Open();
                }

                return _CnnContacts.dataBase;
            }

        }


        /// <summary>
        /// Private constructor necessary to the singleton pattern.
        /// </summary>
        private Connection()
		{
		}

        /// <summary>
        /// @desc This method open a new database depending the platform who call it.
        /// </summary>
        private void Open()
        {
            if (dataBase == null)
            {
                //->TODO: It is necessary that this have no space identation?
#if __ANDROID__
			    var folderPath = Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData );
#else
                var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
#endif
                var path = Path.Combine(folderPath, DB_NAME);
                dataBase = new SQLiteConnection(path, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite);
                var tables = new Type[]
                {
                    typeof(Contact),
                    typeof(Profile),
                    typeof(Note)
                };

                dataBase.CreateTables(CreateFlags.None, tables);
            }
        }
	}
}

