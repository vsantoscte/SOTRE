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
    public partial class CadVeiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CarregarComboStatusVeiculo();

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
            Veiculo veiculo = new VeiculoBLL().ObterPorID(ID);

            this.txtNome.Text = veiculo.nm_nome;
            this.ddlStatus.SelectedValue = veiculo.cd_status.ToString();
            this.txtCapacidade.Text = veiculo.capacidade.ToString();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PesqVeiculo.aspx");
        }

        private void CarregarComboStatusVeiculo()
        {
            this.ddlStatus.DataSource = Util.Util.CarregarComboStatusVeiculo();
            this.ddlStatus.DataTextField = "nm_descricao";
            this.ddlStatus.DataValueField = "id_status";
            this.ddlStatus.DataBind();
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Veiculo veiculo = new Veiculo();
            VeiculoBLL veiculoBLL = new VeiculoBLL();

            veiculo.nm_nome = this.txtNome.Text;
            veiculo.cd_status = int.Parse(this.ddlStatus.SelectedValue);
            veiculo.capacidade = double.Parse(this.txtCapacidade.Text);

            if (this.Session["ID"] != null)
            {
                veiculo.id_veiculo = int.Parse(this.Session["ID"].ToString());
                veiculoBLL.Atualizar(veiculo);
            }
            else
            {
                veiculoBLL.Inserir(veiculo);
            }

            Response.Redirect("PesqVeiculo.aspx");
        }
    }
}