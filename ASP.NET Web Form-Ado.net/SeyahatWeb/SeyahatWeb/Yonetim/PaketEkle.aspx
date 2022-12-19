<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.Master" AutoEventWireup="true" CodeBehind="PaketEkle.aspx.cs" Inherits="SeyahatWeb.Yonetim.PaketEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h3 class="page-title">  Yeni Tur Ekleme Sayfası  </h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
       <div class="col-12 grid-margin stretch-card">
              <div class="card">
                <div class="card-body">
                 
                  <form class="forms-sample" runat="server">
                    <div class="form-group">
                      <label for="exampleInputName1">Tur Adı:</label>
                      
                        <asp:TextBox ID="txtAd" runat="server" CssClass="form-control" placeholder="Tur Adını Girin"></asp:TextBox>
                    </div>
                    <div class="form-group">
                      <label for="exampleInputEmail3">Tur Fiyat</label>
                     
                         <asp:TextBox ID="turFiyat" runat="server" CssClass="form-control" placeholder="Tur Fiyat"></asp:TextBox>
                    </div>
                    <div class="form-group">
                      <label for="exampleInputPassword4">Tur Süresi</label>
                       <asp:TextBox ID="turSuresi" runat="server" CssClass="form-control" placeholder="Tur Süresi"></asp:TextBox>
                    </div>
                    <div class="form-group">
                      <label for="exampleSelectGender">Konum</label>
                       
                        <asp:TextBox ID="turKonum" runat="server" CssClass="form-control" placeholder="Tur Konumu"></asp:TextBox>
                          
                      </div>
                    <div class="form-group">
                      <label>Tur Resim</label>
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="file-control file-upload-info" />
                    </div>
                   
                    <div class="form-group">
                      <label for="exampleTextarea1">Tur Detayı</label>
                      <asp:TextBox ID="txtDetay" runat="server" TextMode="MultiLine"  height="80px" CssClass="form-control" placeholder="Tur Detay"></asp:TextBox>
                    </div>
                   
                      <asp:Button ID="Button1" runat="server" Text="Kaydet" CssClass="btn btn-gradient-primary mr-2" />
                  </form>
                </div>
              </div>
            </div>
</asp:Content>
