using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("estudiantes")]
    public class Estudiante
    {
        [Key]
        public int Id { get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public string correo { get; set; }

        

    }
}
