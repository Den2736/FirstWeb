<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h3>Зарегестрированные пользователи</h3>
        <asp:Table ID="UsersTable" runat="server" 
            CellPadding="20" 
            GridLines="Vertical"
            HorizontalAlign="Left">
        </asp:Table>
    </div>
    </asp:Content>
