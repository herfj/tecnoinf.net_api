using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resistencia.Database;
using Common.DataTransferObjects;

namespace BusinessLogic.DataModel.Mappers
{
    class UsuarioMapper
    {
        public DTOUsuarios MapToDTOUsuarios(Usuarios User)
        {
            if (User == null)
                return null;
            DTOUsuarios DTUser = new DTOUsuarios()
            {
                Nombre = User.Nombre,
                Apellido = User.Apellido,
                Descripcion = User.Descripcion,
                Email = User.Email,
                Password = User.Password,
                Ciudad = User.Ciudad,
                Pais = User.Pais,
                Profesion = User.Profesion,
                Fecha_nac = User.Fecha_nac,
                Empresa = User.Empresa,
                URL = User.URL,
                ID_Visual = User.ID_Visual,
                Seguidores = DTOSeguidores(User.Usuarios1),
                Seguidos = DTOSeguidores(User.Usuarios2)
            };
            return DTUser;
        }
        public Usuarios MapFromDTOUsuarios(DTOUsuarios DTOUser)
        {
            if (DTOUser == null)
                return null;
            Usuarios Usuario = new Usuarios()
            {
                Nombre = DTOUser.Nombre,
                Apellido = DTOUser.Apellido,
                Descripcion = DTOUser.Descripcion,
                Email = DTOUser.Email,
                Password = DTOUser.Password,
                Ciudad = DTOUser.Ciudad,
                Pais = DTOUser.Pais,
                Profesion = DTOUser.Profesion,
                Fecha_nac = DTOUser.Fecha_nac,
                Empresa = DTOUser.Empresa,
                URL = DTOUser.URL,
                ID_Visual = DTOUser.ID_Visual,
                Usuarios1 = Seguidores(DTOUser.Seguidores),
                Usuarios2 = Seguidores(DTOUser.Seguidos)
            };
            return Usuario;
        }

        public ICollection<DTOUsuarios> DTOSeguidores(ICollection<Usuarios> users)
        {
            ICollection<DTOUsuarios> DTOusers;
            DTOusers = new HashSet<DTOUsuarios>();
            foreach (Usuarios user in users)
            {
                DTOUsuarios DTOu = new DTOUsuarios();
                DTOu.Nombre = user.Nombre;
                DTOu.Apellido = user.Apellido;
                DTOu.Descripcion = user.Descripcion;
                DTOu.Email = user.Email;
                DTOu.Password = user.Password;
                DTOu.Ciudad = user.Ciudad;
                DTOu.Pais = user.Pais;
                DTOu.Profesion = user.Profesion;
                DTOu.Fecha_nac = user.Fecha_nac;
                DTOu.Empresa = user.Empresa;
                DTOu.URL = user.URL;
                DTOu.ID_Visual = user.ID_Visual;
                DTOusers.Add(DTOu);
            }
            return DTOusers;
        }

        public ICollection<Usuarios> Seguidores(ICollection<DTOUsuarios> DTOusers)
        {
            ICollection<Usuarios> users;
            users = new HashSet<Usuarios>();
            foreach (DTOUsuarios DTOuser in DTOusers)
            {
                Usuarios user = new Usuarios();
                user.Nombre = DTOuser.Nombre;
                user.Apellido = DTOuser.Apellido;
                user.Descripcion = DTOuser.Descripcion;
                user.Email = DTOuser.Email;
                user.Password = DTOuser.Password;
                user.Ciudad = DTOuser.Ciudad;
                user.Pais = DTOuser.Pais;
                user.Profesion = DTOuser.Profesion;
                user.Fecha_nac = DTOuser.Fecha_nac;
                user.Empresa = DTOuser.Empresa;
                user.URL = DTOuser.URL;
                user.ID_Visual = DTOuser.ID_Visual;
                users.Add(user);
            }
            return users;
        }
    }
}
