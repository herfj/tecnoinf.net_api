using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resistencia.Database;

namespace BusinessLogic.DataModel.Repositories
{
    class ComentariosRepository
    {
        private readonly design_proEntities _context;

        public ComentariosRepository(design_proEntities context)
        {
            this._context = context;
        }

        public Comentarios get(int ID)
        {
            var ComentariosEntity = this._context.Comentarios.Where(c => c.ID == ID).FirstOrDefault();
            return ComentariosEntity;
        }

        public List<Comentarios> GetAll()
        {
            var entityList = this._context.Comentarios.Select(s => s).ToList();
            return entityList;
        }

        public bool Any(int ID)
        {
            var exists = this._context.Comentarios.Any(s => s.ID == ID);
            return exists;
        }

        public void Create(Comentarios com)
        {
            this._context.Comentarios.Add(com);
        }

        public void Delete(int ID)
        {
            var entity = this.get(ID);
            this._context.Comentarios.Remove(entity);
        }
    }
}
