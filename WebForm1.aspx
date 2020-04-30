<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="RequestValidationAndXss.WebForm11" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <input id="Submit1" type="submit" value="submit" />
    </form>
    <br />
    You entered:
    <asp:Label ID="Label1" runat="server"></asp:Label></body>
</html>
