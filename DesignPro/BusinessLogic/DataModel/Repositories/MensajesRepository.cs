using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resistencia.Database;

namespace BusinessLogic.DataModel.Repositories
{
    class MensajesRepository
    {
        private readonly design_proEntities _context;

        public MensajesRepository(design_proEntities context)
        {
            this._context = context;
        }

        public Mensajes get(int ID)
        {
            var MensajesEntity = this._context.Mensajes.Where(c => c.ID == ID).FirstOrDefault();
            return MensajesEntity;
        }

        public List<Mensajes> GetAll()
        {
            var entityList = this._context.Mensajes.Select(s => s).ToList();
            return entityList;
        }

        public bool Any(int ID)
        {
            var exists = this._context.Mensajes.Any(s => s.ID == ID);
            return exists;
        }

        public void Create(Mensajes men)
        {
            this._context.Mensajes.Add(men);
        }

        public void Delete(int ID)
        {
            var entity = this.get(ID);
            this._context.Mensajes.Remove(entity);
        }
    }
}
