<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetim/Admin.Master" AutoEventWireup="true" CodeBehind="PaketDuzenleSil.aspx.cs" Inherits="SeyahatWeb.Yonetim.PaketDuzenleSil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h3 class="page-title">  Paket Düzenle   </h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <form runat="server"> 
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" OnSelecting="SqlDataSource1_Selecting" ConnectionString="<%$ ConnectionStrings:dbGoTripConnectionString %>" DeleteCommand="DELETE FROM [tblTurPaket] WHERE [id] = @id" InsertCommand="INSERT INTO [tblTurPaket] ([Ad], [Fiyat], [sure], [Lokasyon], [Resim], [Detay]) VALUES (@Ad, @Fiyat, @sure, @Lokasyon, @Resim, @Detay)" SelectCommand="SELECT * FROM [tblTurPaket]" UpdateCommand="UPDATE [tblTurPaket] SET [Ad] = @Ad, [Fiyat] = @Fiyat, [sure] = @sure, [Lokasyon] = @Lokasyon, [Resim] = @Resim, [Detay] = @Detay WHERE [id] = @id">
        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Ad" Type="String" />
            <asp:Parameter Name="Fiyat" Type="Int32" />
            <asp:Parameter Name="sure" Type="Int32" />
            <asp:Parameter Name="Lokasyon" Type="String" />
            <asp:Parameter Name="Resim" Type="String" />
            <asp:Parameter Name="Detay" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Ad" Type="String" />
            <asp:Parameter Name="Fiyat" Type="Int32" />
            <asp:Parameter Name="sure" Type="Int32" />
            <asp:Parameter Name="Lokasyon" Type="String" />
            <asp:Parameter Name="Resim" Type="String" />
            <asp:Parameter Name="Detay" Type="String" />
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1"  CssClass="table table-borderless" runat ="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="Ad" HeaderText="Ad" SortExpression="Ad" />
            <asp:BoundField DataField="Fiyat" HeaderText="Fiyat" SortExpression="Fiyat" />
            <asp:BoundField DataField="sure" HeaderText="sure" SortExpression="sure" />
            <asp:BoundField DataField="Lokasyon" HeaderText="Lokasyon" SortExpression="Lokasyon" />
            <asp:BoundField DataField="Resim" HeaderText="Resim" SortExpression="Resim" />
            <asp:BoundField DataField="Detay" HeaderText="Detay" SortExpression="Detay" />
        </Columns>
    </asp:GridView>
        </form>
</asp:Content>
