<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionHistory.aspx.cs" Inherits="KpopZtation.View.User.TransactionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="TransactionGridView" runat="server" AutoGenerateColumns="false" OnRowDeleting="TransactionGridView_RowDeleting">
        <Columns>
            <asp:BoundField HeaderText="Transaction ID" DataField="TransactionID"/>
            <asp:BoundField HeaderText="Customer Name" DataField="CustomerName"/>
            <asp:CommandField ButtonType="Button" HeaderText="Action" ShowDeleteButton="true" DeleteText="See Details" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
     <asp:GridView ID="CartGridView" runat="server" AutoGenerateColumns="false" OnRowDataBound="CartGridView_RowDataBound" Visible="false">
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
        </Columns>
    </asp:GridView>
</asp:Content>
