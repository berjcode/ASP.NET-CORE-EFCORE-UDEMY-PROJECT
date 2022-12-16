using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using static System.Net.Mime.MediaTypeNames;

namespace FirstApplication
{
    public class Global : System.Web.HttpApplication
    {

       
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["TotalApplications"]= 0;
            Application["TotalUserSessions"] = 0;
            Application["TotalApplications"] = (int)Application["TotalApplications"] +1;


        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application["TotalUserSessions"] = (int)Application["TotalUserSessions"] +1 ;
        }


        protected void Session_End(object sender, EventArgs e)
        {
            Application["TotalUserSessions"] = (int)Application["TotalUserSessions"] - 1;
        }

    }
}