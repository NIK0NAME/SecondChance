<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SecondChances.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="Content/main.css"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main_content">
            <div class="left_ilustration">

            </div>
            <div class="login_content">
               <div >
                    <h1 style="text-align: center;"><img src="https://image.flaticon.com/icons/svg/1727/1727763.svg" width="50"/><br />Login to get some trash</h1>
                    <div>
                        <asp:TextBox ID="username" runat="server"></asp:TextBox>
                        <asp:TextBox ID="pass" runat="server"></asp:TextBox>
                    </div>
                    <asp:Button ID="Button1" runat="server" Text="Make it real" />
               </div>
            </div>
        </div>
    </form>
</body>
</html>
