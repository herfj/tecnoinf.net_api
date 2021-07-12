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
    public class ComentariosController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Comment(DTOComentarios dtocm)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                if(dtocm.Fecha == null || dtocm.Cuerpo == null || dtocm.Usuario == null || dtocm.Proyecto == null)
                {
                    return InternalServerError();
                }
                ControllerComentarios controller = new ControllerComentarios();
                controller.Comentar(dtocm);
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
        [HttpGet]
        public IHttpActionResult GetComentariosFromPJ([FromUri] string Titulo)
        {
            if(Titulo == null)
            {
                return InternalServerError();
            }
            ControllerComentarios controller = new ControllerComentarios();
            List<DTOComentarios> lstDTO = controller.GetComentariosFromProyecto(Titulo);

            return Ok(lstDTO);
        }
    }
    
}
