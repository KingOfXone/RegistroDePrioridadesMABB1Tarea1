using Microsoft.EntityFrameworkCore;
using RegistroDePrioridadesMABB1.DAL;
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

        public bool Existe(int prioridadID)
        {
            return _contexto.Prioridades.Any(p => p.PrioridadId == prioridadID);
        }

        public bool Guardar(Prioridades prioridades)
        {
            if (!Existe(prioridades.PrioridadId)) return this.Insertar(prioridades);
            else return this.Modificar(prioridades);
        }
        public bool Eliminar(Prioridades Prioridades)
        {
            var p = _contexto.Prioridades.Find(Prioridades.PrioridadId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(Prioridades).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
        }
        public bool Modificar(Prioridades Prioridades)
        {
            var p = _contexto.Prioridades.Find(Prioridades.PrioridadId);
            _contexto.Entry(p!).State = EntityState.Detached;
            _contexto.Entry(Prioridades).State = EntityState.Modified;
            return _contexto.SaveChanges() > 0;
        }
        public bool Insertar(Prioridades Prioridades)
        {
            _contexto.Prioridades.Add(Prioridades);
            return _contexto.SaveChanges() == 0;
        }
        public Prioridades? Buscar(int PrioridadId)
        {
            return _contexto.Prioridades
                    .AsNoTracking()
                    .SingleOrDefault(a => a.PrioridadId == PrioridadId);
        }
        public List<Prioridades> Listar(Expression<Func<Prioridades, bool>> Criterio)
        {
            return _contexto.Prioridades.Where(Criterio).AsNoTracking().ToList();
        }
      }
    }
