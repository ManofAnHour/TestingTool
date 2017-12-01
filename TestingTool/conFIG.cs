using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingTool
{
    public class conFIG
    {
        public static string ConnFor_PG_QAData = "Server=localhost;Port= 5432; Username=apiuser;Password=abc123;Database=ClientData";

        public static string ConnFor_PG_Admin = "Server=localhost;Port= 5432; Username=postgres;Password=[Ds#$Kk.;Database=BFC";

        //public static string ConnFor_PG_QAData = "Server=10.4.10.31;Port= 5432; Username=apiuser;Password=abc123;Database=ClientData";

        //public static string ConnFor_PG_Admin = "Server=10.45.71.39;Port= 5432; Username=postgres;Password=[Ds#$Kk.;Database=BFC";


        public static string testingTool = "http://" + System.Web.HttpContext.Current.Request.Url.Host + ":" + Convert.ToString(System.Web.HttpContext.Current.Request.Url.Port) + "/";


    }
}