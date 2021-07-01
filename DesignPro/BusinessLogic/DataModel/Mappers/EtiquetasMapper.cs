using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resistencia.Database;
using Common.DataTransferObjects;

namespace BusinessLogic.DataModel.Mappers
{
    class EtiquetasMapper
    {
        public DTOEtiquetas MapToDTOEtiquetas(Etiquetas eti)
        {
            if(eti == null)
            {
                return null;
            }
            DTOEtiquetas DTOEti = new DTOEtiquetas()
            {
                Titulo_proyecto = eti.Titulo_proyecto,
                Etiquetas1 = eti.Etiquetas1,
                ID = eti.ID
            };
            return DTOEti;
        }

        public Etiquetas MapFromDTOEtiquetas(DTOEtiquetas DTOEti)
        {
            if(DTOEti == null)
            {
                return null;
            }
            Etiquetas eti = new Etiquetas()
            {
                Titulo_proyecto = DTOEti.Titulo_proyecto,
                Etiquetas1 = DTOEti.Etiquetas1,
                ID = DTOEti.ID
            };
            return eti;
        }
    }
}
