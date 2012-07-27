<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBunchBallAction.aspx.cs" Inherits="Jhilburn.BunchBallAdmin.AddBunchBallAction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" ID="Label2">Action</asp:Label>
    <asp:DropDownList ID="ddlAction" runat="server" ClientIDMode="Static"></asp:DropDownList> 
    <br /><br />
    <asp:Label runat="server" Text="User" ID="lblUser">Users (must be comma delimited)</asp:Label>
    <br />

    <asp:TextBox ID="txtUserId" runat="server" ClientIDMode="Static" TextMode="MultiLine"></asp:TextBox>
    <br />
    <br />
    <asp:Label runat="server" Text="Value" ID="Label1"></asp:Label>
    <br />
    <asp:TextBox ID="txtValue" runat="server" ClientIDMode="Static"></asp:TextBox>  
    <br />
    <br />
    <asp:Button ID="btnSubmit" runat="server" ClientIDMode="Static" Text="Submit" OnClick="btnSubmit_Click"/>
</asp:Content>
