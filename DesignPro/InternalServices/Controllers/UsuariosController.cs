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
        [HttpGet]
        public List<DTOUsuarios> GetAllUsuarios()
        {
            ControllerUsuario controller = new ControllerUsuario();
            List<DTOUsuarios> lstDTO = controller.GetAllUsers();

            return lstDTO;
        }
        [HttpGet]
        public IHttpActionResult GetUsuario([FromUri] string Email)
        {
            ControllerUsuario controller = new ControllerUsuario();
            if (string.IsNullOrEmpty(Email))
            {
                return NotFound();
            }
            else
            {

                var Usuario = controller.GetUser(Email);
                if (Usuario == null)
                {
                    return NotFound();     
                }
                return Ok(Usuario);
            }
            
        }

        [HttpPost]
        public IHttpActionResult CreateUsuario(DTOUsuarios user)
        {
            
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                ControllerUsuario controller = new ControllerUsuario();
                if(user.Email == null || user.Nombre == null || user.Apellido == null || user.Password == null || user.Fecha_nac == null || user.Pais == null)
                {
                    return InternalServerError();
                }
                controller.CrearUsuario(user);
                response.Success = true;
                return Ok(controller.GetUser(user.Email));
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.ToString();
                return InternalServerError();
            }
           
        }

        [HttpPut]
        public IHttpActionResult UpdateUsuario(DTOUsuarios Usuario)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                if(Usuario.Email == null)
                {
                    return InternalServerError();  
                }
                ControllerUsuario controller = new ControllerUsuario();
                controller.ModificarUsuario(Usuario);
                response.Success = true;
                return Ok(controller.GetUser(Usuario.Email));
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.ToString();
                return InternalServerError();    
            }
            
        }

        [HttpDelete]
        public IHttpActionResult DeleteUsuario(DTOUsuarios user)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                if(user.Email == null)
                {
                    return InternalServerError();
                }
                ControllerUsuario controller = new ControllerUsuario();
                controller.BorrarUsuario(user.Email);
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

        [HttpPost]
        public IHttpActionResult Log([FromBody] JObject LogContent)
        {
            DTOBaseResponse response = new DTOBaseResponse();

            ControllerUsuario controller = new ControllerUsuario();
            if(LogContent["Email"].ToString() == null || LogContent["Password"].ToString() == null)
            {
                return Unauthorized();
            }
            else{

                var Usuario = controller.Loguear(LogContent["Email"].ToString(), LogContent["Password"].ToString());
                if (Usuario == null)
                {
                    return Unauthorized();
                }
                return Ok(Usuario);

            }
                
        }

        [HttpPut]
        public IHttpActionResult Seguir([FromBody]JObject SeguirContent)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                if(SeguirContent["seguidor"].ToString() == null || SeguirContent["seguido"].ToString() == null)
                {
                    return InternalServerError();
                }
                ControllerUsuario controller = new ControllerUsuario();
                controller.SeguirUsuario(SeguirContent["seguidor"].ToString(), SeguirContent["seguido"].ToString());
                response.Success = true;

                return Ok(controller.GetUser(SeguirContent["seguido"].ToString()));
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.ToString();
                return InternalServerError();
            }
    
        }

        [HttpPut]
        public IHttpActionResult LikearProyecto([FromBody]JObject LikearProyectoContent)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                if(LikearProyectoContent["Email"].ToString() == null || LikearProyectoContent["Titulo"].ToString() == null)
                {
                    return InternalServerError();
                }
                ControllerUsuario controller = new ControllerUsuario();
                controller.LikeProyecto(LikearProyectoContent["Email"].ToString(), LikearProyectoContent["Titulo"].ToString());
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

        [HttpPut]
        public IHttpActionResult DejarDeSeguir([FromBody]JObject DejarDeSeguirContent)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                if(DejarDeSeguirContent["seguidor"].ToString() == null || DejarDeSeguirContent["seguido"].ToString() == null)
                {
                    return InternalServerError();
                }
                ControllerUsuario controller = new ControllerUsuario();
                controller.DejarDeSeguirUsuario(DejarDeSeguirContent["seguidor"].ToString(), DejarDeSeguirContent["seguido"].ToString());
                response.Success = true;
                return Ok(controller.GetUser(DejarDeSeguirContent["seguido"].ToString()));
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.ToString();
                return InternalServerError();
            }
            
        }

        [HttpPut]
        public IHttpActionResult DislikeProyecto([FromBody] JObject DislikeProyectoContent)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                if(DislikeProyectoContent["Email"].ToString() == null || DislikeProyectoContent["Titulo"].ToString() == null)
                {
                    return InternalServerError();
                }
                ControllerUsuario controller = new ControllerUsuario();
                controller.DislikeProyecto(DislikeProyectoContent["Email"].ToString(), DislikeProyectoContent["Titulo"].ToString());
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
        public IHttpActionResult SigueONoSigue([FromBody]JObject SigueONoSigueContent)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                if(SigueONoSigueContent["seguidor"].ToString() == null || SigueONoSigueContent["seguido"].ToString() == null)
                {
                    return InternalServerError();
                }
                ControllerUsuario controller = new ControllerUsuario();
                response.Success = controller.EsteLoSigueONo(SigueONoSigueContent["seguidor"].ToString(), SigueONoSigueContent["seguido"].ToString());
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
        public IHttpActionResult EsteLeDioLikeONo([FromUri]string Email, [FromUri] string Titulo)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                if(Email == null || Titulo == null)
                {
                    return InternalServerError();
                }
                ControllerUsuario controller = new ControllerUsuario();
                response.Success = controller.EsteDioLikeONo(Email, Titulo);
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
