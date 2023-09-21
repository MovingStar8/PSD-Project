<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="UpdateAlbum.aspx.cs" Inherits="KpopZtation.View.User.UpdateAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="AlbumNameLbl" runat="server" Text="Album Name:"></asp:Label>
    <asp:TextBox ID="AlbumNameTxb" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="AlbumPriceLbl" runat="server" Text="Album Price:"></asp:Label>
    <asp:TextBox ID="AlbumPriceTxb" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="AlbumStockLbl" runat="server" Text="Album Stock:"></asp:Label>
    <asp:TextBox ID="AlbumStockTxb" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="AlbumDescriptionLbl" runat="server" Text="Album Description:"></asp:Label>
    <asp:TextBox ID="AlbumDescriptionTxb" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="AlbumImageLbl" runat="server" Text="Album Image:"></asp:Label>
    <br />
    <asp:FileUpload ID="ImageFile" runat="server" />
    <br />
    <asp:Label ID="ErrorLbl" runat="server" Text="" ForeColor="Red"></asp:Label>
    <br />
    <asp:Button ID="InsertBtn" runat="server" Text="Update Album" OnClick="UpdateBtn_Click" />
    <asp:Button ID="CancelBtn" runat="server" Text="Cancel" OnClick="CancelBtn_Click" />
</asp:Content>
