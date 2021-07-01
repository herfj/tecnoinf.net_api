using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resistencia.Database;

namespace BusinessLogic.DataModel.Repositories
{
    class ProyectoRepository
    {
        private readonly design_proEntities _context;

        public ProyectoRepository(design_proEntities context)
        {
            this._context = context;
        }

        public Proyecto get(string Titulo)
        {
            var ProyectoEntity = this._context.Proyecto.Where(a => a.Titulo == Titulo).FirstOrDefault();
            return ProyectoEntity;
        }

        public List<Proyecto> GetAll()
        {
            var entityList = this._context.Proyecto.Select(s => s).ToList();
            return entityList;
        }

        public bool Any(string Titulo)
        {
            var exists = this._context.Proyecto.Any(s => s.Titulo == Titulo);
            return exists;
        }

        public void Create(Proyecto vis)
        {
            this._context.Proyecto.Add(vis);
        }

        public void Delete(string Titulo)
        {
            var entity = this.get(Titulo);
            this._context.Proyecto.Remove(entity);
        }
    }
}
