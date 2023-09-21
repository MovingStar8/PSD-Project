<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="KpopZtation.View.User.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="CartGridView" runat="server" AutoGenerateColumns="false" OnRowDataBound="CartGridView_RowDataBound" OnRowDeleting="CartGridView_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="Album Image">
                <ItemTemplate>
                    <asp:Image ID="ImageBtn" runat="server" Width="100px" Height="100px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Album Name" DataField="AlbumName"/>
            <asp:BoundField HeaderText="Album Price" DataField="AlbumPrice"/>
            <asp:BoundField HeaderText="Album Description" DataField="AlbumDescription"/>
            <asp:BoundField HeaderText="Quantity" DataField="AlbumStock"/>
            <asp:CommandField ButtonType="Button" HeaderText="Action" ShowDeleteButton="true" DeleteText="Remove"  />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="CheckoutBtn" runat="server" Text="Checkout" OnClick="CheckoutBtn_Click" />
</asp:Content>
