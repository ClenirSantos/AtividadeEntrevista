using AutoMapper;
using Dominio;
using Dominio.DTO.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebAtividadeEntrevista.Models;

namespace WebAtividadeEntrevista.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteService _clienteService;

        public ClienteController()
        {
            _clienteService = new ClienteService();
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Incluir(ClienteModelView cliente)
        {
            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ClienteModelView, ClienteDTO>());
                var mapper = new Mapper(config);
                 _clienteService.Adicionar(mapper.Map<ClienteDTO>(cliente));
                return Json("Cadastro efetuado com sucesso");
            }
        }

        [HttpPost]
        public JsonResult Alterar(ClienteModelView cliente)
        {
            if (!this.ModelState.IsValid)
            {
                List<string> erros = (from item in ModelState.Values
                                      from error in item.Errors
                                      select error.ErrorMessage).ToList();

                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }
            else
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ClienteModelView, ClienteDTO>());
                var mapper = new Mapper(config);
                _clienteService.Editar(mapper.Map<ClienteDTO>(cliente));
                return Json("Cadastro efetuado com sucesso");
            }
        }

        [HttpGet]
        public ActionResult Alterar(long id)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClienteDTO, ClienteModelView>());
            var mapper = new Mapper(config);
            var model =  mapper.Map<ClienteModelView>(_clienteService.Buscar(id));

            return View(model);
        }

        [HttpPost]
        public JsonResult ClienteList(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ClienteDTO, ClienteModelView > ());
                var mapper = new Mapper(config);

                List<ClienteModelView> clientes = mapper.Map<List<ClienteModelView>>(_clienteService.Listar());

                //Return result to jTable
                return Json(new { Result = "OK", Records = clientes, TotalRecordCount = clientes.Count });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}