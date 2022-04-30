using System.ComponentModel.DataAnnotations;

namespace P2_2018CR610_2019BL601.Models
{
    public class Generos
    {
        [Key]
        public int genero_id { get; set; }
        public string genero { get; set; }
    }
}
