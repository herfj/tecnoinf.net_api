using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resistencia.Database;
using Common.DataTransferObjects;

namespace BusinessLogic.DataModel.Mappers
{
    class ComentariosMapper
    {
        public DTOComentarios MapToDTOComentarios(Comentarios com)
        {
            if(com == null)
            {
                return null;
            }
            DTOComentarios DTOCom = new DTOComentarios
            {
                ID = com.ID,
                Fecha = com.Fecha,
                Cuerpo = com.Cuerpo,
                Usuario = com.Usuario,
                Proyecto = com.Proyecto
            };
            return DTOCom;
        }

        public Comentarios MapFromDTOComentarios(DTOComentarios DTOCom)
        {
            if(DTOCom == null)
            {
                return null;
            }
            Comentarios com = new Comentarios()
            {
                ID = DTOCom.ID,
                Fecha = DTOCom.Fecha,
                Cuerpo = DTOCom.Cuerpo,
                Usuario = DTOCom.Usuario,
                Proyecto = DTOCom.Proyecto
            };
            return com;
        }
    }
}
