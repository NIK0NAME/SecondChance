<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SecondChances._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <%--<div class="main-container">
       <div class="dashboard">
            <h1 runat="server" id="whois" style="color: #ccc;"></h1>
       </div>
   </div>--%>
    <!-- ##### Welcome Area Start ##### 
    <section class="welcome_area bg-img background-overlay" style="background-image: url(img/bg-img/bg-1.jpg);">
        <div class="container h-100">
            <div class="row h-100 align-items-center">
                <div class="col-12">
                    <div class="hero-content">
                        <h6>asoss</h6>
                        <h2>New Collection</h2>
                        <a href="#" class="btn essence-btn">view collection</a>
                    </div>
                </div>
            </div>
        </div>
    </section>-->
    <!-- ##### Welcome Area End ##### -->
    <div class="sec_products">
        <div class="filter_prod"></div>
        <div class="prod_list" runat="server" id="pr_list">
            
        </div>
    </div>

</asp:Content>
