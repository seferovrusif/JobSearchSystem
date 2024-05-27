using JobSearch.Core.Entities;
using JobSearch.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace JobSearch.Api.Helpers
{
    public static class SeedData
    {
        ///TODO:tekrar nezer yetir koda ve bu kodun bir defe islemesi variantini arassdir
        public static IApplicationBuilder UseSeedData(this WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                using (var scope = context.RequestServices.CreateScope())
                {
                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                    await CreateRolesAsync(roleManager);
                    await CreateUsersAsync(userManager, app);

                }
                await next();
            });
            return app;
        }
        static async Task CreateRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.Roles.AnyAsync())
            {
                foreach (var role in Enum.GetNames(typeof(Roles)))
                {
                    var result = await roleManager.CreateAsync(new IdentityRole(role));
                    if (!result.Succeeded)
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (var error in result.Errors)
                        {
                            sb.Append(error.Description + " ");
                        }
                        throw new Exception(sb.ToString().TrimEnd());
                    }
                }
            }
        }
        static async Task CreateUsersAsync(UserManager<AppUser> userManager, WebApplication app)
        {
            if (await userManager.FindByNameAsync(app.Configuration.GetSection("Admin")?["Username"]) == null)
            {
                var user = new AppUser
                {
                    UserName = app.Configuration.GetSection("Admin")["Username"],
                    Email = app.Configuration.GetSection("Admin")["Email"],
                    Name = app.Configuration.GetSection("Admin")["Name"],
                    Surname = app.Configuration.GetSection("Admin")["Surname"],
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(user, app.Configuration.GetSection("Admin")["Password"]);
                if (!result.Succeeded)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var error in result.Errors)
                    {
                        sb.Append(error.Description + " ");
                    }
                    throw new Exception(sb.ToString().TrimEnd());
                }
                var adroleresult= await userManager.AddToRoleAsync(user, nameof(Roles.Admin));
                if (!adroleresult.Succeeded)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var error in adroleresult.Errors)
                    {
                        sb.Append(error.Description + " ");
                    }
                    throw new Exception(sb.ToString().TrimEnd());
                }
            }
        }
    }
}
