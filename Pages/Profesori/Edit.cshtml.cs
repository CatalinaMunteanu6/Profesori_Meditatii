using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Profesori_Meditatii.Data;
using Profesori_Meditatii.Models;

namespace Profesori_Meditatii.Pages.Profesori
{
    public class EditModel : PageModel
    {
        private readonly Profesori_Meditatii.Data.Profesori_MeditatiiContext _context;

        public EditModel(Profesori_Meditatii.Data.Profesori_MeditatiiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Profesor Profesor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           var profesor = await _context.Profesor.FirstOrDefaultAsync(p => p.ID == id);
            if (profesor == null)
            {
                return NotFound();
            }
            Profesor = profesor;

            ViewData["MaterieID"] = new SelectList(_context.Materie, "ID", "NumeMaterie");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            
            if (!ModelState.IsValid)
            {

                return Page();
            }

            _context.Attach(Profesor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesorExists(Profesor.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return RedirectToPage("./Index");
        }

        private bool ProfesorExists(int id)
        {
            return _context.Profesor.Any(e => e.ID == id);
        }
    }
}
