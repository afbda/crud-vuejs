using System.ComponentModel.DataAnnotations.Schema;

namespace CrudClientes.Models
{
    public class TelefoneCliente
    {
        public long TelefoneClienteId { get; set; }
        public long Telefone { get; set; }

        [ForeignKey("ClienteFK")]
        public long ClienteId { get; set; }
        public Cliente Cliente {get; set;}
    }
}
