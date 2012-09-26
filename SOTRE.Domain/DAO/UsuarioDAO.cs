using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SOTRE.Domain
{
    public class UsuarioDAO : BaseDAO<Usuario>, IBaseDAO<Usuario>
    {

        SOTREDataContext contexto = null;

        public UsuarioDAO()
        {
            contexto = new SOTREDataContext();
        }

        /// <summary>
        /// Método Usado Para Obter Usuario para a Autenticação
        /// </summary>
        /// <param name="entidade">Objeto com o Valor do login e senha</param>
        /// <returns>Usuario obtido como retorno da consulta</returns>
        protected Usuario UsuarioAutenticar(Usuario entidade)
        {
            return contexto.Usuario.FirstOrDefault(q => q.nm_login == entidade.nm_login && q.nm_senha == entidade.nm_senha);
        }
    }
}
