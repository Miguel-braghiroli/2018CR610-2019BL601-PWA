using System.ComponentModel.DataAnnotations;

namespace P2_2018CR610_2019BL601.Models
{
    public class Departamentos
    {
        [Key]
        public int departamento_id { get; set; }
        public string departamento { get; set; }
    }
}
