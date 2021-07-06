﻿using System;
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

        public IHttpActionResult GetProyect([System.Web.Http.FromBody] JObject GetContent)
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


        public List<DTOProyecto> GetAllProyect()
        {
            ControllerProyecto controller = new ControllerProyecto();
            List<DTOProyecto> lstDTO = controller.GetAllProyects();

            return lstDTO;
        }

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

        
        public IHttpActionResult FilterByMine(DTOUsuarios user)
        {
            if(user.Email == null)
            {
                return InternalServerError();
            }
            ControllerProyecto controller = new ControllerProyecto();
            List<DTOProyecto> lstDTO = controller.FilterByMio(user.Email);

            return Ok(lstDTO);
        }

        public List<DTOCategoria> GetAllCats()
        {
            ControllerProyecto controller = new ControllerProyecto();
            List<DTOCategoria> lstDTO = controller.GetAllCategos();

            return lstDTO;
        }

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
