using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FP.Domain
{
    public class MainDomain
    {
        public void con()
        {
            this.SqlConnection = new SqlConnection("data source=.;initial catalog=TestDb;Integrated Security=True;MultipleActiveResultSets=True;App=EntityFramework");
            this.SqlConnection.Open();
        }

        public SqlDataReader GetReader(string commandText)
        {
            this.SqlCommand = new SqlCommand(commandText, this.SqlConnection);
            return this.SqlCommand.ExecuteReader();
        }

        public void ExecuteNonQuery(string commandText)
        {
            this.SqlCommand = new SqlCommand(commandText, this.SqlConnection);
            this.SqlCommand.ExecuteNonQuery();
        }

        public void CloseConnection()
        {
            this.SqlConnection.Close();
        }

        protected SqlCommand SqlCommand { get; set; }
        private SqlConnection SqlConnection { get; set; }
    }
}