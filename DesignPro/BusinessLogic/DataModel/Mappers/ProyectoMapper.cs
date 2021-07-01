using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resistencia.Database;
using Common.DataTransferObjects;


namespace BusinessLogic.DataModel.Mappers
{
    class ProyectoMapper
    {
        public DTOProyecto MapToDTOProyecto(Proyecto proyecto)
        {
            if(proyecto == null)
            {
                return null;
            }
            DTOProyecto DTOproyecto = new DTOProyecto()
            {
                Titulo = proyecto.Titulo,
                Vistas = proyecto.Vistas,
                Fecha_publicada = proyecto.Fecha_publicada,
                Autor = proyecto.Autor,
                ID_Portfolio = proyecto.ID_Portfolio,
                Portada = proyecto.Portada
            };
            return DTOproyecto;
        }

        public Proyecto MapFromDTOProyecto(DTOProyecto DTOproyecto)
        {
            if(DTOproyecto == null)
            {
                return null;
            }
            Proyecto proyecto = new Proyecto()
            { 
                Titulo = DTOproyecto.Titulo,
                Vistas = DTOproyecto.Vistas,
                Fecha_publicada = DTOproyecto.Fecha_publicada,
                Autor = DTOproyecto.Autor,
                ID_Portfolio = DTOproyecto.ID_Portfolio,
                Portada = DTOproyecto.Portada
            };
            return proyecto;
        }
    }
}
