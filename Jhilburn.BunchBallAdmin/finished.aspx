<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="finished.aspx.cs" Inherits="Jhilburn.BunchBallAdmin.finished" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" ID="lblFinished">Records have been updated. </asp:Label>
    <asp:HyperLink runat="server" NavigateUrl="~/AddBunchBallAction.aspx">Click here to return to admin page.</asp:HyperLink>
</asp:Content>
