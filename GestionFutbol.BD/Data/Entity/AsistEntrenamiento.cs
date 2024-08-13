using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFutbol.BD.Data.Entity
{
    public class AsistEntrenamiento : EntityBase
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public bool Asistio { get; set; }

        public int JugadorId { get; set; }
        public Jugador Jugador { get; set; }

        public int EntrenamientoId { get; set; }
        public Entrenamiento Entrenamiento { get; set; }

        public List<Jugador> Jugadores { get; set; }
        public List<Entrenamiento> Entrenamientos { get; set; }
    }
}
