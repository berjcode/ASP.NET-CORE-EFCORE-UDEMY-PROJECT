<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="FirstApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"> Buraya Giriş yapın

        </asp:TextBox>
        <p>
       <asp:Button runat="server" Text="Click Me" OnClick="Unnamed1_Click" Width="118px" />
        </p>
    </form>
</body>

</html>
