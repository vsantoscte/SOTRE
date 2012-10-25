using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOTRE.Domain.DAO;

namespace SOTRE.Domain.BLL
{
    public class StatusPedidoBLL : IBaseBLL<Status_Pedido>
    {

        StatusPedidoDAO statusDAO = null;

        public StatusPedidoBLL()
        {
            statusDAO = new StatusPedidoDAO();
        }

        public void Inserir(Status_Pedido entidade)
        {
            statusDAO.Inserir(entidade);
        }

        public void Atualizar(Status_Pedido entidade)
        {
            statusDAO.Atualizar(entidade);
        }

        public void Excluir(int ID)
        {
            Status_Pedido tipoStatus = this.ObterPorID(ID);
            statusDAO.Excluir(tipoStatus);
        }

        public Status_Pedido ObterPorID(int ID)
        {
            return statusDAO.ObterPorID(ID);
        }

        public IQueryable<Status_Pedido> ObterTodos()
        {
            return statusDAO.ObterTodos();
        }
    }
}
