using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOTRE.Domain.DAO;

namespace SOTRE.Domain.BLL
{
    public class TipoClienteBLL : IBaseBLL<Tipo_Cliente>
    {
        TipoClienteDAO tipoClienteDAO = null;
        SOTREDataContext contexto = null;

        public TipoClienteBLL()
        {
            tipoClienteDAO = new TipoClienteDAO();
            contexto = new SOTREDataContext();
        }

        public void Inserir(Tipo_Cliente entidade)
        {
            tipoClienteDAO.Inserir(entidade, contexto);
        }

        public void Atualizar(Tipo_Cliente entidade)
        {
            tipoClienteDAO.Atualizar(entidade, contexto);
        }

        public void Excluir(int ID)
        {
            Tipo_Cliente tipoCliente = tipoClienteDAO.ObterPorID(ID, contexto);
            tipoClienteDAO.Excluir(tipoCliente, contexto);
        }

        public Tipo_Cliente ObterPorID(int ID)
        {
            return tipoClienteDAO.ObterPorID(ID, contexto);
        }

        public IQueryable<Tipo_Cliente> ObterTodos()
        {
            return tipoClienteDAO.ObterTodos(contexto);
        }
    }
}
