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
            IQueryable<Veiculo> query = new VeiculoBLL().ObterTodos();

            this.grvVeiculo.DataSource = (from q in query
                                          select new
                                          {
                                              ID = q.id_veiculo,
                                              nome = q.nm_nome,
                                              status = q.Tab_Tipo_Status_Veiculo.nm_descricao,
                                              capacidade = q.capacidade
                                          });
            this.grvVeiculo.DataBind();

            this.upCadastroVeiculo.Update();
        }

        protected void imgDeletar_Click(object sender, ImageClickEventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();

            usuarioBLL.Excluir(int.Parse(((ImageButton)sender).CommandArgument));

            this.CarregarTela();
        }
    }
}