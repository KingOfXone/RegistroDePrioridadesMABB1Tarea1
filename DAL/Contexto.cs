using ClientesMABB.Models;
using Microsoft.EntityFrameworkCore;
using TicketsMABB3.Models;

namespace TicketsMABB3.DAL
{
    public class Contexto :DbContext
    {
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Prioridades> Prioridad { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    }
}
