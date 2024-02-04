using ClientesMABB.DAL;
using Microsoft.EntityFrameworkCore;
using RegistroDePrioridadesMABB1.Models;
using System.Linq.Expressions;

namespace RegistroDePrioridadesMABB1.BLL
{
    public class PrioridadesBLL
    {
        private readonly Contexto _contexto;
        public PrioridadesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }
        public bool Existe(int PrioridadId)
        {
            return _contexto.Prioridad.Any(p => p.PrioridadId == PrioridadId);

        }
        public bool Guardar(Prioridades Prioridades)
        {
            if (!Existe(Prioridades.PrioridadId))
                return this.Insertar(Prioridades);
            else
                return this.Modificar(Prioridades);
        }
        public bool Eliminar(int id)
        {
            var prioridades = _contexto.Prioridad.Find(id);
            _contexto.Prioridad.Remove(prioridades);
            var deleted = _contexto.SaveChanges() > 0;
            return deleted;
        }
        public async Task<Prioridades?> Buscar(int id)
        {
            return await _contexto.Prioridad.FindAsync(id);
        }
        public bool Insertar(Prioridades Prioridades)
        {
            _contexto.Prioridad.Add(Prioridades);
            return _contexto.SaveChanges() > 0;
        }
        public bool Modificar(Prioridades Prioridades)
        {
            var p = _contexto.Prioridad.Find(Prioridades.PrioridadId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(Prioridades).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }
        public List<Prioridades> Getlist(Expression<Func<Prioridades, bool>> criterio)
        {
            return _contexto.Prioridad.Where(criterio).AsNoTracking().ToList();
        }
    }
}