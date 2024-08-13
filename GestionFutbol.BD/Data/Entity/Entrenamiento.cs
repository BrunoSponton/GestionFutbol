using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFutbol.BD.Data.Entity
{
    public class Entrenamiento : EntityBase
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Descripcion { get; set; }
    }
}
