﻿using System;
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
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            usuario.nm_login = loginSOTRE.UserName;
            usuario.nm_senha = loginSOTRE.Password;

            usuario = usuarioDAO.UsuarioAutenticar(usuario);
            
            if (usuario != null)
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
