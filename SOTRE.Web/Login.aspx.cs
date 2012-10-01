using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SOTRE.Domain;

namespace SOS.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void loginSOTRE_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioBLL UsuarioBLL = new UsuarioBLL();

            usuario.nm_login = loginSOTRE.UserName;
            usuario.nm_senha = loginSOTRE.Password;

            Boolean autenticar = UsuarioBLL.UsuarioAutenticar(usuario);

            if (autenticar)
            {
                e.Authenticated = true;
                FormsAuthentication.RedirectFromLoginPage(loginSOTRE.UserName, false);
            }
            else
            {
                e.Authenticated = false;
            }
        }
    }
}
