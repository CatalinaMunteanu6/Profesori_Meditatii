using System.ComponentModel.DataAnnotations;

namespace Profesori_Meditatii.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Required]
        public string Nume { get; set; }

        [Required]
        public string Prenume { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int? MaterieID { get; set; }

        public Materie Materie { get; set; }
    }
}
