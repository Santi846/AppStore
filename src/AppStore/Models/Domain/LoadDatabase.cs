using Microsoft.AspNetCore.Identity;

namespace AppStore.Models.Domain;

public class LoadDatabase{
    public static async Task InsertData(DatabaseContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager){

        //if there is not data receiben
        if (!roleManager.Roles.Any())
        {
            await roleManager.CreateAsync(new IdentityRole("ADMIN"));
        }

        if (!userManager.Users.Any())
        {
            var user = new ApplicationUser {
                Nombre = "Vaxi Dres",
                Email = "vdres@work.com.uy",
                UserName = "vdres"
            };

        }

    }
};