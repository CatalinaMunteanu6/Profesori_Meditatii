using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Profesori_Meditatii.Models;

namespace Profesori_Meditatii.Data
{
    public class Profesori_MeditatiiContext : DbContext
    {
        public Profesori_MeditatiiContext (DbContextOptions<Profesori_MeditatiiContext> options)
            : base(options)
        {
        }

        public DbSet<Profesori_Meditatii.Models.Profesor> Profesor { get; set; } = default!;
        public DbSet<Profesori_Meditatii.Models.Materie> Materie { get; set; } = default!;
        public DbSet<Profesori_Meditatii.Models.Student> Student { get; set; } = default!;
    }
}
