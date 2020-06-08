using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDWithSPDataGrid
{
    public partial class Default : System.Web.UI.Page
    {
        readonly string cs = ConnectionString.GetConnectionString();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetData();
        }

        // Get data of a table to be filled in a gridview
        void GetData()
        {
            // Name of the stored procedure
            string spName = "spCRUDINFO";

            SqlConnection conn = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(spName, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataSet dataset = new DataSet();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Type", "Select");
            cmd.Parameters.AddWithValue("@Id", DBNull.Value);
            cmd.Parameters.AddWithValue("@Name", DBNull.Value);
            cmd.Parameters.AddWithValue("@Age", DBNull.Value);
            cmd.Parameters.AddWithValue("@City", DBNull.Value);
            cmd.Parameters.AddWithValue("@Country", DBNull.Value);

            using (conn)
            {
                conn.Open();

                adapter.Fill(dataset);

                gvInfo.DataSource = dataset;
                gvInfo.DataBind();
            }
        }
    }
}