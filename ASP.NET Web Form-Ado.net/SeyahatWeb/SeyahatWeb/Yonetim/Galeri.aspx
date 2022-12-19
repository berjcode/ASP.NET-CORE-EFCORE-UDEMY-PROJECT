<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.Master" AutoEventWireup="true" CodeBehind="Galeri.aspx.cs" Inherits="SeyahatWeb.Yonetim.Galeri" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h3 class="page-title"> Galeri </h3>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
 
    <div class="col-12 grid-margin stretch-card">
              <div class="card">
                <div class="card-body">
                 
                  <form class="forms-sample" runat="server">
                    <div class="form-group">
                      <label for="exampleInputName1">Kategori Ekle</label>
                      
                        <asp:TextBox ID="txtKategoriAdi" runat="server" CssClass="form-control" placeholder="Kategori Adı Girin "></asp:TextBox>
                          <asp:Button ID="Button2" runat="server" Text="Kategori Ekle" CssClass="btn btn-gradient-primary mr-2" />
                    </div>
                   <br />  <br />  <br /> 
                    <div class="form-group">
                        <div class="form-group">
                      <label for="exampleInputName1">Kategori Adı</label>
                      
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                      <label>Galeri Resim</label>
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="file-control file-upload-info" />
                    </div>
                   
                      <asp:Button ID="Button1" runat="server" Text="Resimi Kaydet" CssClass="btn btn-gradient-primary mr-2" />
                  </form>
                </div>
              </div>
            </div>
</asp:Content>
