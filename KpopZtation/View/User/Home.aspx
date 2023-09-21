<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="KpopZtation.View.User.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="ArtistGridView" runat="server" AutoGenerateColumns="false" OnRowDataBound="ArtistGridView_RowDataBound" OnRowEditing="ArtistGridView_RowEditing" OnRowDeleting="ArtistGridView_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="Artist Image">
                <ItemTemplate>
                    <asp:ImageButton ID="ImageBtn" runat="server" OnClick="ImageBtn_Click" Width="100px" Height="100px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Artist Name" DataField="ArtistName"/>
            <asp:CommandField ButtonType="Button" HeaderText="Action" ShowEditButton="true" ShowDeleteButton="true" DeleteText="Delete" EditText="Update" Visible="false"/>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="InsertBtn" runat="server" Text="Insert Artist" OnClick="InsertBtn_Click" Visible="false" />
</asp:Content>
