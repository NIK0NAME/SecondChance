<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="SecondChances.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>SQL Connection and Data Managment</title>
    <link rel="stylesheet" href="/Content/main.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="main-container">
            <asp:GridView ID="GridView1" runat="server" CssClass="beatifull-table"></asp:GridView>
            <div runat="server" id="newGr"></div>
        </div>
    </form>
</body>
</html>
