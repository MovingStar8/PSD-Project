<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="Album.aspx.cs" Inherits="KpopZtation.View.User.Album" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="AlbumGridView" runat="server" AutoGenerateColumns="false" OnRowDataBound="AlbumGridView_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="Album Image">
                <ItemTemplate>
                    <asp:Image ID="ImageBtn" runat="server" Width="100px" Height="100px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Album Name" DataField="AlbumName"/>
            <asp:BoundField HeaderText="Album Price" DataField="AlbumPrice"/>
            <asp:BoundField HeaderText="Album Stock" DataField="AlbumStock"/>
            <asp:BoundField HeaderText="Album Description" DataField="AlbumDescription"/>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="ErrorLbl" runat="server" Text="" ForeColor="Red"></asp:Label>
    <br />
    <asp:Label ID="QuantityLbl" runat="server" Text="Quantity:" Visible="false"></asp:Label>
    <asp:TextBox ID="QuantityTxb" runat="server" Visible="false"></asp:TextBox>
    <br />
    <asp:Button ID="AddCartBtn" runat="server" Text="Add To Cart" OnClick="AddCartBtn_Click" Visible="false" />
</asp:Content>
