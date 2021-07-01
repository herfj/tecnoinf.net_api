using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resistencia.Database;

namespace BusinessLogic.DataModel.Repositories
{
    class PagesRepository
    {
        private readonly design_proEntities _context;

        public PagesRepository(design_proEntities context)
        {
            this._context = context;
        }

        public Pages get(int ID)
        {
            var PagesEntity = this._context.Pages.Where(c => c.ID == ID).FirstOrDefault();
            return PagesEntity;
        }

        public List<Pages> GetAll()
        {
            var entityList = this._context.Pages.Select(s => s).ToList();
            return entityList;
        }

        public bool Any(int ID)
        {
            var exists = this._context.Pages.Any(s => s.ID == ID);
            return exists;
        }

        public void Create(Pages page)
        {
            this._context.Pages.Add(page);
        }

        public void Delete(int ID)
        {
            var entity = this.get(ID);
            this._context.Pages.Remove(entity);
        }
    }
}
