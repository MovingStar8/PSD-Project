<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="InsertArtist.aspx.cs" Inherits="KpopZtation.View.User.InsertArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="ArtistNameLbl" runat="server" Text="Artist Name:"></asp:Label>
    <asp:TextBox ID="ArtistNameTxb" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="ArtistImageLbl" runat="server" Text="Artist Image:"></asp:Label>
    <br />
    <asp:FileUpload ID="ImageFile" runat="server" />
    <br />
    <asp:Label ID="ErrorLbl" runat="server" Text="" ForeColor="Red"></asp:Label>
    <br />
    <asp:Button ID="InsertBtn" runat="server" Text="Insert Artist" OnClick="InsertBtn_Click" />
</asp:Content>
