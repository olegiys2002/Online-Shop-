
namespace КурсовойИнтернетМагазин.Models
{
    public static class RoleInitializer
    {
        
        public static async Task InitializeRoles(UserManager<IdentityUser> _userManager, RoleManager<IdentityRole> roleManager,IConfiguration _configuration)
        {
            string adminName = _configuration["AdminInformation:UserName"];
            string adminEmail = _configuration["AdminInformation:UserEmail"];
            string adminPassword = _configuration["AdminInformation:Password"];
            if (!await roleManager.RoleExistsAsync("admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }

            if (!await roleManager.RoleExistsAsync("customer"))
            {
                await roleManager.CreateAsync(new IdentityRole("customer"));
            }
            if (_userManager.FindByEmailAsync(adminEmail) == null) {
                IdentityUser admin = new IdentityUser()
                {
                    UserName = adminName,
                    Email = adminEmail,

                };

                var result = await _userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(admin, "admin");
                }


            }



        }
    }
}
