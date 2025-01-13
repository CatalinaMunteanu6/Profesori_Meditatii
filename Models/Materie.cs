using System.ComponentModel.DataAnnotations;

namespace Profesori_Meditatii.Models
{
    public class Materie
    {
        public int ID { get; set; }

        [Display(Name = "Denumire Materie")]
        public string NumeMaterie { get; set; }

        public ICollection<Profesor>? Profesori { get; set; } // relație cu Profesor
    }

}
