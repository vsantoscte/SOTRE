using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SOTRE.Domain;

namespace SOTRE.Web.Cadastro
{
    public partial class PesqUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                this.CarregarDados();
        }

        private void CarregarDados()
        {
            IQueryable<Usuario> query = new UsuarioDAO().ObterTodos();

            grvUsuario.DataSource = (from q in query select new { ID = q.id_usuario, nome = q.nm_nome, cpf = q.nm_cpf, login = q.nm_login }).OrderBy(q => q.nome);

            grvUsuario.DataBind();

            this.upCadastroUsuario.Update();
        }

        protected void imgDeletar_Click(object sender, ImageClickEventArgs e)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            usuarioDAO.Excluir(int.Parse(((ImageButton)sender).CommandArgument));

            this.CarregarDados();
        }
    }
}