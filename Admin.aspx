<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Account_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>Это страница для администраторов</h2>
    <div class="form-horizontal">
        <h4>Форма задания ролей</h4>
        <asp:ListView runat="server" ID ="UsersWithNoRolesListView"
                    ItemType="WebSite.ApplicationUser"
                    SelectMethod="GetUsersWithNoRoles" DeleteMethod="RemoveLogin" >

                    <LayoutTemplate>
                        <table class="table">
                            <tbody>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </tbody>
                        </table>

                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label runat="server" id= "UserNameLabel" Text ="<%#:Item.UserName%>"> 
                                </asp:Label>
                            </td>
                            <td> 
                                <asp:DropDownList runat="server" ID ="ChooseRoleDDList" 
                                    Visible="<%# ThereAreUsersWithNoRoles %>" 
                                    OnSelectedIndexChanged ="RoleChanged">
                                    <asp:ListItem Selected ="True" Value = "RoleIsNotChosen">- роль не задана -</asp:ListItem>
                                    <asp:ListItem Value ="admin">Администратор</asp:ListItem>
                                    <asp:ListItem Value ="manager">Директор</asp:ListItem>
                                    <asp:ListItem Value ="seller">Продавец</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button runat="server"  ID="SetRoleButton"
                                    Text= 'Назначить роль'  
                                    CommandName="Set" CausesValidation="false"
                                    ToolTip='<%# "Назначить пользователю " + Item.UserName + " роль"%>'
                                    Visible="<%# ThereAreUsersWithNoRoles %>" CssClass="btn btn-default" OnClick="SetRole"/>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
    </div>
</asp:Content>

