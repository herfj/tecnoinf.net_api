using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DataModel.Mappers;
using BusinessLogic.DataModel.Repositories;
using Common.DataTransferObjects;
using Resistencia.Database;

namespace BusinessLogic.Controllers
{
    public class ControllerComentarios
    {
        private ComentariosMapper _mapper;
        public ControllerComentarios()
        {
            _mapper = new ComentariosMapper();
        }

        public void Comentar(DTOComentarios cmt)
        {
            try
            {
                using (design_proEntities context = new design_proEntities())
                {
                    ComentariosRepository repositorio = new ComentariosRepository(context); 
                    repositorio.Create(_mapper.MapFromDTOComentarios(cmt));

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

              
        public List<DTOComentarios> GetComentariosFromProyecto(string Titulo)
        {
            List<DTOComentarios> cmts = new List<DTOComentarios>();

            using (design_proEntities context = new design_proEntities())
            {
                ComentariosRepository repositorio = new ComentariosRepository(context);
                var entityList = repositorio.GetAll();
                foreach (var entity in entityList)
                {
                    if(entity.Proyecto == Titulo)
                    cmts.Add(_mapper.MapToDTOComentarios(entity));
                }
            }
            return cmts;
                
        }
    }
}
