using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resistencia.Database;

namespace BusinessLogic.DataModel.Repositories
{
    class UsuariosRepository
    {
        private readonly design_proEntities _context;

        public UsuariosRepository(design_proEntities context)
        {
            this._context = context;
        }

        public Usuarios get(string Email)
        {
            var UsuariosEntity = this._context.Usuarios.Where(a => a.Email == Email).FirstOrDefault();
            return UsuariosEntity;
        }

        public List<Usuarios> GetAll()
        {
            var entityList = this._context.Usuarios.Select(s => s).ToList();
            return entityList;
        }

        public bool Any(string Email)
        {
            var exists = this._context.Usuarios.Any(s => s.Email == Email);
            return exists;
        }

        public void Create(Usuarios user)
        {
            this._context.Usuarios.Add(user);
        }

        public void Delete(string Email)
        {
            var entity = this.get(Email);
            this._context.Usuarios.Remove(entity);
        }
    }
}
