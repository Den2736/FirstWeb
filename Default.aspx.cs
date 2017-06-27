using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TableRow row = new TableRow();
        TableCell nameCell = new TableCell();
        nameCell.Controls.Add(new LiteralControl("Имя пользователя"));
        nameCell.Font.Bold = true;
        row.Cells.Add(nameCell);

        TableCell roleCell = new TableCell();
        roleCell.Controls.Add(new LiteralControl("Тип учетной записи"));
        roleCell.Font.Bold = true;
        row.Cells.Add(roleCell);
        UsersTable.Rows.Add(row);

        RolesController rolesController = new RolesController();

        ApplicationDbContext dbUser = new ApplicationDbContext();
        IEnumerable<ApplicationUser> users = dbUser.Users;
        foreach(var user in users)
        {
            row = new TableRow();
            nameCell = new TableCell();
            nameCell.Controls.Add(new LiteralControl(user.UserName));
            row.Cells.Add(nameCell);

            roleCell = new TableCell();
            string role;
            string[] roles;
            try
            {
                roles = Roles.GetRolesForUser(user.UserName);
                role = roles[0];
                if (role == rolesController.AdminRole)
                    role = "Администратор";
                else if (role == rolesController.ManagerRole)
                    role = "Директор";
                else if (role == rolesController.SellerRole)
                    role = "Продавец";
            }
            catch(IndexOutOfRangeException)
            {
                role = "Тип записи еще не был присвоен администратором";
            }
            roleCell.Controls.Add(new LiteralControl(role));
            row.Cells.Add(roleCell);
            UsersTable.Rows.Add(row);
        }
    }

    protected void UserTable_Load(object sender, EventArgs e)
    {
    }
}