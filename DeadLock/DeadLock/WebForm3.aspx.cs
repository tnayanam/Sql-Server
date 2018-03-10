using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DeadLock
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFillDummyData_Click(object sender, EventArgs e)
        {
            txtId1.Text = "1";
            txtId2.Text = "2";
            txtId3.Text = "3";
            txtAddress1.Text = "Delhi";
            txtAddress2.Text = "Patna";
            txtAddress3.Text = "Nagpur";
            txtName1.Text = "Tanuj";
            txtName2.Text = "Rajesh";
            txtName3.Text = "Rohit";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spInsertEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@EmpTableType";
                param.Value = GetEmployees();
                cmd.Parameters.Add(param);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private DataTable GetEmployees()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            dt.Columns.Add("Address");

            dt.Rows.Add(int.Parse(txtId1.Text), txtName1.Text, txtAddress1.Text);
            dt.Rows.Add(int.Parse(txtId2.Text), txtName2.Text, txtAddress2.Text);
            dt.Rows.Add(int.Parse(txtId3.Text), txtName3.Text, txtAddress3.Text);
            return dt;
        }
    }
}
