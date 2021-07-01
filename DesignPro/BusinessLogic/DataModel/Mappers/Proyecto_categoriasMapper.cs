using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resistencia.Database;
using Common.DataTransferObjects;

namespace BusinessLogic.DataModel.Mappers
{
    class Proyecto_categoriasMapper
    {
        public DTOProyecto_categorias MapToDTOProyecto_categorias(Proyecto_categorias pc)
        {
            if(pc == null)
            {
                return null;
            }
            DTOProyecto_categorias DTOPc = new DTOProyecto_categorias()
            {
                Categoria = pc.Categoria,
                Titulo_proyecto = pc.Titulo_proyecto,
                ID = pc.ID
            };
            return DTOPc;
        }

        public Proyecto_categorias MapFromDTOProyecto_categoias(DTOProyecto_categorias DTOPc)
        {
            if(DTOPc == null)
            {
                return null;
            }
            Proyecto_categorias pc = new Proyecto_categorias()
            {
                Categoria = DTOPc.Categoria,
                Titulo_proyecto = DTOPc.Titulo_proyecto,
                ID = DTOPc.ID
            };
            return pc;
        }
    }
}
