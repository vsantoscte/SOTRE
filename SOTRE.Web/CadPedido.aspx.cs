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

                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    this.CarregarDadosTela();

                    this.Session["ID"] = int.Parse(Request.QueryString["ID"]);
                }
                else
                {
                    this.Session["ID"] = null;
                }
            }
        }

        private void CarregarDadosTela()
        {
            Pedido pedido = new PedidoBLL().ObterPorID(int.Parse(Request.QueryString["ID"]));
            List<Demanda> lstDemanda = new DemandaBLL().ObterTodos().Where(w => w.cd_pedido == pedido.id_pedido).ToList<Demanda>();
            Produto produto = null;
            ProdutoBLL produtoBLL = new ProdutoBLL();
            List<DemandaGrid> lstDemandaGrid = new List<DemandaGrid>();
            DemandaGrid demandaGrid = null;

            foreach (Demanda objDemanda in lstDemanda)
            {
                produto = produtoBLL.ObterPorID(objDemanda.cd_produto);
                demandaGrid = new DemandaGrid();

                demandaGrid.ID = produto.id_produto;
                demandaGrid.Nome_Produto = produto.nm_nome;
                demandaGrid.Quantidade = objDemanda.qtd_produto;

                lstDemandaGrid.Add(demandaGrid);
            }

            this.ddlCliente.SelectedValue = pedido.cd_cliente.ToString();
            this.ddlStatus.SelectedValue = pedido.cd_status.ToString();
            this.grvPedido.DataSource = lstDemandaGrid;
            this.grvPedido.DataBind();

            Session.Add("DemandasGrid", lstDemandaGrid);
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
            List<DemandaGrid> lstDemandaGrid = (List<DemandaGrid>)Session["DemandasGrid"];

            demandaGrid = lstDemandaGrid.Find(delegate(DemandaGrid d) { return d.ID == int.Parse(((ImageButton)sender).CommandArgument); });

            lstDemandaGrid.Remove(demandaGrid);

            Session.Add("DemandasGrid", lstDemandaGrid);

            CarregarGrid();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PesqPedido.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Pedido pedido = new Pedido();
            PedidoBLL pedidoBLL = new PedidoBLL();
            Demanda demanda = new Demanda();
            DemandaBLL demandaBLL = new DemandaBLL();
            List<DemandaGrid> lstDemandaGrid = (List<DemandaGrid>)Session["DemandasGrid"];
            List<Demanda> lstDemanda = null;

            pedido.cd_cliente = int.Parse(ddlCliente.SelectedValue);
            pedido.cd_status = int.Parse(ddlStatus.SelectedValue);

            if (this.Session["ID"] == null)
            {
                pedidoBLL.Inserir(pedido);
                pedido = pedidoBLL.RetornarUltimoPedido();
            }
            else
            {
                pedido.id_pedido = int.Parse(this.Session["ID"].ToString());
                pedidoBLL.Atualizar(pedido);

                lstDemanda = demandaBLL.ObterTodos().Where(w => w.cd_pedido == pedido.id_pedido).ToList<Demanda>();

                foreach (Demanda objDemanda in lstDemanda)
                {
                    demandaBLL.Excluir(objDemanda.id_demanda);
                }
            }

            foreach (DemandaGrid itemDemandaGrid in lstDemandaGrid)
            {
                demanda = new Demanda();

                demanda.cd_produto = itemDemandaGrid.ID;
                demanda.cd_pedido = pedido.id_pedido;
                demanda.qtd_produto = itemDemandaGrid.Quantidade;

                demandaBLL.Inserir(demanda);
            }

            Response.Redirect("PesqPedido.aspx");

        }

        protected void imgAddProduto_Click(object sender, ImageClickEventArgs e)
        {
            DemandaGrid demandaGrid = new DemandaGrid();
            List<DemandaGrid> lstDemandaGrid = null;

            demandaGrid.ID = int.Parse(ddlProdutos.SelectedValue);
            demandaGrid.Nome_Produto = ddlProdutos.SelectedItem.Text;
            demandaGrid.Quantidade = int.Parse(txtqtd.Text);

            if (Session["DemandasGrid"] == null)
            {
                lstDemandaGrid = new List<DemandaGrid>();

                lstDemandaGrid.Add(demandaGrid);
            }
            else
            {
                lstDemandaGrid = (List<DemandaGrid>)Session["DemandasGrid"];
                lstDemandaGrid.Add(demandaGrid);
            }

            Session.Add("DemandasGrid", lstDemandaGrid);

            CarregarGrid();
        }

        private void CarregarGrid()
        {
            this.grvPedido.DataSource = (List<DemandaGrid>)Session["DemandasGrid"];
            this.grvPedido.DataBind();
        }
    }
}