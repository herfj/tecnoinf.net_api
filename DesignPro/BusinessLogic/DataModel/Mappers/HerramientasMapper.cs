using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resistencia.Database;
using Common.DataTransferObjects;

namespace BusinessLogic.DataModel.Mappers
{
    class HerramientasMapper
    {
        public DTOHerramientas MapToDTOHerramientas(Herramientas her)
        {
            if(her == null)
            {
                return null;
            }
            DTOHerramientas DTOHer = new DTOHerramientas()
            {
                Titulo_proyecto = her.Titulo_proyecto,
                Herramienta = her.Herramienta,
                ID = her.ID
            };
            return DTOHer;
        }

        public Herramientas MapFromDTOHerramientas(DTOHerramientas DTOHer)
        {
            if (DTOHer == null)
            {
                return null;
            }
            Herramientas her = new Herramientas()
            {
                Titulo_proyecto = DTOHer.Titulo_proyecto,
                Herramienta = DTOHer.Herramienta,
                ID = DTOHer.ID
            };
            return her;
        }
    }
}
