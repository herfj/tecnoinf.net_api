using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resistencia.Database;
using Common.DataTransferObjects;

namespace BusinessLogic.DataModel.Mappers
{
    class PortfolioMapper
    {
        public DTOPortfolio MapToDTOPortfolio(Portfolio p)
        {
            if(p == null)
            {
                return null;
            }
            DTOPortfolio DTOP = new DTOPortfolio()
            {
                ID = p.ID,
                Titulo_Proyecto = p.Titulo_Proyecto
            };
            return DTOP;
        }

        public Portfolio MapFromDTOPortfolio(DTOPortfolio DTOP)
        {
            if(DTOP == null)
            {
                return null;
            }
            Portfolio p = new Portfolio()
            {
                ID = DTOP.ID,
                Titulo_Proyecto = DTOP.Titulo_Proyecto
            };
            return p;
        }
    }
}
