using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace SeyahatWeb.Yonetim
{
    public partial class PaketEkle : System.Web.UI.Page
    {
        string conn = WebConfigurationManager.ConnectionStrings["dbGoTripConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            if(FileUpload1.HasFile)
            {
                if(FileUpload1.PostedFile.ContentType=="image/jpeg" || FileUpload1.PostedFile.ContentType == "image/jpg"|| FileUpload1.PostedFile.ContentType == "image/png")
                {
                    string ResimAd = FileUpload1.FileName.ToString();

                    FileUpload1.SaveAs(Server.MapPath("~/images/" + ResimAd));
                    lblResim.Text = ResimAd.ToString();

;                }else
                {
                    lblResim.Text = "lütfen jpeg ve png uzantılı dosya secin";

                }


            }else
            {
                lblResim.Text = "Lüttfen bir resim secin ";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(conn);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tblTurPaket(Ad,Fiyat,Sure,Lokasyon,Resim,Detay) values (@Ad,@Fiyat,@Sure,@Lokasyon,@Resim,@Detay)", baglanti);
            komut.Parameters.AddWithValue("@Ad", txtAd.Text.ToString());
            komut.Parameters.AddWithValue("@Fiyat", turFiyat.Text.ToString());
            komut.Parameters.AddWithValue("@Sure", turSuresi.Text.ToString());
            komut.Parameters.AddWithValue("@Lokasyon", turKonum.Text.ToString());
            komut.Parameters.AddWithValue("@Resim", lblResim.Text.ToString());
            komut.Parameters.AddWithValue("@Detay", txtDetay.Text.ToString());
            komut.ExecuteNonQuery();

            baglanti.Close();
            Response.Redirect("PaketEkle.aspx");
        }
    }
}