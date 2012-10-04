using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SOTRE.Domain;
using SOTRE.Domain.BLL;

namespace SOTRE.Web
{
    public partial class PesqProduto : System.Web.UI.Page
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
            IQueryable<Produto> query = new ProdutoBLL().ObterTodos();

            this.grvProduto.DataSource = (from q in query
                                          select new { ID = q.id_produto, nome = q.nm_nome, descarga = q.cd_duracao_descarga, capacidade = q.cd_espaco_ocupado, descricao = q.nm_descricao });

            this.grvProduto.DataBind();

            this.upCadastroProduto.Update();
        }

        protected void imgDeletar_Click(object sender, ImageClickEventArgs e)
        {
            ProdutoBLL produtoBLL = new ProdutoBLL();

            produtoBLL.Excluir(int.Parse(((ImageButton)sender).CommandArgument));

            this.CarregarTela();
        }
    }
}