using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MuscleWorld.Data;

namespace MuscleWorld.Pages
{
    [Authorize(Roles = "Admin")]
    public class UserListModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserListModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IList<IdentityUser> User { get; set; }


        public async Task OnGetAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            User = users;
        }

    }


}