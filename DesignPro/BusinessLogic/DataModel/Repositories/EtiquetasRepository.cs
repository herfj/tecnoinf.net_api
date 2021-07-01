using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resistencia.Database;

namespace BusinessLogic.DataModel.Repositories
{
    class EtiquetasRepository
    {
        private readonly design_proEntities _context;

        public EtiquetasRepository(design_proEntities context)
        {
            this._context = context;
        }

        public Etiquetas get(int ID)
        {
            var EtiquetasEntity = this._context.Etiquetas.Where(c => c.ID == ID).FirstOrDefault();
            return EtiquetasEntity;
        }

        public List<Etiquetas> GetAll()
        {
            var entityList = this._context.Etiquetas.Select(s => s).ToList();
            return entityList;
        }

        public bool Any(int ID)
        {
            var exists = this._context.Etiquetas.Any(s => s.ID == ID);
            return exists;
        }

        public void Create(Etiquetas eti)
        {
            this._context.Etiquetas.Add(eti);
        }

        public void Delete(int ID)
        {
            var entity = this.get(ID);
            this._context.Etiquetas.Remove(entity);
        }
    }
}
