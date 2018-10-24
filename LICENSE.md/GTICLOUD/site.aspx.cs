using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GTICLOUD
{
    public partial class site : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GTICLOUD.navbar.dropstring = "";
            try
            {

                if (Session[Macros.SESSION_KEY].ToString() == "" || Session[Macros.SESSION_KEY].ToString() == null)
                {


                    Response.Redirect("Default.aspx");

                }
                else
                {
                    //get all data accornding Session[Macros.SESSION_SITE_KEY].ToString() 

                  //  Response.Write("<h3>"+heddinfld.Value+"</h3>");
                    string st = Cryptography.GetK_Decrypt(Request.QueryString.Get("skey").ToString());

                    bool bcheck = DB_Querys.IsSitekeyAvailable(st, Session[Macros.SESSION_KEY].ToString());

                    if (bcheck)
                    {
                        //
                    }
                    else {

                        Response.Redirect("Default.aspx");
                    }
                    //int view = (Convert.ToInt32(st.ToCharArray()[0]) - 33);

                   //   Response.Write("<h3>" + st + "</h3>");
                    GTICLOUD.navbar.dropstring += "  <li><a href='#!'>Settings</a></li>";
                    GTICLOUD.navbar.dropstring += "  <li><a href='#!'>Logout</a></li>";
                }

            }
            catch (Exception ex)
            {

                Response.Redirect("Default.aspx");
            }
        }


    }
}