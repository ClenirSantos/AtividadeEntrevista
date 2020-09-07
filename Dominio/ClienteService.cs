using AtividadeEntrevista.Data;
using AtividadeEntrevista.Data.Repositorio;
using AutoMapper;
using Dominio.DTO.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ClienteService
    {
        private readonly ClienteRespositorio _clienteRepositorio;

        public ClienteService()
        {
            _clienteRepositorio = new ClienteRespositorio();

        }

        public void Adicionar(ClienteDTO clienteDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClienteDTO, Cliente>());
            var mapper = new Mapper(config);
            _clienteRepositorio.Adicionar(mapper.Map<Cliente>(clienteDTO));
        }

        public void Editar(ClienteDTO clienteDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClienteDTO, Cliente>());
            var mapper = new Mapper(config);
            _clienteRepositorio.Editar(mapper.Map<Cliente>(clienteDTO));
        }

        public List<ClienteDTO> Listar()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Cliente, ClienteDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<List<ClienteDTO>>(_clienteRepositorio.ListarTodos().ToList());
        }

        public void Exluir(ClienteDTO clienteDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClienteDTO, Cliente>());
            var mapper = new Mapper(config);
            _clienteRepositorio.Excluir(mapper.Map<Cliente>(clienteDTO));
        }


    }
}
