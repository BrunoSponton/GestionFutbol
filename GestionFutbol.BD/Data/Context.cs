using GestionFutbol.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFutbol.BD.Data
{
    public class Context : DbContext
    {
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<Entrenamiento> Entrenamientos { get; set; }
        public DbSet<EstPartido> EstPartidos { get; set; }
        public DbSet<AsistEntrenamiento> AsistEntrenamientos { get; set; }

        public Context(DbContextOptions options) :base(options) 
        {
        }
    }
}
