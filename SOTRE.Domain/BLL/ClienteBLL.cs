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
        SOTREDataContext contexto = null;

        public ClienteBLL()
        {
            clienteDAO = new ClienteDAO();
            contexto = new SOTREDataContext();
        }


        public void Inserir(Cliente entidade)
        {
            clienteDAO.Inserir(entidade, contexto);
        }

        public void Atualizar(Cliente entidade)
        {
            clienteDAO.Atualizar(entidade, contexto);
        }

        public void Excluir(int ID)
        {
            Cliente cliente = this.ObterPorID(ID);
            clienteDAO.Excluir(cliente, contexto = new SOTREDataContext());
        }

        public Cliente ObterPorID(int ID)
        {
            return clienteDAO.ObterPorID(ID, contexto);
        }

        public IQueryable<Cliente> ObterTodos()
        {
            return clienteDAO.ObterTodos(contexto);
        }
    }
}
