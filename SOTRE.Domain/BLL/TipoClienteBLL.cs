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

        public TipoClienteBLL()
        {
            tipoClienteDAO = new TipoClienteDAO();
        }

        public void Inserir(Tipo_Cliente entidade)
        {
            tipoClienteDAO.Inserir(entidade);
        }

        public void Atualizar(Tipo_Cliente entidade)
        {
            tipoClienteDAO.Atualizar(entidade);
        }

        public void Excluir(int ID)
        {
            Tipo_Cliente tipoCliente = tipoClienteDAO.ObterPorID(ID);
            tipoClienteDAO.Excluir(tipoCliente);
        }

        public Tipo_Cliente ObterPorID(int ID)
        {
            return tipoClienteDAO.ObterPorID(ID);
        }

        public IQueryable<Tipo_Cliente> ObterTodos()
        {
            return tipoClienteDAO.ObterTodos();
        }
    }
}
