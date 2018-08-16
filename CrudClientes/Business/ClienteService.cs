using CrudClientes.Data;
using CrudClientes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudClientes.Business
{
    public class ClienteService
    {
        private ApplicationDbContext _context;

        public ClienteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _context.Clientes.OrderBy(c => c.Nome).ToList();
        }

        public Cliente Obter(long clienteId)
        {
            if(clienteId == 0)
            {
                return null;
            }
            return _context.Clientes.Where(c => c.ClienteId == clienteId).FirstOrDefault();
        }

        public void Inserir(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            cliente.Telefones.ForEach(t => _context.TelefoneClientes.Add(t));
            _context.SaveChanges();
        }

        public bool Atualizar(Cliente cliente)
        {
            var cli = _context.Clientes.Where(c => c.ClienteId == cliente.ClienteId).FirstOrDefault();
            if(cli == null)
            {
                return false;
            }
            cli.CPF = cliente.CPF;
            cli.Email = cliente.Email;
            cli.Nome = cliente.Nome;
            cli.Situacao = cliente.Situacao;
            cli.Telefones = cliente.Telefones;
            _context.SaveChanges();
            return true;
        }

        public bool Excluir(long clienteId)
        {
            var cli = _context.Clientes.Where(c => c.ClienteId == clienteId).FirstOrDefault();
            if (cli == null)
            {
                return false;
            }
            cli.Situacao = false;
            _context.SaveChanges();
            return true;
        }

        public bool Reativar(long clienteId)
        {
            var cli = _context.Clientes.Where(c => c.ClienteId == clienteId).FirstOrDefault();
            if (cli == null)
            {
                return false;
            }
            cli.Situacao = true;
            _context.SaveChanges();
            return true;
        }

        public void InserirTelefone(TelefoneCliente telefone)
        {
            _context.TelefoneClientes.Add(telefone);
            _context.SaveChanges();
        }

        public bool AtualizarTelefone(TelefoneCliente telefone)
        {
            var tel = _context.TelefoneClientes.Where(c => c.TelefoneClienteId == telefone.TelefoneClienteId).FirstOrDefault();
            if (tel == null)
            {
                return false;
            }
            tel.Telefone = telefone.Telefone;
            _context.SaveChanges();
            return true;
        }

        public bool ExcluirTelefone(long telefoneId)
        {
            var tel = _context.TelefoneClientes.Where(c => c.TelefoneClienteId == telefoneId).FirstOrDefault();
            if (tel == null)
            {
                return false;
            }
            _context.TelefoneClientes.Remove(tel);
            _context.SaveChanges();
            return true;
        }
    }
}
