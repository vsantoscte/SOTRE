using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SOTRE.Domain.DAO;

namespace SOTRE.Domain.BLL
{
    public class PedidoBLL : IBaseBLL<Pedido>
    {
        PedidoDAO pedidoDAO = null;
        SOTREDataContext contexto = null;

        public PedidoBLL()
        {
            pedidoDAO = new PedidoDAO();
            contexto = new SOTREDataContext();
        }

        public void Inserir(Pedido entidade)
        {
            pedidoDAO.Inserir(entidade, contexto);
        }

        public void Atualizar(Pedido entidade)
        {
            pedidoDAO.Atualizar(entidade, contexto);
        }

        public void Excluir(int ID)
        {
            Pedido pedido = this.ObterPorID(ID);
            pedidoDAO.Excluir(pedido, contexto = new SOTREDataContext());
        }

        public Pedido ObterPorID(int ID)
        {
            return pedidoDAO.ObterPorID(ID, contexto);
        }

        public IQueryable<Pedido> ObterTodos()
        {
            return pedidoDAO.ObterTodos(contexto);
        }

        public Pedido RetornarUltimoPedido()
        {
            if (contexto == null)
            {
                contexto = new SOTREDataContext();
            }
            return pedidoDAO.RetornarUltimoPedido(contexto);
        }
    }
}
