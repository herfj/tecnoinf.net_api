using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resistencia.Database;
using Common.DataTransferObjects;

namespace BusinessLogic.DataModel.Mappers
{
    class VisualMapper
    {
        public DTOVisual MapToDTOVisual(Visual v)
        {
            if(v == null)
            {
                return null;
            }
            DTOVisual DTOV = new DTOVisual()
            {
                ID = v.ID,
                Path = v.Path,
                Tipo = v.Tipo
            };
            return DTOV;
        }

        public Visual MapFromDTOVisual(DTOVisual DTOV)
        {
            if(DTOV == null)
            {
                return null;
            }
            Visual v = new Visual()
            {
                ID = DTOV.ID,
                Path = DTOV.Path,
                Tipo = DTOV.Tipo
            };
            return v;
        }
    }
}
