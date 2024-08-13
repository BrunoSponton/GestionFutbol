using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFutbol.BD.Data.Entity
{
    public class EstPartido : EntityBase
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(2, ErrorMessage = "Maximo numero de caracteres {1}")]
        public int Goles { get; set; }
        
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(2, ErrorMessage = "Maximo numero de caracteres {1}")]
        public int Asistencias { get; set; }
        
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(3, ErrorMessage = "Maximo numero de caracteres {1}")]
        public int MinutosJugados { get; set; }

        public int JugadorId { get; set; }
        public Jugador Jugador { get; set; }

        public int PartidoId { get; set; }
        public Partido Partido { get; set; }

        public List<Jugador> Jugadores { get; set; }
        public List <Partido> Partidos { get; set; }
    }
}
