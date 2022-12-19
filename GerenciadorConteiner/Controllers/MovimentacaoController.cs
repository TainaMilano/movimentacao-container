using Application.Infraestructure.Domain;
using Application.Models;
using Application.ViewModel;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentacaoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovimentacaoRepository _repository;

        public MovimentacaoController(IMovimentacaoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // POST api/<ConteinerController>
        [HttpPost]
        public IActionResult Post([FromBody] MovimentacaoRequest request)
        {
            var movimentacao = _mapper.Map<Movimentacao>(request);
            var response = _repository.Incluir(movimentacao).Result;

            if (!response)
            {
                return StatusCode(500, "Ocorreu um erro ao salvar a movimentação");
            }

            return StatusCode(200);
        }

        // PUT api/<ConteinerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MovimentacaoRequest request)
        {
            if (id < 1)
            {
                return StatusCode(400, "O Id da query não foi informado");
            }

            if (id != request.Id)
            {
                return StatusCode(400, "O Id da query é diferente do Id informado no corpo da requisição");
            }

            var movimentacao = _mapper.Map<Movimentacao>(request);
            var response = _repository.Alterar(movimentacao).Result;

            if (!response)
            {
                return StatusCode(500, "Ocorreu um erro ao alterar o contêiner");
            }

            return StatusCode(201);
        }

        // DELETE api/<ConteinerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 1)
            {
                return StatusCode(400, "O Id da query não foi informado");
            }

            var response = _repository.Excluir(id).Result;

            if (!response)
            {
                return StatusCode(500, "Ocorreu um erro ao excluir o contêiner");
            }

            return StatusCode(201);
        }

        // GET api/<ConteinerController>/5
        [HttpGet("{id}")]
        public Movimentacao Get(int id)
        {
            return _repository.PesquisarPorId(id).Result;
        }

        // GET: api/<ConteinerController>
        [HttpGet]
        public IEnumerable<Movimentacao> Get()
        {
            return _repository.BuscarTodos().Result;
        }

        // GET: api/<ConteinerController>
        [HttpGet("cliente")]
        public IEnumerable<object> PesquisarTodosAgrupadosPorCliente()
        {
            var movimentacoes = _repository.BuscarTodosComCliente().Result;

            var response = new List<object>();
            foreach (var group in movimentacoes.GroupBy(m => m.Conteiner?.Cliente))
            {
                var result = new List<Movimentacao>();
                foreach (var movimentacao in group)
                {
                    movimentacao.Conteiner.Movimentacoes = null;
                    result.Add(movimentacao);
                }

                response.Add(result);
            }

            return response;
        }

        // GET: api/<ConteinerController>
        [HttpGet("tipo-movimentacao")]
        public IEnumerable<object> PesquisarTodosAgrupadosPorTipoMovimentacao()
        {
            var movimentacoes = _repository.BuscarTodos().Result;

            var response = new List<object>();
            foreach (var group in movimentacoes.GroupBy(m => m.Tipo))
            {
                var result = new List<Movimentacao>();
                foreach (var movimentacao in group)
                {
                    result.Add(movimentacao);
                }

                response.Add(result);
            }

            return response;
        }
    }
}
