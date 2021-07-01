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
                ControllerComentarios controller = new ControllerComentarios();
                controller.Comentar(dtocm);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.ToString();
            }
            return Ok(response);
        }
    
        public List<DTOComentarios> GetComentariosFromPJ(DTOProyecto pj)
        {
            ControllerComentarios controller = new ControllerComentarios();
            List<DTOComentarios> lstDTO = controller.GetComentariosFromProyecto(pj.Titulo);

            return lstDTO;
        }
    }
    
}
