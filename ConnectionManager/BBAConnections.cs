using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Practices.Unity;

namespace ConnectionManager
{

    public interface IBBAConnection
    {
        IDbConnection  GetConnection();
        string ConType { get; set; }
    }

    public class BBAConnection : IBBAConnection
    {
        public string ConType { get; set; }

        public IDbConnection GetConnection()
        {
            string _connectionString = "";
            IDbConnection connection = null;

            try
            {
                // inside if else logic we fetch connection string from ini file or from any source and inistialize connection.
                if (ConType == "local")
                {
                    _connectionString = "put here local db connection";
                    connection = new System.Data.SqlClient.SqlConnection(_connectionString);
                }
                else if (ConType == "remote")
                {
                    _connectionString = "put here remote db connection";
                    connection = new System.Data.SqlClient.SqlConnection(_connectionString);
                }
                else if (ConType == "OrcsWeb")
                {
                    _connectionString = "put here website db connection";
                    connection = new System.Data.SqlClient.SqlConnection(_connectionString);
                }
                else if (ConType == "Sage")
                {
                    _connectionString = "put here sage connection";
                    connection = new System.Data.SqlClient.SqlConnection(_connectionString);
                }

                connection.Open();
            }
            catch (Exception ex)
            {
                string strErr = ex.Message;
            }

            return connection;
        }
    }

    public static class Factory
    {
        static IUnityContainer cont = null;

        public static IBBAConnection initialize(string type)
        {
            IBBAConnection oDbConnection = null;

            cont = new UnityContainer();
            cont.RegisterType<IBBAConnection, BBAConnection>("local");
            cont.RegisterType<IBBAConnection, BBAConnection>("remote");
            cont.RegisterType<IBBAConnection, BBAConnection>("OrcsWeb");
            cont.RegisterType<IBBAConnection, BBAConnection>("Sage");

            oDbConnection = cont.Resolve<IBBAConnection>(type);
            oDbConnection.ConType = type;

            return oDbConnection;
        }
    }

}
