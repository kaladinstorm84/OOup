using OOup.DataObjects;
using OOup.Tasks.TaskBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OOup.Tasks
{
    public abstract class RunSQL : BaseTask
    {
        public string ConnectionString { get; }
        public string SQL { get; set; }
        public abstract void SetSQL();
        public RunSQL(DatabaseConnection databaseConnection)
        {
            ConnectionString = "";
        }
        public RunSQL(string connectionString)
        {
            ConnectionString=connectionString;  
        }

        public override void Run()
        {

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SetSQL();   
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandText = SQL;
                cmd.ExecuteNonQuery();
            }

        }
    }
}
