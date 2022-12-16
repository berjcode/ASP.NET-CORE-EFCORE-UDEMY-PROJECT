using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstApplication
{
    public partial class session : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Uygulama Sayısı : " + Application["TotalApplications"]);
            Response.Write("<br>");
            Response.Write("Number of user Online " + Application["TotalUserSessions"]);
        }
    }
}