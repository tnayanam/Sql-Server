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

        [System.Web.Services.WebMethod]
        public static Result CallStoredProcedure(int attemptsLeft)
        {
            Result _result = new Result();
            if (attemptsLeft > 0)
            {

                try
                {
                    string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand("spTransaction2", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        _result.Message = "Transaction successful";
                        _result.Success = true;
                        _result.AttemptsLeft = 0;
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 1205)
                    {
                        _result.AttemptsLeft = attemptsLeft - 1;
                        _result.Message = "Deadlock Occured" + _result.AttemptsLeft.ToString();
                    }
                    else
                    {
                        throw;
                    }
                    _result.Success = false;
                }
            }
            return _result;
        }
    }
}


