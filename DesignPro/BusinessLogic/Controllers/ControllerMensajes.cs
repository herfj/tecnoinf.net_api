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
    public class ControllerMensajes
    {
        private MensajesMapper _mapper;
        public ControllerMensajes()
        {
            _mapper = new MensajesMapper();
        }

        public void EnviarMensaje(DTOMensajes Mensaje)
        {
            try
            {
                using (design_proEntities context = new design_proEntities())
                {
                    MensajesRepository repositorio = new MensajesRepository(context); 
                    repositorio.Create(_mapper.MapFromDTOMensajes(Mensaje));

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

             
        public List<DTOMensajes> BandejaEntrada(string Email)
        {
            List<DTOMensajes> bandeja = new List<DTOMensajes>();

            using (design_proEntities context = new design_proEntities())
            {
                MensajesRepository repositorio = new MensajesRepository(context);
                var entityList = repositorio.GetAll();
                foreach (var entity in entityList)
                {
                    if(entity.Remitente == Email)
                    bandeja.Add(_mapper.MapToDTOMensajes(entity));
                }
            }
            return bandeja;
                
        }

        public List<DTOMensajes> BandejaSalida(string Email)
        {
            List<DTOMensajes> bandeja = new List<DTOMensajes>();

            using (design_proEntities context = new design_proEntities())
            {
                MensajesRepository repositorio = new MensajesRepository(context);
                var entityList = repositorio.GetAll();
                foreach (var entity in entityList)
                {
                    if(entity.Emisor == Email)
                    bandeja.Add(_mapper.MapToDTOMensajes(entity));
                }
            }
            return bandeja;
                
        }

        public DTOMensajes GetMensaje(int ID)
        {
            using (design_proEntities context = new design_proEntities())
            {
                MensajesRepository repositorio = new MensajesRepository(context);
                var entity = repositorio.get(ID);
                return _mapper.MapToDTOMensajes(entity);   
            }
        }

        public void Visto(int ID)
        {
            using (design_proEntities context = new design_proEntities())
            {
                MensajesRepository repositorio = new MensajesRepository(context);
                var entity = repositorio.get(ID);
                entity.Visto = 1;
                context.SaveChanges();
            }
        }
        

        //No visto = 0
        //Visto = 1
        

    }
}