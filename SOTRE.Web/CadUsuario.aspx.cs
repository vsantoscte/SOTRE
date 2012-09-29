using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SOTRE.Domain;

namespace SOTRE.Web
{
    public partial class CadUsuario : System.Web.UI.Page
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
            Usuario usuario = new UsuarioBLL().ObterPorID(ID);

            this.txtNome.Text = usuario.nm_nome;
            this.txtCpf.Text = usuario.nm_cpf;
            this.txtCadLogin.Text = usuario.nm_login;
            this.txtCadSenha.Text = usuario.nm_senha;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioBLL UsuarioBLL = new UsuarioBLL();

            usuario.nm_nome = this.txtNome.Text;
            usuario.nm_login = this.txtCadLogin.Text;
            usuario.nm_cpf = this.txtCpf.Text;
            usuario.nm_senha = this.txtCadSenha.Text;

            if (this.Session["ID"] != null)
            {
                usuario.id_usuario = int.Parse(this.Session["ID"].ToString());
                UsuarioBLL.Atualizar(usuario);
            }
            else
            {
                UsuarioBLL.Inserir(usuario);
            }

            Response.Redirect("PesqUsuario.aspx");

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PesqUsuario.aspx");
        }
    }
}