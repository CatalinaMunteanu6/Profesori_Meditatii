using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Profesori_Meditatii.Data;
using Profesori_Meditatii.Models;

namespace Profesori_Meditatii.Pages.Studenti
{
    public class IndexModel : PageModel
    {
        private readonly Profesori_Meditatii.Data.Profesori_MeditatiiContext _context;

        public IndexModel(Profesori_Meditatii.Data.Profesori_MeditatiiContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Student = await _context.Student
                .Include(s => s.Materie)
                .ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync(Student student)
        {
            if (!ModelState.IsValid)
            {
                // Dacă modelul nu este valid, rămâne pe pagină
                return Page();
            }

            // Adăugăm un singur student în context (presupunând că variabila `student` este un singur obiect de tip Student)
            _context.Student.Add(student);

            // Salvăm modificările în baza de date
            await _context.SaveChangesAsync();

            // Redirecționăm la pagina Index
            return RedirectToPage("./Index");
        }


    }
}