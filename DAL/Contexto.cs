using ClientesMABB.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientesMABB.DAL
{
    public class Contexto:DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    }
}
