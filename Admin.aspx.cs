using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite;

public partial class Account_Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    
    protected bool ThereAreUsersWithNoRoles
    {
        get;
        private set;
    }

    private string choosenRole = "RoleIsNotChosen";

    public IEnumerable<ApplicationUser> GetUsersWithNoRoles()
    {
        ApplicationDbContext dbUser = new ApplicationDbContext();
        IEnumerable<ApplicationUser> users = dbUser.Users;
        var usersWithNoRoles = users.Where(user => HasNoRoles(user));
        // проверка IEnumerable на число элементов не получилась
        foreach (var user in usersWithNoRoles)
            if (HasNoRoles(user))
            {
                ThereAreUsersWithNoRoles = true;
                break;
            }
        return usersWithNoRoles;
    }

    private bool HasNoRoles(ApplicationUser user)
    {
        string[] roles = Roles.GetRolesForUser(user.UserName);
        return roles.Length == 0;
    }

    public void RemoveLogin(string loginProvider, string providerKey)
    {
    }

    protected void RoleChanged(object sender, EventArgs e)
    {
        choosenRole = (sender as DropDownList).SelectedValue;
    }

    protected void SetRole(object sender, EventArgs e)
    {
        if (choosenRole != "RoleIsNotChosen")
        {
            int index;
            for (index = 0; index < UsersWithNoRolesListView.Controls.Count; index++)
            {
                // ищем, в каком элементе была нажата кнопка и запоминаем индекс
                Button currItemButton = (Button)UsersWithNoRolesListView.Items[index].FindControl("SetRoleButton");
                if (currItemButton.Equals(sender as Button))
                {
                    string userName = ((Label)UsersWithNoRolesListView.Items[index].FindControl("UserNameLabel")).Text;
                    string role = choosenRole;
                    Roles.AddUserToRole(userName, role);
                    UsersWithNoRolesListView.DeleteItem(index);
                    break;
                }
            }
        }
    }
}