using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogic.Controllers;
using Common.DataTransferObjects;
using Newtonsoft.Json.Linq;



namespace InternalServices.Controllers
{
    public class MensajesController : ApiController
    {
        [HttpPost]
        public IHttpActionResult SendMSG(DTOMensajes dtomsg)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                if(dtomsg.ID == null || dtomsg.Fecha == null || dtomsg.Cuerpo == null || dtomsg.Visto == null || dtomsg.Emisor == null || dtomsg.Remitente == null){
                    return InternalServerError();
                }
                ControllerMensajes controller = new ControllerMensajes();
                controller.EnviarMensaje(dtomsg);
                response.Success = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.ToString();
                return InternalServerError();
            }
            
        }

        public List<DTOMensajes> BandejadeEntrada(DTOUsuarios user)
        {
            if(user.Email == null)
            {
                return InternalServerError();
            }
            ControllerMensajes controller = new ControllerMensajes();
            List<DTOMensajes> lstDTO = controller.BandejaEntrada(user.Email);

            return lstDTO;
        }

        public List<DTOMensajes> BandejadeSalida(DTOUsuarios user)
        {
            if(user.Email == null)
            {
                return InternalServerError();
            }
            ControllerMensajes controller = new ControllerMensajes();
            List<DTOMensajes> lstDTO = controller.BandejaSalida(user.Email);

            return lstDTO;
        }

        public IHttpActionResult GetMSG([FromBody] JObject GetContent)
        {
            if(GetContent["ID"].ToString() == null)
            {
                return InternalServerError();
            }
            ControllerMensajes controller = new ControllerMensajes();
            int num_var = Int32.Parse(GetContent["ID"].ToString());
            var Mensaje = controller.GetMensaje(num_var);

            if (Mensaje == null)
            {
                return NotFound();
            }
            return Ok(Mensaje);
        }

        [HttpPut]
        public IHttpActionResult PonerVisto([FromBody] JObject VistoContent)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                if(VistoContent["ID"].ToString() == null)
                {
                    return InternalServerError();
                }
                ControllerMensajes controller = new ControllerMensajes();
                int num_var = Int32.Parse(VistoContent["ID"].ToString());
                controller.Visto(num_var);
                response.Success = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.ToString();
                return InternalServerError();
            }
        }
    }
}