using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace GTICLOUD
{
    public class DB_Querys
    {

        internal static string LocalSqlConn() {

            string query = "Data Source=LAPTOP-EMJVR3G8;Initial Catalog=gti_cloud;Integrated Security=True";
            return query;
        }

        internal static string CreateAccountQuery() {

            string query = "insert into registration (gti_user_name,email,category,password,created,updated) values (@username,@email,@category,@password,@created,@updated)";

            return query;
        }

        internal static string CreateSite() {

            string query = "insert into sites (sitename,siteid,postype,backofficeuserid,backofficepassword,regitered,updated) values (@sitename,@siteid,@postype,@backofficeuserid,@backofficepassword,@regitered,@updated)";

            return query;
        
        }

        internal static string GetRegisteredUsersQuery() {

            string query = "select email,password,category,permission_level from registration";

            return query;
        
        }

        internal static string GetSideNav() {

            string query = "select *from sidenav";

            return query;
        
        }

        internal static string GetSites()
        {
            string query = "select sitekey,sitename,siteid,postype,regitered,updated from sites";

            return query;
        }

        internal static string SiteServices() {

            return null;
        
        }

        internal static string AddAccessControl()
        {
            string query = "insert into accessControl (sitekey,name,email,category,authentication_key,is_authenticate,created,updated,permission_level) values(@sitekey,@name,@email,@category,@authentication_key,@is_authenticate,@created,@updated,@permission_level)";

            return query;
        }

        internal static string CheckAlready()
        {
            string query = "select email,sitekey from accessControl";

            return query;
        }

        internal static string Authentication(string sEmail, string sAuth_key)
        {
            string query = "select sitekey,is_authenticate,authentication_key,email,permission_level from accessControl where email='" + sEmail + "' and authentication_key='" + sAuth_key + "' and is_authenticate='1'";

                return query;
        }

        internal static string getSiteKeys(string email)
        {
            string query = "select sitekey from accessControl where email='" + email + "'";

            return query;
        }

        internal static string GetSitesAccordingKeys(string sSiteKeys)
        {
            string query = "select *from sites where sitekey in ("+sSiteKeys+")";

            return query;
        }

        internal static bool IsSitekeyAvailable(string sitekey,string email){

            string query = "select S.sitekey,A.email from sites S inner join accessControl A on S.sitekey=A.sitekey where A.email='"+email+"' and A.sitekey='"+sitekey+"'";

            SqlCommand cmd = DB.ExecuteReader(query);
            SqlDataReader dbr = cmd.ExecuteReader();

            if (dbr.HasRows == false)
            {
                return false;
            }
            else {

                return true;
            }

            DB.CloseConn();
            cmd.Dispose();
            dbr.Dispose();

        }
    }
}