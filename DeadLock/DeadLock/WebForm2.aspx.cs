using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DeadLock
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = "Transaction successful";
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("spTransaction2", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Label1.Text = "Transaction successful";
                    Label1.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 1205)
                {
                    Label1.Text = "Deadlock. Please retry";
                }
                else
                {
                    Label1.Text = ex.Message;
                }
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}