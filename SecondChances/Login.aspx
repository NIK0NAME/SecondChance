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
            
            <div class="login_content">
               <div style="width: 320px;">
                    <h1 style="text-align: center;"><img src="https://image.flaticon.com/icons/svg/1727/1727763.svg" width="35"/><br />Log In</h1>
                    <div class="form_data">
                        <div class="form_col">
                            <span>Username: </span><asp:TextBox ID="data_user" runat="server"></asp:TextBox>
                        </div>
                        <div class="form_col">
                             <span>Password: </span><asp:TextBox ID="data_pass" TextMode="Password" runat="server"></asp:TextBox>
                        </div>
                        <div class="button_signin">
                            <asp:Button ID="btn_signin" runat="server" Text="signin" />
                        </div>
                    </div>
                    
               </div>
            </div>
            <div class="left_ilustration secondOne">

            </div>
        </div>
    </form>
</body>
</html>
