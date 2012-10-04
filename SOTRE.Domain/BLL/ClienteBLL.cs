using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOTRE.Domain.DAO;

namespace SOTRE.Domain.BLL
{
    public class ClienteBLL : IBaseBLL<Cliente>
    {
        ClienteDAO clienteDAO = null;

        public ClienteBLL()
        {
            clienteDAO = new ClienteDAO();
        }


        public void Inserir(Cliente entidade)
        {
            clienteDAO.Inserir(entidade);
        }

        public void Atualizar(Cliente entidade)
        {
            clienteDAO.Atualizar(entidade);
        }

        public void Excluir(int ID)
        {
            Cliente cliente = this.ObterPorID(ID);
            clienteDAO.Excluir(cliente);
        }

        public Cliente ObterPorID(int ID)
        {
            return clienteDAO.ObterPorID(ID);
        }

        public IQueryable<Cliente> ObterTodos()
        {
            return clienteDAO.ObterTodos();
        }
    }
}
