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
    public partial class CadProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    this.CarregarTela(int.Parse(Request.QueryString["ID"]));

                    this.Session["ID"] = int.Parse(Request.QueryString["ID"]);
                }
                else
                {
                    this.Session["ID"] = null;
                }
            }
        }

        private void CarregarTela(int ID)
        {
            Produto produto = new ProdutoBLL().ObterPorID(ID);

            this.txtNome.Text = produto.nm_nome;
            this.txtDuracao.Text = produto.cd_duracao_descarga.ToString();
            this.txtDescricao.Text = produto.nm_descricao;
            this.txtCadEspaco.Text = produto.cd_espaco_ocupado.ToString();

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PesqProduto.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            ProdutoBLL produtoBLL = new ProdutoBLL();
            Produto produto = new Produto();

            produto.nm_nome = this.txtNome.Text;
            produto.nm_descricao = this.txtDescricao.Text;
            produto.cd_duracao_descarga = int.Parse(this.txtDuracao.Text);
            produto.cd_espaco_ocupado = int.Parse(this.txtCadEspaco.Text);

            if (this.Session["ID"] != null)
            {
                produto.id_produto = int.Parse(this.Session["ID"].ToString());

                produtoBLL.Atualizar(produto);
            }
            else
            {
                produtoBLL.Inserir(produto);
            }

            Response.Redirect("PesqProduto.aspx");
        }
    }
}