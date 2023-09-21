<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="Artist.aspx.cs" Inherits="KpopZtation.View.User.Artist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="ArtistNamelbl" runat="server" Text="Artist Name: "></asp:Label>
    <asp:TextBox ID="ArtistNameTxb" runat="server" Enabled="false"></asp:TextBox>
    <br />
    <asp:Image ID="ArtistImg" runat="server" Width="100px" Height="100px" />
    <br />
    <br />
    <asp:GridView ID="AlbumGridView" runat="server" AutoGenerateColumns="false" OnRowDataBound="AlbumGridView_RowDataBound" OnRowEditing="AlbumGridView_RowEditing" OnRowDeleting="AlbumGridView_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="Album Image">
                <ItemTemplate>
                    <asp:ImageButton ID="ImageBtn" runat="server" OnClick="ImageBtn_Click" Width="100px" Height="100px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Album Name" DataField="AlbumName"/>
            <asp:BoundField HeaderText="Album Price" DataField="AlbumPrice"/>
            <asp:BoundField HeaderText="Album Stock" DataField="AlbumStock"/>
            <asp:BoundField HeaderText="Album Description" DataField="AlbumDescription"/>
            <asp:CommandField ButtonType="Button" HeaderText="Action" ShowEditButton="true" ShowDeleteButton="true" DeleteText="Delete" EditText="Update" Visible="false" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="InsertBtn" runat="server" Text="Insert Album" OnClick="InsertBtn_Click" Visible="false" />
</asp:Content>
