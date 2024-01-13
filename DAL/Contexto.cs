using Microsoft.EntityFrameworkCore;
using RegistroDePrioridadesMABB1.Models;

namespace RegistroDePrioridadesMABB1.DAL
{
    public class Contexto:DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Prioridades> Prioridades { get; set; }
    }
}
