using BusinessLogic.DataModel.Mappers;
using BusinessLogic.DataModel.Repositories;
using Common.DataTransferObjects;
using Resistencia.Database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace BusinessLogic.Controllers
{
    public class ControllerUsuario
    {
        private UsuarioMapper _mapper;
        public ControllerUsuario()
        {
            _mapper = new UsuarioMapper();
        }

        public void CrearUsuario(DTOUsuarios DTOUser)
        {
            try
            {
                using (design_proEntities context = new design_proEntities())
                {
                    UsuariosRepository repositorio = new UsuariosRepository(context);
                    if(repositorio.Any(DTOUser.Email))
                    {
                        throw new Exception("El usuario ya existe.");
                    }
                    repositorio.Create(_mapper.MapFromDTOUsuarios(DTOUser));

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarUsuario(DTOUsuarios DTOUser)
        {
            try
            {
                using (design_proEntities context = new design_proEntities())
                {
                    UsuariosRepository repositorio = new UsuariosRepository(context);
                    Usuarios entity = repositorio.get(DTOUser.Email);
                    int ID = CrearVisual(DTOUser.imagen);

                    entity.Nombre = DTOUser.Nombre;
                    entity.Apellido = DTOUser.Apellido;
                    entity.Profesion = DTOUser.Profesion;
                    entity.Empresa = DTOUser.Empresa;
                    entity.Pais = DTOUser.Pais;
                    entity.Ciudad = DTOUser.Ciudad;
                    entity.ID_Visual = ID;
                    entity.URL = DTOUser.URL;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int CrearVisual(string base64)
        {
            using (design_proEntities context = new design_proEntities())
            {
                Visual v = new Visual();
                VisualRepository visualRepository = new VisualRepository(context);
                v.Path = base64;
                v.Tipo = 0;
                visualRepository.Create(v);
                context.SaveChanges();
                return v.ID;
            }
        }

        public void BorrarUsuario(string Email)
        {
            try
            {
                using (design_proEntities context = new design_proEntities())
                {
                    UsuariosRepository repositorio = new UsuariosRepository(context);
                    repositorio.Delete(Email);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DTOUsuarios Loguear(string Email, string Password)
        {
            try
            {
                using (design_proEntities context = new design_proEntities())
                {
                    UsuariosRepository repositorio = new UsuariosRepository(context);
                    var entity = repositorio.get(Email);
                    if (entity==null)
                    {
                        return _mapper.MapToDTOUsuarios(entity);
                    }
                    Usuarios user = repositorio.get(Email);
                    if(user.Password != Password)
                    {
                        entity = null;
                        return _mapper.MapToDTOUsuarios(entity);
                    }
                    return _mapper.MapToDTOUsuarios(entity);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DTOUsuarios GetUser(string Email)
        {
            using (design_proEntities context = new design_proEntities())
            {
                UsuariosRepository repositorio = new UsuariosRepository(context);
                VisualRepository visual = new VisualRepository(context);
                var entity = repositorio.get(Email);
                var DTOentity = _mapper.MapToDTOUsuarios(entity);
                int dou = DTOentity.ID_Visual ?? default(int);
                var v = visual.get(dou);
                DTOentity.imagen = v.Path;
                
                return DTOentity;   
            }
        }
        
        public List<DTOUsuarios> GetAllUsers()
        {
            List<DTOUsuarios> usuarios = new List<DTOUsuarios>();

            using (design_proEntities context = new design_proEntities())
            {
                UsuariosRepository repositorio = new UsuariosRepository(context);
                var entityList = repositorio.GetAll();
                foreach (var entity in entityList)
                {
                    usuarios.Add(_mapper.MapToDTOUsuarios(entity));
                }
            }
            return usuarios;
                
        }

        public void SeguirUsuario(string Seguidor, string Seguido)
        {
            try
            {
                using (design_proEntities context = new design_proEntities())
                {
                    UsuariosRepository repositorio = new UsuariosRepository(context);
                    Usuarios UsuarioSeguidor = repositorio.get(Seguidor);
                    Usuarios UsuarioSeguido = repositorio.get(Seguido);
                    if ((!UsuarioSeguidor.Usuarios2.Contains(UsuarioSeguido)) && (!UsuarioSeguido.Usuarios1.Contains(UsuarioSeguidor)))
                    {
                        UsuarioSeguidor.Usuarios2.Add(UsuarioSeguido);
                        UsuarioSeguido.Usuarios1.Add(UsuarioSeguidor);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Ya se siguen");
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void DejarDeSeguirUsuario(string Seguidor, string Seguido)
        {
            try
            {
                using (design_proEntities context = new design_proEntities())
                {
                    UsuariosRepository repositorio = new UsuariosRepository(context);
                    Usuarios UsuarioSeguidor = repositorio.get(Seguidor);
                    Usuarios UsuarioSeguido = repositorio.get(Seguido);
                    if ((UsuarioSeguidor.Usuarios2.Contains(UsuarioSeguido)) && (UsuarioSeguido.Usuarios1.Contains(UsuarioSeguidor)))
                    {
                        UsuarioSeguidor.Usuarios2.Remove(UsuarioSeguido);
                        UsuarioSeguido.Usuarios1.Remove(UsuarioSeguidor);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("No se siguen");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EsteLoSigueONo(string Seguidor, string Seguido)
        {
            using (design_proEntities context = new design_proEntities())
            {
                UsuariosRepository repositorio = new UsuariosRepository(context);
                Usuarios UsuarioSeguidor = repositorio.get(Seguidor);
                Usuarios UsuarioSeguido = repositorio.get(Seguido);
                if ((UsuarioSeguidor.Usuarios2.Contains(UsuarioSeguido)) && (UsuarioSeguido.Usuarios1.Contains(UsuarioSeguidor)))
                {
                    return true;
                }
                else{
                    return false;
                }
            }
        }

        public void LikeProyecto(string Email, string Titulo_proyecto)
        {
            try
            {
                using (design_proEntities context = new design_proEntities())
                {
                    UsuariosRepository repositorio = new UsuariosRepository(context);
                    ProyectoRepository p_repositorio = new ProyectoRepository(context);
                    Usuarios valorador = repositorio.get(Email);
                    Proyecto p_valorado = p_repositorio.get(Titulo_proyecto);
                    if(!valorador.Proyecto1.Contains(p_valorado))
                    {
                        valorador.Proyecto1.Add(p_valorado);
                        p_valorado.Usuarios1.Add(valorador);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("No dio like");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void DislikeProyecto(string Email, string Titulo_proyecto)
        {
            try
            {
                using (design_proEntities context = new design_proEntities())
                {
                    UsuariosRepository repositorio = new UsuariosRepository(context);
                    ProyectoRepository p_repositorio = new ProyectoRepository(context);
                    Usuarios valorador = repositorio.get(Email);
                    Proyecto p_valorado = p_repositorio.get(Titulo_proyecto);
                    if(valorador.Proyecto1.Contains(p_valorado))
                    {
                        valorador.Proyecto1.Remove(p_valorado);
                        p_valorado.Usuarios1.Remove(valorador);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Ya dio like");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool EsteDioLikeONo(string Email, string Titulo_proyecto)
        {
            using (design_proEntities context = new design_proEntities())
            {
                UsuariosRepository repositorio = new UsuariosRepository(context);
                ProyectoRepository p_repositorio = new ProyectoRepository(context);
                Usuarios valorador = repositorio.get(Email);
                Proyecto p_valorado = p_repositorio.get(Titulo_proyecto);
                if(valorador.Proyecto1.Contains(p_valorado))
                {
                    return true;
                }
                else{
                    return false;
                }
            }
        }

        //usuarios.proyecto = los proyectos del usuario
        //proyecto.usuarios = el autor
        //proyecto.usuarios1 = likes del proyecto
        //usuarios.proyecto1 = proyectos que ha dado like
        //usuarios.usuarios1 = seguidores
        //usuarios.usuarios2 = seguidos

    }
}
