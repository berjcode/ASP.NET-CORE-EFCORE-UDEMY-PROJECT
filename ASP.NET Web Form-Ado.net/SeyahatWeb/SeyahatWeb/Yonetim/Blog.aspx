<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.Master" AutoEventWireup="true" CodeBehind="Blog.aspx.cs" Inherits="SeyahatWeb.Yonetim.Blog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h3 class="page-title"> Blog Ekle  </h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
      <div class="col-12 grid-margin stretch-card">
              <div class="card">
                <div class="card-body">
                 
                  <form class="forms-sample" runat="server">
                    <div class="form-group">
                      <label for="exampleInputName1">Başlık  Adı:</label>
                      
                        <asp:TextBox ID="txtBaslik" runat="server" CssClass="form-control" placeholder="Başlık   Girin"></asp:TextBox>
                    </div>
                    <div class="form-group">
                      <label for="exampleInputEmail3">Özet</label>
                     
                         <asp:TextBox ID="turOzet" runat="server" CssClass="form-control" placeholder="Blog Özeti Girin"></asp:TextBox>
                    </div>
                    <div class="form-group">
                      <label for="exampleInputPassword4">Kategori</label>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    
                    <div class="form-group">
                      <label>Blog Resim</label>
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="file-control file-upload-info" />
                    </div>
                   
                    <div class="form-group">
                      <label for="exampleTextarea1">Blog Detayı</label>
                      <asp:TextBox ID="txtDetay" runat="server" TextMode="MultiLine"  height="100px" CssClass="form-control" placeholder="Tur Detay"></asp:TextBox>
                    </div>
                        <asp:Label ID="lblTarih" runat="server" Text=""></asp:Label>
                      <asp:Button ID="Button1" runat="server" Text="Kaydet" CssClass="btn btn-gradient-primary mr-2" OnClick="Button1_Click" />
                     
                  </form>
                </div>
              </div>
            </div>
</asp:Content>
