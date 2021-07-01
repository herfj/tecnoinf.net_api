using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resistencia.Database;

namespace BusinessLogic.DataModel.Repositories
{
    class VisualRepository
    {
        private readonly design_proEntities _context;

        public VisualRepository(design_proEntities context)
        {
            this._context = context;
        }

        public Visual get(int ID)
        {
            var VisualEntity = this._context.Visual.Where(a => a.ID == ID).FirstOrDefault();
            return VisualEntity;
        }

        public List<Visual> GetAll()
        {
            var entityList = this._context.Visual.Select(s => s).ToList();
            return entityList;
        }

        public bool Any(int ID)
        {
            var exists = this._context.Visual.Any(s => s.ID == ID);
            return exists;
        }

        public void Create(Visual vis)
        {
            this._context.Visual.Add(vis);
        }

        public void Delete(int ID)
        {
            var entity = this.get(ID);
            this._context.Visual.Remove(entity);
        }


    }
}
