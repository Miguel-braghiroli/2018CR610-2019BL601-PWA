using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P2_2018CR610_2019BL601.Models
{
    public class Casos
    {
        [Key]
        public int caso_id { get; set; }

        [NotMapped]
        public string departamento { get; set; }

        [Required]
        [Display(Name = "Departamento")]
        public int departamento_id { get; set; }

        [NotMapped]
        public string genero { get; set; }

        [Required]
        [Display(Name = "Genero")]
        public int genero_id { get; set; }

        [Required]
        [Display(Name = "Confirmados")]
        public int confirmados { get; set; }

        [Required]
        [Display(Name = "Recuperados")]
        public int recuperados { get; set; }

        [Required]
        [Display(Name = "Fallecidos")]
        public int fallecidos { get; set; }
    }
}
