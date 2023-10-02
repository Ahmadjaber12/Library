using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace dimentions.serverconnection
{
     class serverconnectionn
    {
        public static string ConnectionString = "Data Source=ABU-ZAIN123;Initial Catalog=BooksStoreClients;Integrated Security=True";
        public static DataTable executeSQL(string sql)
        {


            SqlConnection connection = new SqlConnection();

            SqlDataAdapter adapter = default(SqlDataAdapter);

            DataTable dt = new DataTable();
            try
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(dt);
                connection.Close();
                connection = null;
                return dt;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("An Error Occured:" + ex.Message,
                  "SQl Server Connection Failed!!",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                dt = null;
            }
            return dt;

        }
    }
}
