#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab3_example.Models;
using System.Security.Claims;

namespace lab3_example.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly StoreDBContext _context;

        public IndexModel(StoreDBContext context)
        {
            _context = context;
        }

        public IList<Lab3_example.Models.Product> Product { get; set; }
        public string? UserEmail { get; set; }
        public async Task OnGetAsync()
        {

            Product = await _context.Product.ToListAsync();
            if (User.Identity != null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                if (claimsIdentity.IsAuthenticated)
                {
                    var email = claimsIdentity.FindFirst(ClaimTypes.Email);
                    if (email != null)
                    {
                        UserEmail = email.Value;

                    }
                    // foreach (var cl in claimsIdentity.Claims)
                    // {
                    //    
                    // }
                }
            }

        }




    }
}
