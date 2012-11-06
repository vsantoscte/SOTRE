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

        public PedidoBLL()
        {
            pedidoDAO = new PedidoDAO();
        }

        public void Inserir(Pedido entidade)
        {
            pedidoDAO.Inserir(entidade);
        }

        public void Atualizar(Pedido entidade)
        {
            pedidoDAO.Atualizar(entidade);
        }

        public void Excluir(int ID)
        {
            Pedido pedido = this.ObterPorID(ID);
            pedidoDAO.Excluir(pedido);
        }

        public Pedido ObterPorID(int ID)
        {
            return pedidoDAO.ObterPorID(ID);
        }

        public IQueryable<Pedido> ObterTodos()
        {
            return pedidoDAO.ObterTodos();
        }

        public Pedido RetornarUltimoPedido()
        {
            return pedidoDAO.RetornarUltimoPedido();
        }

        public double CalculaPesoTotalPedido(int ID)
        {
            DemandaBLL demandaBLL = new DemandaBLL();
            ProdutoBLL produtoBLL = new ProdutoBLL();
            double capacidade = 0;
            Produto produto = null;
            List<Demanda> lstDemanda = demandaBLL.ObterTodos().Where<Demanda>(w => w.cd_pedido == ID).ToList<Demanda>();

            foreach (Demanda objDemanda in lstDemanda)
            {
                produto = produtoBLL.ObterPorID(objDemanda.cd_produto);
                capacidade += (objDemanda.qtd_produto * produto.cd_espaco_ocupado);
            }

            return capacidade;
        }
    }
}
