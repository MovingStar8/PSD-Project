<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="KpopZtation.View.Guest.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="NameLbl" runat="server" Text="Name: "></asp:Label>
    <asp:TextBox ID="NameTxb" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="EmailLbl" runat="server" Text="Email: "></asp:Label>
    <asp:TextBox ID="EmailTxb" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="GenderLbl" runat="server" Text="Gender: "></asp:Label>
    <asp:RadioButtonList ID="GenderRadioBtn" runat="server">
        <asp:ListItem Text="Male"></asp:ListItem>
        <asp:ListItem Text="Female"></asp:ListItem>
    </asp:RadioButtonList>
    <asp:Label ID="AddressLbl" runat="server" Text="Address: "></asp:Label>
    <asp:TextBox ID="AddressTxb" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="PasswordLbl" runat="server" Text="Password: "></asp:Label>
    <asp:TextBox ID="PasswordTxb" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Label ID="ErrorLbl" runat="server" Text="" ForeColor="Red"></asp:Label>
    <br />
    <asp:Button ID="RegisterBtn" runat="server" Text="Register" OnClick="RegisterBtn_Click" />

</asp:Content>
