using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudClientes.Models
{
    public class Cliente
    {
        public long ClienteId { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Situacao { get; set; }
        public List<TelefoneCliente> Telefones { get; set; }
    }
}
