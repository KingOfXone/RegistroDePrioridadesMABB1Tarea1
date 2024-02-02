using ClientesMABB.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TicketsMABB3.DAL;

namespace ClientesMABB.BLL
{
    public class ClientesBLL
    {
        private Contexto _contexto;

        public ClientesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int id)
        {
            return _contexto.Clientes.Any(o => o.ClienteId == id);
        }
        private bool Insertar(Cliente clientes)
        {
            _contexto.Clientes.Add(clientes);
            return _contexto.SaveChanges() > 0;
        }

        private bool Modificar(Cliente cliente)
        {
            var PrioridadADesechar = _contexto.Clientes.Find(cliente.ClienteId);
            if (cliente != null)
            {
                _contexto.Entry(PrioridadADesechar).State = EntityState.Detached;
                _contexto.Entry(cliente).State = EntityState.Modified;
                return _contexto.SaveChanges() > 0;
            }
            return false;

        }

        public bool Guardar(Cliente cliente)
        {
            if (_contexto.Clientes.Any(p => p.ClienteId != cliente.ClienteId && p.Rnc == cliente.Rnc || p.Nombres == cliente.Nombres))
            {
                return false;
            }
            if (!Existe(cliente.ClienteId))
                return Insertar(cliente);
            else
                return Modificar(cliente);
        }

        public bool Eliminar(Cliente cliente)
        {


            if (cliente != null)
            {
                _contexto.Entry(cliente).State = EntityState.Deleted;
                return _contexto.SaveChanges() > 0;
            }
            return false;

        }

        public Cliente? Buscar(int id)
        {
            return _contexto.Clientes.Where(o => o.ClienteId == id).AsNoTracking().SingleOrDefault(); ;
        }

        public List<Cliente> BuscarPorId(int id)
        {
            return _contexto.Clientes.AsNoTracking().Where(c => c.ClienteId == id).ToList();
        }

        public List<Cliente> GetList(Expression<Func<Cliente, bool>> criterio)
        {
            return _contexto.Clientes.AsNoTracking().Where(criterio).ToList();
        }
        public List<Cliente> GetList()
        {
            return _contexto.Clientes.AsNoTracking().ToList();
        }
    }
}