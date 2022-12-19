using Azure.Core;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication1.Infraestructure.Domain;
using WebApplication1.Infraestructure.Standard;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConteinerController : ControllerBase
    {
        private readonly IConteinerRepository _repository;
        private readonly IValidator<Conteiner> _validator;

        public ConteinerController(IConteinerRepository repository, IValidator<Conteiner> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        // GET: api/<ConteinerController>
        [HttpGet]
        public IEnumerable<Conteiner> Get()
        {
            return _repository.BuscarTodos().Result;
        }

        // GET api/<ConteinerController>/5
        [HttpGet("{id}")]
        public Conteiner Get(int id)
        {
            return _repository.PesquisarPorId(id).Result;
        }

        // POST api/<ConteinerController>
        [HttpPost]
        public IActionResult Post([FromBody] Conteiner request)
        {
            var result = request.ValidateConteiner(_validator);

            if (result.IsValid)
            {
                var response = _repository.Incluir(request).Result;

                if (!response)
                {
                    return StatusCode(500, "Ocorreu um erro ao salvar o contêiner");
                }

                return StatusCode(200);
            }

            return StatusCode(500, result.Errors);
        }

        // PUT api/<ConteinerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Conteiner request)
        {
            if (id < 1)
            {
                return StatusCode(400, "O Id da query não foi informado");
            }

            if (id != request.Id)
            {
                return StatusCode(400, "O Id da query é diferente do Id informado no corpo da requisição");
            }

            var result = request.ValidateConteiner(_validator);

            if (result.IsValid)
            {
                var response = _repository.Alterar(request).Result;

                if (!response)
                {
                    return StatusCode(500, "Ocorreu um erro ao alterar o contêiner");
                }

                return StatusCode(201);
            }

            return StatusCode(500, result.Errors);
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
    }
}
