using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewsWebApp.Data;
using NewsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.Core
{
    public static class Seed
    {
        public static async Task InvokeAsync(IServiceScope scope,NewsDbContext db)
        {
            if (!db.Users.Any())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var configurtaion = scope.ServiceProvider.GetRequiredService<IConfiguration>();

                User admin = new User
                {
                    Name = "Tarlan",
                    Surname = "Usubov",
                    UserName = "NewstoreAdmin505",
                    Email = "admin@newstore.az"
                };

                User user = new User()
                {
                    Name = "Sarkhan",
                    Surname = "Mirzeyev",
                    Email = "sarkhan@code.edu.az",
                    UserName = "DeliSerxan"
                };

                var adminCreateResult =  await userManager.CreateAsync(admin, configurtaion["Admin:Password"]);
                var userCreateResult = await userManager.CreateAsync(user, "Serxan123@");

                if (adminCreateResult.Succeeded)
                {
                    var roleCreateResult=  await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
                    if (roleCreateResult.Succeeded)
                    {
                        var roleAddResult = await userManager.AddToRoleAsync(admin, "Admin");
                    }
                }

            }
        }
    }
}
