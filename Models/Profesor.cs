using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Profesori_Meditatii.Models
{
    public class Profesor
    {
        public int ID { get; set; }

        [Display(Name = "Nume Profesor")]
        public string Nume { get; set; }

        [Display(Name = "Prenume Profesor")]
        public string Prenume { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal TarifulPeOra { get; set; }
        public int? MaterieID { get; set; }
        public Materie? Materie { get; set; } // Navigation property

    }
}
