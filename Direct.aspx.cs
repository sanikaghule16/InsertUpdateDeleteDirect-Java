using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace insertupdatedeletedirect
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["MVTDBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();

                cmd.CommandText = "delete from Product where ProductId=1";
                int Totalrowaffected = cmd.ExecuteNonQuery();
                Response.Write(" Total row deleted --> " + Totalrowaffected.ToString());
                Response.Write("<br/>");
                cmd.CommandText = "insert into Product values(4,'mobile',30,3)";
                Totalrowaffected = cmd.ExecuteNonQuery();
                Response.Write(" Total row Inserted  --> " + Totalrowaffected.ToString());
                Response.Write("<br/>");
                cmd.CommandText = "update Product set qty=11 where ProductId =2";
                Totalrowaffected = cmd.ExecuteNonQuery();
                Response.Write(" Total row Updated   --> " + Totalrowaffected.ToString());
                Response.Write("<br/>");
                con.Close();

            }
        }
    }
}
