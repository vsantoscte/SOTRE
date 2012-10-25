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
    public partial class PesqVeiculo : System.Web.UI.Page
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
            IQueryable<Veiculo> queryVeiculo = new VeiculoBLL().ObterTodos();
            IQueryable<Status_Veiculo> queryStatus = new StatusVeiculoBLL().ObterTodos();


            this.grvVeiculo.DataSource = (from v in queryVeiculo
                                          join t in queryStatus on v.cd_status equals t.id_status
                                          select new
                                          {
                                              ID = v.id_veiculo,
                                              nome = v.nm_nome,
                                              status = t.nm_descricao,
                                              capacidade = v.capacidade
                                          });
            this.grvVeiculo.DataBind();

            this.upCadastroVeiculo.Update();
        }

        protected void imgDeletar_Click(object sender, ImageClickEventArgs e)
        {
            VeiculoBLL veiculoBLL = new VeiculoBLL();

            veiculoBLL.Excluir(int.Parse(((ImageButton)sender).CommandArgument));

            this.CarregarTela();
        }
    }
}