<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MainMaster.Master" AutoEventWireup="true" CodeBehind="Stocktaking.aspx.cs" Inherits="Msmf.admin.Stocktaking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainConten" runat="server">
       <asp:DropDownList  ID="listCatgory1"  runat="server"  Font-Size="Large" BackColor="YellowGreen" AutoPostBack="true"  on
               <asp:DropDownList ID="listModels"   runat="server" Font-Size="Large" BackColor="YellowGreen" AutoPostBack="true" OnSelectedIndexChanged="listModels_SelectedIndexChanged" />
</asp:Content>
