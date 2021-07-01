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
    public class UsuariosController : ApiController
    {
        public List<DTOUsuarios> GetAllUsuarios()
        {
            ControllerUsuario controller = new ControllerUsuario();
            List<DTOUsuarios> lstDTO = controller.GetAllUsers();

            return lstDTO;
        }

        public IHttpActionResult GetUsuario(DTOUsuarios user)
        {
            ControllerUsuario controller = new ControllerUsuario();
            var Usuario = controller.GetUser(user.Email);

            if (Usuario == null)
            {
                return NotFound();
            }
            return Ok(Usuario);
        }

        [HttpPost]
        public IHttpActionResult CreateUsuario(DTOUsuarios user)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                ControllerUsuario controller = new ControllerUsuario();
                controller.CrearUsuario(user);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.ToString();
            }
            return Ok(response);
        }

        [HttpPost]
        public IHttpActionResult UpdateUsuario(DTOUsuarios Usuario)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                ControllerUsuario controller = new ControllerUsuario();
                controller.ModificarUsuario(Usuario);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.ToString();
            }
            return Ok(response);
        }

        [HttpDelete]
        public IHttpActionResult DeleteUsuario(DTOUsuarios user)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                ControllerUsuario controller = new ControllerUsuario();
                controller.BorrarUsuario(user.Email);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.ToString();
            }
            return Ok(response);
        }

        public IHttpActionResult Log([FromBody] JObject LogContent)
        {
            DTOBaseResponse response = new DTOBaseResponse();

                ControllerUsuario controller = new ControllerUsuario();
                var Usuario = controller.Loguear(LogContent["Email"].ToString(), LogContent["Password"].ToString());
                if (Usuario == null)
                {
                    return NotFound();
                }
                return Ok(Usuario);
        }

        [HttpPut]
        public IHttpActionResult Seguir([FromBody]JObject SeguirContent)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                ControllerUsuario controller = new ControllerUsuario();
                controller.SeguirUsuario(SeguirContent["seguidor"].ToString(), SeguirContent["seguido"].ToString());
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.ToString();
            }
            return Ok(response);
        }

        [HttpPut]
        public IHttpActionResult LikearProyecto([FromBody]JObject LikearProyectoContent)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                ControllerUsuario controller = new ControllerUsuario();
                controller.LikeProyecto(LikearProyectoContent["Email"].ToString(), LikearProyectoContent["Titulo"].ToString());
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.ToString();
            }
            return Ok(response);
        }

        [HttpPut]
        public IHttpActionResult DejarDeSeguir([FromBody]JObject DejarDeSeguirContent)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                ControllerUsuario controller = new ControllerUsuario();
                controller.DejarDeSeguirUsuario(DejarDeSeguirContent["seguidor"].ToString(), DejarDeSeguirContent["seguido"].ToString());
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.ToString();
            }
            return Ok(response);
        }

        [HttpPut]
        public IHttpActionResult DislikeProyecto([FromBody] JObject DislikeProyectoContent)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                ControllerUsuario controller = new ControllerUsuario();
                controller.DislikeProyecto(DislikeProyectoContent["Email"].ToString(), DislikeProyectoContent["Titulo"].ToString());
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.ToString();
            }
            return Ok(response);
        }

        public IHttpActionResult SigueONoSigue([FromBody]JObject SigueONoSigueContent)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                ControllerUsuario controller = new ControllerUsuario();
                response.Success = controller.EsteLoSigueONo(SigueONoSigueContent["seguidor"].ToString(), SigueONoSigueContent["seguido"].ToString());
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.ToString();
            }
            return Ok(response);
        }

        public IHttpActionResult EsteLeDioLikeONo([FromBody]JObject EsteLeDioLikeONoContent)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                ControllerUsuario controller = new ControllerUsuario();
                response.Success = controller.EsteDioLikeONo(EsteLeDioLikeONoContent["Email"].ToString(), EsteLeDioLikeONoContent["Titulo"].ToString());
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.ToString();
            }
            return Ok(response);
        }
    }
}
