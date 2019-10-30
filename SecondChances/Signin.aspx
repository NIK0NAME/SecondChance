<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="SecondChances.Signin" %>
<%@ MasterType VirtualPath="~/Site.Master" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="main_content" runat="server" id="piter">
            <div class="left_ilustration">

            </div>
            <div class="login_content">
               <div style="width: 320px;">
                    <h1 style="text-align: center;"><img src="https://image.flaticon.com/icons/svg/1727/1727763.svg" width="35"/><br />Sing In</h1>
                    <div class="form_data">
                        <div class="form_col">
                             <span>Name: </span><asp:TextBox ID="data_name" runat="server"></asp:TextBox>
                        </div>
                        <div class="form_col">
                            <span>Username: </span><asp:TextBox ID="data_user" runat="server"></asp:TextBox>
                        </div>
                        <div class="form_col">
                             <span>Password: </span><asp:TextBox ID="data_pass" TextMode="Password" runat="server"></asp:TextBox>
                        </div>
                       <div class="form_col">
                             <span>Mail: </span><asp:TextBox ID="data_mail" TextMode="Email" runat="server"></asp:TextBox>
                       </div>
                        <div class="button_signin">
                            <asp:Button ID="btn_signin" runat="server" Text="signin" />
                        </div>
                    </div>
                    
               </div>
            </div>
        </div>
</asp:Content>
