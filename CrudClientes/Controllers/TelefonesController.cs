using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudClientes.Business;
using CrudClientes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudClientes.Controllers
{
    [Produces("application/json")]
    [Route("api/Telefones")]
    public class TelefonesController : Controller
    {

        private ClienteService _service;

        public TelefonesController(ClienteService service)
        {
            _service = service;
        }

        // POST api/values
        [HttpPost]
        public void PostTelefone([FromBody]TelefoneCliente telefone)
        {
            _service.InserirTelefone(telefone);
        }

        // PUT api/values/5
        [HttpPut]
        public void UpdateTelefone([FromBody]TelefoneCliente telefone)
        {
            _service.AtualizarTelefone(telefone);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void DeleteTelefone(int id)
        {
            _service.ExcluirTelefone(id);
        }
    }
}