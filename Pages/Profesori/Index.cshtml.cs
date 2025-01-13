using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Profesori_Meditatii.Data;
using Profesori_Meditatii.Models;

namespace Profesori_Meditatii.Pages.Profesori
{
    public class IndexModel : PageModel
    {
        private readonly Profesori_Meditatii.Data.Profesori_MeditatiiContext _context;

        public IndexModel(Profesori_Meditatii.Data.Profesori_MeditatiiContext context)
        {
            _context = context;
        }

        public IList<Profesor> Profesor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Profesor = await _context.Profesor
                .Include(p => p.Materie) // Include relația Materie
                .ToListAsync();
        }
    }
}
