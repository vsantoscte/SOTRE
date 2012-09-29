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
    public partial class PesqCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CarregarTelaCliente();
            }
        }

        private void CarregarTelaCliente()
        {
            IQueryable<Cliente> queryCliente = new ClienteBLL().ObterTodos();

            IQueryable<Tipo_Cliente> queryTipoCliente = new TipoClienteBLL().ObterTodos();

            grvCliente.DataSource = (from c in queryCliente
                                     join t in queryTipoCliente on c.cd_tipo equals t.id_tipo
                                     select new { ID = c.id_cliente, cpf_cnpj = c.nm_cpf_cnpj, tipo = t.nm_descricao_tipo, nome = c.nm_nome, bairro = c.nm_bairro, cep = c.nm_cep });
            grvCliente.DataBind();

            this.upCadastroCliente.Update();
        }

        protected void imgDeletar_Click(object sender, ImageClickEventArgs e)
        {
            ClienteBLL clienteBLL = new ClienteBLL();

            clienteBLL.Excluir(int.Parse(((ImageButton)sender).CommandArgument));

            this.CarregarTelaCliente();
        }
    }
}