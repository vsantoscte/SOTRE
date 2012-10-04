using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOTRE.Domain.DAO;

namespace SOTRE.Domain.BLL
{
    public class StatusPedidoBLL: IBaseBLL<Tab_Tipo_Status>
    {

        StatusPedidoDAO statusDAO = null;
        SOTREDataContext contexto = null;

        public StatusPedidoBLL()
        {
            statusDAO = new StatusPedidoDAO();
            contexto = new SOTREDataContext();
        }

        public void Inserir(Tab_Tipo_Status entidade)
        {
            statusDAO.Inserir(entidade, contexto);
        }

        public void Atualizar(Tab_Tipo_Status entidade)
        {
            statusDAO.Atualizar(entidade, contexto);
        }

        public void Excluir(int ID)
        {
            Tab_Tipo_Status tipoStatus = this.ObterPorID(ID);
            statusDAO.Excluir(tipoStatus, contexto = new SOTREDataContext());
        }

        public Tab_Tipo_Status ObterPorID(int ID)
        {
            return statusDAO.ObterPorID(ID, contexto);
        }

        public IQueryable<Tab_Tipo_Status> ObterTodos()
        {
            return statusDAO.ObterTodos(contexto);
        }
    }
}
