using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Profesori_Meditatii.Data;
using Profesori_Meditatii.Models;

namespace Profesori_Meditatii.Pages.Materii
{
    public class CreateModel : PageModel
    {
        private readonly Profesori_Meditatii.Data.Profesori_MeditatiiContext _context;

        public CreateModel(Profesori_Meditatii.Data.Profesori_MeditatiiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Materie Materie { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Materie.Add(Materie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
