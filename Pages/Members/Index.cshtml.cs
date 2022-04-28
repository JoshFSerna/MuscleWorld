using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MuscleWorld.Data;
using MuscleWorld.Models;

namespace MuscleWorld.Pages.Members
{
    [Authorize(Roles = "User")]
    public class IndexModel : PageModel
    {
        private readonly MuscleWorld.Data.MuscleWorldContext _context;

        public IndexModel(MuscleWorld.Data.MuscleWorldContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchStringID { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchStringFirstName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchStringLastName { get; set; }

        public async Task OnGetAsync()
        {
            var member = from m in _context.Member
                         select m;


            if (!string.IsNullOrEmpty(SearchStringID))
            {
                int searchID = Int32.Parse(SearchStringID);
                member = member.Where(s => s.ID == searchID);
            }

            if (!string.IsNullOrEmpty(SearchStringFirstName))
            {
                member = member.Where(s => s.FirstName.Contains(SearchStringFirstName));
            }

            if (!string.IsNullOrEmpty(SearchStringLastName))
            {
                member = member.Where(s => s.LastName.Contains(SearchStringLastName));
            }

            Member = await member.ToListAsync();
        }
    }
}
