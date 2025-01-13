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

namespace Profesori_Meditatii.Pages.Studenti
{
    public class EditModel : PageModel
    {
        private readonly Profesori_Meditatii.Data.Profesori_MeditatiiContext _context;

        public EditModel(Profesori_Meditatii.Data.Profesori_MeditatiiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; } = default!;
        public SelectList Materii { get; set; }
    public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student =  await _context.Student
                .Include(s => s.Materie)
                .FirstOrDefaultAsync(m => m.ID == id);

          
            if (student == null)
            {
                return NotFound();
            }
            Student = student;
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

            _context.Attach(Student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Student.ID))
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

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.ID == id);
        }
    }
}
