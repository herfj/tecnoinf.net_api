using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resistencia.Database;

namespace BusinessLogic.DataModel.Repositories
{
    class CategoriaRepository
    {
        private readonly design_proEntities _context;

        public CategoriaRepository(design_proEntities context)
        {
            this._context = context;
        }

        public Categoria get(string Nombre)
        {
            var CategoriaEntity = this._context.Categoria.Where(c => c.Nombre == Nombre).FirstOrDefault();
            return CategoriaEntity;
        }

        public List<Categoria> GetAll()
        {
            var entityList = this._context.Categoria.Select(s => s).ToList();
            return entityList;
        }

        public bool Any(string Nombre)
        {
            var exists = this._context.Categoria.Any(s => s.Nombre == Nombre);
            return exists;
        }

        public void Create(Categoria cat)
        {
            this._context.Categoria.Add(cat);
        }

        public void Delete(string Nombre)
        {
            var entity = this.get(Nombre);
            this._context.Categoria.Remove(entity);
        }
    }
}
