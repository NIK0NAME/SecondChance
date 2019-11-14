<%@ Page Title="Gestion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gestion.aspx.cs" Inherits="SecondChances.Gestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="gestion_container">
        <div class="opt_gestin">
            <asp:Button ID="gest_usuario" Text="Gestionar Usuarios" onClick="gest_usuario_Click" runat="server"/>
            <asp:Button ID="gest_productos" Text="Gestionar Productos" onClick="gest_productos_Click" runat="server"/>
            <asp:Button ID="gest_categorias" Text="Gestionar Categorias" onClick="gest_categorias_Click" runat="server"/>
        </div>
        <div class="cont_gestion"> 
            <div class="toolbar_gestion" runat="server" id="toolbar_gestion">
                
                <div class="add_user" runat="server" id="form_add_user" visible="false"> 
                    <label>Name: </label>
                    <asp:TextBox ID="txt_user_nombre" runat="server"></asp:TextBox>
                    <label>Username: </label>
                    <asp:TextBox ID="txt_user_username" runat="server"></asp:TextBox>
                    <label>Pass: </label>
                    <asp:TextBox ID="txt_user_pass" runat="server"></asp:TextBox>
                    <label>Mail: </label>
                    <asp:TextBox ID="txt_user_mail" runat="server"></asp:TextBox>
                    <asp:CheckBox ID="check_user_admin" Text="Admin" runat="server"/>
                </div>
                <asp:Button ID="btn_add" Text="Añadir" onClick="btn_add_Click" runat="server"/>
            </div>
            <div class="elementos_gestion" id="expositor_gestion" runat="server">

            </div>
        </div>

        <asp:HiddenField id="selectedElem" Value="" runat="server"/>
        <asp:HiddenField id="gest_estado" Value="" runat="server"/>
    </div>
</asp:Content>
