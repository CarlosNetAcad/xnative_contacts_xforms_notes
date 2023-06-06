using System;
using ContactApp.Core.Entities;
using SQLite;
using System.IO;
using System.Net.Http;

namespace ContactApp.Core.Repository.API
{
	public class Connection
	{
        #region Flds
        /// <summary>
        ///  <value> @Attribute{Connection} </value> <c>_CnnContacts</c> to get the instance of the self class
        ///		necessary to the singleton.
        /// </summary>
        private static Connection _Cnn;

        public HttpClient Client;

        #endregion Flds

        #region Props
        /// <summary>
        /// <value> @Property{HttpClient} </value> <c>Instance</c> Property use
        /// to get the self singleton instance
        /// <returns>  </returns>
        /// </summary>
        public static HttpClient Instance
        {
            get
            {
                if (_Cnn == null)
                {
                    _Cnn = new Connection();
                    _Cnn.Open();
                }

                return _Cnn.Client;
            }

        }

        #endregion Props

        #region __constructor
        /// <summary>
        /// Private constructor necessary to the singleton pattern.
        /// </summary>
        private Connection()
        {
        }
        #endregion __constructor

        #region - methods
        /// <summary>
        /// @desc This method open a new database depending the platform who call it.
        /// </summary>
        private void Open()
        {
            if( Client == null)
            {
                Client = new HttpClient();
            } 
        }

        public void Close()
        {
            Client.Dispose();
        }
        #endregion - methods
    }
}

