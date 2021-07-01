using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resistencia.Database;

namespace BusinessLogic.DataModel.Repositories
{
    class PortfolioRepository
    {
        private readonly design_proEntities _context;

        public PortfolioRepository(design_proEntities context)
        {
            this._context = context;
        }

        public Portfolio get(int ID)
        {
            var PagesEntity = this._context.Portfolio.Where(c => c.ID == ID).FirstOrDefault();
            return PagesEntity;
        }

        public List<Portfolio> GetAll()
        {
            var entityList = this._context.Portfolio.Select(s => s).ToList();
            return entityList;
        }

        public bool Any(int ID)
        {
            var exists = this._context.Portfolio.Any(s => s.ID == ID);
            return exists;
        }

        public void Create(Portfolio port)
        {
            this._context.Portfolio.Add(port);
        }

        public void Delete(int ID)
        {
            var entity = this.get(ID);
            this._context.Portfolio.Remove(entity);
        }
    }
}
