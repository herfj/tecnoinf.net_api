using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resistencia.Database;
using Common.DataTransferObjects;

namespace BusinessLogic.DataModel.Mappers
{
    class PagesMapper
    {
        public DTOPages MapToDTOPages(Pages p)
        {
            if(p == null)
            {
                return null;
            }
            DTOPages DTOP = new DTOPages()
            {
               ID_Visual = p.ID_Visual,
               ID_Portfolio = p.ID_Portfolio,
               Contenido = p.Contenido,
               ID = p.ID
            };
            return DTOP;
        }

        public Pages MapFromDTOPages(DTOPages DTOP)
        {
            if(DTOP == null)
            {
                return null;
            }
            Pages p = new Pages()
            {
                ID_Visual = DTOP.ID_Visual,
                ID_Portfolio = DTOP.ID_Portfolio,
                Contenido = DTOP.Contenido,
                ID = DTOP.ID
            };
            return p;
        }
    }
}
