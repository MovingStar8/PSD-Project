<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="UpdateArtist.aspx.cs" Inherits="KpopZtation.View.User.UpdateArtist" %>
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
    <asp:Button ID="UpdateBtn" runat="server" Text="Update Artist" OnClick="UpdateBtn_Click" />
    <asp:Button ID="CancelBtn" runat="server" Text="Cancel" OnClick="CancelBtn_Click" />
</asp:Content>
