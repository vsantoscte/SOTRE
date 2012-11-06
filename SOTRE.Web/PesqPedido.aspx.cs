using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SOTRE.Util;
using SOTRE.Domain;
using SOTRE.Domain.BLL;

namespace SOTRE.Web
{
    public partial class PesqPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CarregarTela();
            }
        }

        private void CarregarTela()
        {
            PedidoBLL pedidoBLL = new PedidoBLL();
            List<PedidoGrid> lstPedidoGrid = new List<PedidoGrid>();
            IQueryable<Pedido> iqPedido = pedidoBLL.ObterTodos();
            PedidoGrid pedidoGrid = null;
            ClienteBLL clienteBLL = new ClienteBLL();
            StatusPedidoBLL statusPedidoBLL = new StatusPedidoBLL();

            foreach (Pedido pedido in iqPedido.ToList<Pedido>())
            {
                pedidoGrid = new PedidoGrid();

                pedidoGrid.ID = pedido.id_pedido;
                pedidoGrid.Cliente = clienteBLL.ObterPorID(pedido.cd_cliente).nm_nome;
                pedidoGrid.Status = statusPedidoBLL.ObterPorID(pedido.cd_status).nm_descricao;

                pedidoGrid.Espaco = pedidoBLL.CalculaPesoTotalPedido(pedido.id_pedido);

                lstPedidoGrid.Add(pedidoGrid);
            }

            this.grvPedido.DataSource = lstPedidoGrid;
            this.grvPedido.DataBind();
        }

        protected void imgDeletar_Click(object sender, ImageClickEventArgs e)
        {
            DemandaBLL demandaBLL = new DemandaBLL();
            PedidoBLL pedidoBLL = new PedidoBLL();
            List<Demanda> lstDemanda = demandaBLL.ObterTodos().Where(w => w.cd_pedido == int.Parse(((ImageButton)sender).CommandArgument)).ToList<Demanda>();

            foreach (Demanda objDemanda in lstDemanda)
            {
                demandaBLL.Excluir(objDemanda.id_demanda);
            }

            pedidoBLL.Excluir(int.Parse(((ImageButton)sender).CommandArgument));

            this.CarregarTela();
        }
    }
}