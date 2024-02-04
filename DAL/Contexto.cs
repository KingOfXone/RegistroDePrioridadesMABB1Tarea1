using ClientesMABB.Models;
using Microsoft.EntityFrameworkCore;
using RegistroDePrioridadesMABB1.Models;

namespace ClientesMABB.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Prioridades> Prioridad { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    }
}
