<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SecondChances.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="Content/main.css"/>
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />

    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main_content">
            <div id="alert_placer" runat="server"></div>
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
                            <%--<asp:Button ID="btn_signin" runat="server" Text="Log in" />--%>
                            <input type="button" id="btn_signin" value="Log in" onclick="validarFormulario()"/>
                        </div>

                        <div class="dot_separation">
                            
                        </div>

                        <a class="ma-link" href="Signin.aspx">¿No tienes cuenta?</a>
                    </div>
                    
               </div>
            </div>
            <div class="left_ilustration secondOne">

            </div>
        </div>
        <script src="Scripts/jquery-3.3.1.js"></script>
        <script src="Scripts/Functionalities.js"></script>
        
        <script>

            function validarFormulario() {
                //Obtenemos el formulario
                var my_form = document.getElementById('form1');

                //Obtenemos los elementos del form
                let user = document.getElementById('data_user').value;
                let pass = document.getElementById('data_pass').value;
                console.log(user + " - " + pass);
                if (user != "" && pass != "") {
                    document.getElementById("form1").submit();
                } else {
                    removeAlertos();
                    document.getElementById('alert_placer').innerHTML += "<div class='ma_alert'>Faltan Datos<i class='material-icons closable'>close</i></div>";
                }
            }
        </script>
        
        
    </form>
</body>
</html>
