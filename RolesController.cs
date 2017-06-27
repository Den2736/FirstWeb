using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Providers.Entities;
using WebSite;

/// <summary>
/// Сводное описание для RolesController
/// </summary>
public class RolesController
{
    public RolesController()
    {
        //
        // TODO: добавьте логику конструктора
        //
    }

    public void CreateRoles()
    {
        using (var context = new ApplicationDbContext())
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists(AdminRole))
            {
                var role = new IdentityRole { Name = AdminRole };
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists(ManagerRole))
            {
                var role = new IdentityRole { Name = ManagerRole };
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists(SellerRole))
            {
                var role = new IdentityRole { Name = SellerRole };
                roleManager.Create(role);
            }
        }
    }

    public string AdminRole
    {
        get
        {
            return "admin";
        }
    }
    public string SellerRole
    {
        get
        {
            return "seller";
        }
    }
    public string ManagerRole
    {
        get
        {
            return "manager";
        }
    }
}