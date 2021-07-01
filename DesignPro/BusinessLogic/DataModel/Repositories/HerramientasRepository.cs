using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resistencia.Database;

namespace BusinessLogic.DataModel.Repositories
{
    class HerramientasRepository
    {
        private readonly design_proEntities _context;

        public HerramientasRepository(design_proEntities context)
        {
            this._context = context;
        }

        public Herramientas get(int ID)
        {
            var HerramientasEntity = this._context.Herramientas.Where(c => c.ID == ID).FirstOrDefault();
            return HerramientasEntity;
        }

        public List<Herramientas> GetAll()
        {
            var entityList = this._context.Herramientas.Select(s => s).ToList();
            return entityList;
        }

        public bool Any(int ID)
        {
            var exists = this._context.Herramientas.Any(s => s.ID == ID);
            return exists;
        }

        public void Create(Herramientas her)
        {
            this._context.Herramientas.Add(her);
        }

        public void Delete(int ID)
        {
            var entity = this.get(ID);
            this._context.Herramientas.Remove(entity);
        }
    }
}
