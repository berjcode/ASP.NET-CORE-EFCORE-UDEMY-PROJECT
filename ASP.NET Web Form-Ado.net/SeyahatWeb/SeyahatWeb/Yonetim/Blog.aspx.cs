using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SeyahatWeb.Yonetim
{
    public partial class Blog : System.Web.UI.Page
    {

        DateTime bugun = DateTime.Now;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTarih.Text= bugun.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}