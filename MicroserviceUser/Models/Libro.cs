using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceUser.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }
        //le muestra al usuario que es obligatorio
        [Required(ErrorMessage = "el titulo es obligatorio")]
        //Obliga al usuario a tener entre 3 y 50 caracteres y si no cumple nos arroja un mensaje
        [StringLength(50, ErrorMessage = "EL {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        //Esto es por si necesitamos que sea con tilde pero en DB no tiene tilde
        [Display(Name = "Tìtulo")]

        public string titulo { get; set; }

        [Required(ErrorMessage = "la descripcion es obligatorio")]
        [StringLength(50, ErrorMessage = "EL {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Descripciòn")]

        public string descripcion { get; set; }

        [Required(ErrorMessage = "la fecha es obligatorio")]
        //Aca le damos formato a la hora, solo queremos la fecha
        [DataType(DataType.Date)]

        public DateTime fechaDeLanzamiento { get; set; }

        [Required(ErrorMessage = "el autor es obligatorio")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "el precio es obligatorio")]

        public int precio { get; set; }
    }
}
