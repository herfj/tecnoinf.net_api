using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resistencia.Database;
using Common.DataTransferObjects;

namespace BusinessLogic.DataModel.Mappers
{
    class MensajesMapper
    {
        public DTOMensajes MapToDTOMensajes(Mensajes men)
        {
            if(men == null)
            {
                return null;
            }
            DTOMensajes DTOMen = new DTOMensajes
            {
                ID = men.ID,
                Fecha = men.Fecha,
                Cuerpo = men.Cuerpo,
                Visto = men.Visto,
                Emisor = men.Emisor,
                Remitente = men.Remitente
            };
            return DTOMen;
        }

        public Mensajes MapFromDTOMensajes(DTOMensajes DTOMen)
        {
            if(DTOMen == null)
            {
                return null;
            }
            Mensajes men = new Mensajes()
            {
                ID = DTOMen.ID,
                Fecha = DTOMen.Fecha,
                Cuerpo = DTOMen.Cuerpo,
                Visto = DTOMen.Visto,
                Emisor = DTOMen.Emisor,
                Remitente = DTOMen.Remitente
            };
            return men;
        }
    }
}
