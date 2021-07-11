using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogic.Controllers;
using Common.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace InternalServices.Controllers
{
    public class ProyectoController : ApiController
    {
        [System.Web.Http.HttpPost]
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
        [System.Web.Http.HttpDelete]
        public IHttpActionResult BorrarPage([System.Web.Http.FromBody] JObject BorrarContent)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                if (BorrarContent["ID"] == null || BorrarContent["Titulo"] == null)
                {
                    return InternalServerError();
                }
                ControllerProyecto controller = new ControllerProyecto();
                controller.BorrarPagina(Int32.Parse(BorrarContent["ID"].ToString()));
                response.Success = true;
                return Ok(controller.GetProyect(BorrarContent["Titulo"].ToString()));
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Error = ex.ToString();
                return InternalServerError();
            }
        }
        [System.Web.Http.HttpPut]
        public IHttpActionResult EditarPage([System.Web.Http.FromBody]JObject EditarContent)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                if(EditarContent["ID"] == null || EditarContent["cadena"] == null || EditarContent["texto"] == null || EditarContent["Titulo"] == null)
                {
                    return InternalServerError();
                }
                ControllerProyecto controller = new ControllerProyecto();
                controller.EditarPagina(Int32.Parse(EditarContent["ID"].ToString()), EditarContent["cadena"].ToString(), Int32.Parse(EditarContent["texto"].ToString()));
                response.Success = true;
                return Ok(controller.GetProyect(EditarContent["Titulo"].ToString()));
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Error = ex.ToString();
                return InternalServerError();
            }
        }


        [System.Web.Http.HttpPost]
        public IHttpActionResult CrearPage(DTOProyecto DTOP)
        {
            DTOBaseResponse response = new DTOBaseResponse();
            try
            {
                if((DTOP.Texto == null && DTOP.Imagen == null) || DTOP.Titulo == null)
                {
                    return InternalServerError();
                }
                else
                {
                    ControllerProyecto controller = new ControllerProyecto();
                    controller.CrearPaginas(DTOP);
                    response.Success = true;
                    return Ok(controller.GetProyect(DTOP.Titulo));
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Error = ex.ToString();
                return InternalServerError();
            }
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteProyect([System.Web.Http.FromBody]JObject DeleteContent)
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
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetProyect([System.Web.Http.FromUri] string Titulo)
        {
            ControllerProyecto controller = new ControllerProyecto();
            try
            {
                if(string.IsNullOrEmpty(Titulo))
                {
                    return InternalServerError();
                }
                var Proyecto = controller.GetProyect(Titulo);

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

        [System.Web.Http.HttpPut]
        public IHttpActionResult SumarProyect([System.Web.Http.FromBody]JObject ShowContent)
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

        [System.Web.Http.HttpGet]
        public List<DTOProyecto> GetAllProyect()
        {
            ControllerProyecto controller = new ControllerProyecto();
            List<DTOProyecto> lstDTO = controller.GetAllProyects();

            return lstDTO;
        }
        [System.Web.Http.HttpGet]
        public IHttpActionResult FilterByCategory(DTOCategoria cat)
        {
            if(cat.Nombre==null)
            {
                return InternalServerError();
            }
            ControllerProyecto controller = new ControllerProyecto();
            List<DTOProyecto> lstDTO = controller.FilterByCat(cat.Nombre);

            return Ok(lstDTO);
        }
        [System.Web.Http.HttpGet]
        public IHttpActionResult FilterByLikes(DTOUsuarios user)
        {
            if(user.Email == null)
            {
                return InternalServerError();
            }
            ControllerProyecto controller = new ControllerProyecto();
            List<DTOProyecto> lstDTO = controller.FilterByLike(user.Email);

            return Ok(lstDTO);
        }
 

        [System.Web.Http.HttpGet]
        public IHttpActionResult FilterByMine([System.Web.Http.FromUri] string Email)
        {
            if(string.IsNullOrEmpty(Email))
            {
                return InternalServerError();
            }
            ControllerProyecto controller = new ControllerProyecto();
            List<DTOProyecto> lstDTO = controller.FilterByMio(Email);

            return Ok(lstDTO);
        }
        [System.Web.Http.HttpGet]
        public List<DTOCategoria> GetAllCats()
        {
            ControllerProyecto controller = new ControllerProyecto();
            List<DTOCategoria> lstDTO = controller.GetAllCategos();

            return lstDTO;
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult SearchBy(string busqueda)

        {   
            try{
                if(busqueda == null)
                {
                    return InternalServerError();
                }
                ControllerProyecto controller = new ControllerProyecto();
                List<DTOProyecto> lstDTO = controller.Search(busqueda);

                return Ok(lstDTO);

            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
