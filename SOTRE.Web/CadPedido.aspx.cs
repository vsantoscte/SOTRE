using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SOTRE.Domain;
using SOTRE.Util;
using SOTRE.Domain.BLL;

namespace SOTRE.Web
{
    public partial class CadPedido : System.Web.UI.Page
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
            CarregarCompoCliente();
            CarregarCompoProduto();
            CarregarCompoStatus();
        }


        private void CarregarCompoCliente()
        {
            ddlCliente.DataSource = Util.Util.CarregarComboCliente();
            ddlCliente.DataTextField = "nm_nome";
            ddlCliente.DataValueField = "id_cliente";
            ddlCliente.DataBind();
        }

        private void CarregarCompoStatus()
        {
            ddlStatus.DataSource = Util.Util.CarregarComboStatus();
            ddlStatus.DataTextField = "nm_descricao";
            ddlStatus.DataValueField = "id_status";
            ddlStatus.DataBind();
        }

        private void CarregarCompoProduto()
        {
            ddlProdutos.DataSource = Util.Util.CarregarComboProduto();
            ddlProdutos.DataTextField = "nm_nome";
            ddlProdutos.DataValueField = "id_produto";
            ddlProdutos.DataBind();
        }

        protected void imgDeletar_Click(object sender, ImageClickEventArgs e)
        {
            DemandaGrid demandaGrid = new DemandaGrid();
            List<DemandaGrid> lstDemanda = (List<DemandaGrid>)Session["DemandasGrid"];

            demandaGrid = lstDemanda.Find(delegate(DemandaGrid d) { return d.ID == int.Parse(((ImageButton)sender).CommandArgument); });

            lstDemanda.Remove(demandaGrid);

            Session.Add("DemandasGrid", lstDemanda);

            CarregarGrid();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Pedido pedido = new Pedido();
            PedidoBLL pedidoBLL = new PedidoBLL();
            Demanda demanda = new Demanda();
            DemandaBLL demandaBLL = new DemandaBLL();
            List<DemandaGrid> lstDemanda = (List<DemandaGrid>)Session["DemandasGrid"];

            pedido.cd_cliente = int.Parse(ddlCliente.SelectedValue);
            pedido.cd_status = int.Parse(ddlStatus.SelectedValue);

            pedidoBLL.Inserir(pedido);

            pedido = pedidoBLL.RetornarUltimoPedido();

            foreach (DemandaGrid itemDemandaGrid in lstDemanda)
            {
                demanda.cd_produto = itemDemandaGrid.ID;
                demanda.cd_pedido = pedido.id_pedido;
                demanda.qtd_produto = itemDemandaGrid.Quantidade;

                demandaBLL.Inserir(demanda);
            }

        }

        protected void imgAddProduto_Click(object sender, ImageClickEventArgs e)
        {
            DemandaGrid demandaGrid = new DemandaGrid();
            List<DemandaGrid> lstDemanda = null;

            demandaGrid.ID = int.Parse(ddlProdutos.SelectedValue);
            demandaGrid.Nome_Produto = ddlProdutos.SelectedItem.Text;
            demandaGrid.Quantidade = int.Parse(txtqtd.Text);

            if (Session["DemandasGrid"] == null)
            {
                lstDemanda = new List<DemandaGrid>();

                lstDemanda.Add(demandaGrid);
            }
            else
            {
                lstDemanda = (List<DemandaGrid>)Session["DemandasGrid"];
                lstDemanda.Add(demandaGrid);
            }

            Session.Add("DemandasGrid", lstDemanda);

            CarregarGrid();
        }

        private void CarregarGrid()
        {
            this.grvPedido.DataSource = (List<DemandaGrid>)Session["DemandasGrid"];
            this.grvPedido.DataBind();
        }
    }
}