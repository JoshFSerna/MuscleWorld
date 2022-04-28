using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MuscleWorld.Pages
{
    public class UserList_RemoveRoleModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserList_RemoveRoleModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [BindProperty]
        public IdentityUser User { get; set; }

        public async Task<IActionResult> OnGetAsync(String Id)
        {

            if (Id == null)
            {
                return NotFound();
            }


            User = await _userManager.Users.FirstOrDefaultAsync(m => m.Id.Equals(Id));


            if (User == null)
            {
                return NotFound();
            }

            await _userManager.RemoveFromRoleAsync(User, "User");


            return RedirectToPage("./Index");
        }

    }
}
