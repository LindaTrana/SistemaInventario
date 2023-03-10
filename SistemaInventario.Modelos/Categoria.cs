using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.Modelos
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        [Display(Name = "Nombre Categoria")]
        public string Nombre { get; set; }

        [Required]
        public bool Estado { get; set; }
    }
}
