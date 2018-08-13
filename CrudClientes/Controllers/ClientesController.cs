using System.Collections.Generic;
using CrudClientes.Business;
using CrudClientes.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudClientes.Controllers
{
    [Produces("application/json")]
    [Route("api/clientes")]
    public class ClientesController : Controller
    {
        private ClienteService _service;

        public ClientesController(ClienteService service)
        {
            _service = service;
        }
        // GET api/Clientes
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return _service.ObterTodos();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Cliente Get(long id)
        {
            return _service.Obter(id);
        }

        // POST api/values
        [HttpPost]
        public void Post()
        {
            _service.Inserir(new Cliente());
        }

        // PUT api/values/5
        [HttpPut]
        public void Update()
        {
            _service.Atualizar(new Cliente());
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Excluir(id);
        }
    }
}