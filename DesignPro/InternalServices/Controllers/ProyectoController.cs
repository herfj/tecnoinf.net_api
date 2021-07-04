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
    public class ProyectoController : ApiController
    {
        [HttpPost]
        public IHttpActionResult CreateProyect(DTOProyecto DTOP)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                if(DTOP.Titulo == null || DTOP.Autor == null || DTOP.Vistas == null || DTOP.Fecha_publicada == null || DTOP.Portada == null)
                {
                    return InternalServerError();
                }
                ControllerProyecto controller = new ControllerProyecto();
                controller.CrearProyecto(DTOP);
                response.Success = true;
                return Ok(controller.GetProyect(DTOP.Titulo));
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.ToString();
                return InternalServerError();
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteProyect([FromBody]JObject DeleteContent)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                if(DeleteContent["Titulo"].ToString() == null)
                {
                    return InternalServerError();
                }
                ControllerProyecto controller = new ControllerProyecto();
                controller.BorrarProyecto(DeleteContent["Titulo"].ToString());
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

        public IHttpActionResult GetProyect([FromBody] JObject GetContent)
        {
            ControllerProyecto controller = new ControllerProyecto();
            try
            {
                if(GetContent["Titulo"].ToString()==null)
                {
                    return InternalServerError();
                }
                var Proyecto = controller.GetProyect(GetContent["Titulo"].ToString());

                if (Proyecto == null)
                {
                    return NotFound();
                }
                return Ok(Proyecto);
            }
            catch (Exception ex){
                return InternalServerError();
            }
            
        }

        [HttpPut]
        public IHttpActionResult SumarProyect([FromBody] JObject ShowContent)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                if(ShowContent["Titulo"].ToString() == null)
                {
                    return InternalServerError();
                }
                ControllerProyecto controller = new ControllerProyecto();
                controller.SumarVistas(ShowContent["Titulo"].ToString());
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


        public List<DTOProyecto> GetAllProyect()
        {
            ControllerProyecto controller = new ControllerProyecto();
            List<DTOProyecto> lstDTO = controller.GetAllProyects();

            return lstDTO;
        }

        public List<DTOProyecto> FilterByCategory(DTOCategoria cat)
        {
            if(cat.Nombre==null)
            {
                return InternalServerError();
            }
            ControllerProyecto controller = new ControllerProyecto();
            List<DTOProyecto> lstDTO = controller.FilterByCat(cat.Nombre);

            return lstDTO;
        }

        public List<DTOProyecto> FilterByLikes(DTOUsuarios user)
        {
            if(user.Email == null)
            {
                return InternalServerError();
            }
            ControllerProyecto controller = new ControllerProyecto();
            List<DTOProyecto> lstDTO = controller.FilterByLike(user.Email);

            return lstDTO;
        }

        
        public List<DTOProyecto> FilterByMine(DTOUsuarios user)
        {
            if(user.Email == null)
            {
                return InternalServerError();
            }
            ControllerProyecto controller = new ControllerProyecto();
            List<DTOProyecto> lstDTO = controller.FilterByMio(user.Email);

            return lstDTO;
        }

        public List<DTOCategoria> GetAllCats()
        {
            ControllerProyecto controller = new ControllerProyecto();
            List<DTOCategoria> lstDTO = controller.GetAllCategos();

            return lstDTO;
        }

        public List<DTOProyecto> SearchBy(string busqueda)
        {   
            try{
                if(busqueda == null)
                {
                    return InternalServerError();
                }
                ControllerProyecto controller = new ControllerProyecto();
                List<DTOProyecto> lstDTO = controller.Search(busqueda);
                return lsDTO;
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
