<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KpopZtation.View.Guest.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="EmailLbl" runat="server" Text="Email: "></asp:Label>
    <asp:TextBox ID="EmailTxb" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="PasswordLbl" runat="server" Text="Password: "></asp:Label>
    <asp:TextBox ID="PasswordTxb" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <asp:CheckBox ID="RememberMeCB" runat="server" Text="Remember Me"/>
    <br />
    <asp:Label ID="ErrorLbl" runat="server" Text="" ForeColor="Red"></asp:Label>
    <br />
    <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" />
</asp:Content>
