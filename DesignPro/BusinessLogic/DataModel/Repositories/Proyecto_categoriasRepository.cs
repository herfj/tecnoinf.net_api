using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resistencia.Database;

namespace BusinessLogic.DataModel.Repositories
{
    class Proyecto_categoriasRepository
    {
        private readonly design_proEntities _context;

        public Proyecto_categoriasRepository(design_proEntities context)
        {
            this._context = context;
        }

        public Proyecto_categorias get(int ID)
        {
            var ProyectoEntity = this._context.Proyecto_categorias.Where(a => a.ID == ID).FirstOrDefault();
            return ProyectoEntity;
        }

        public List<Proyecto_categorias> GetAll()
        {
            var entityList = this._context.Proyecto_categorias.Select(s => s).ToList();
            return entityList;
        }

        public bool Any(int ID)
        {
            var exists = this._context.Proyecto_categorias.Any(s => s.ID == ID);
            return exists;
        }

        public void Create(Proyecto_categorias vis)
        {
            this._context.Proyecto_categorias.Add(vis);
        }

        public void Delete(int ID)
        {
            var entity = this.get(ID);
            this._context.Proyecto_categorias.Remove(entity);
        }
    }
}
